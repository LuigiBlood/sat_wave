using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SatellaWave
{
    public partial class EventPlazaEditor : Form
    {
        static ushort selectedTile;
        public static ushort[] tileMap;
        public static bool[] doorLocations;

        public static Bitmap tileSetImage; //Avoid rerendering too much

        public static byte[] TILEdata;   //0x2000 - 0xA000 VRAM (Tile Data)
        public static ushort[] TILESETdata; //0x2200 - 0x4200 WRAM (Cell Data)
        public static Color[][] PALdata; //0x2000 - 0x2200 WRAM (Palette)
        public static byte[] SOLIDdata;  //0x4200 - 0x4600 WRAM (Solid/Priority)

        public EventPlazaEditor(ushort[] _tilemap, bool[] _doors, Color[] _pal, byte[] _tiles, ushort[] _map)
        {
            InitializeComponent();
            selectedTile = 0;
            tileMap = _tilemap;
            doorLocations = _doors;

            InitPaletteData(_pal);
            InitTileData(_tiles);
            InitTilesetData(_map);

            InitTilesetImage();
            UpdateTilesetImage();
            UpdateTilemapImage();
        }

        public void InitTilesetImage()
        {
            tileSetImage = new Bitmap(16 * 8, 16 * 128);

            using (Graphics g = Graphics.FromImage(tileSetImage))
            {
                for (int y = 0; y < 128; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        g.DrawImageUnscaled(DrawCell(x + y * 8), 16 * x, 16 * y);
                    }
                }
            }
        }

        public void InitTileData(byte[] _tiles)
        {
            TILEdata = new byte[ResourceAccess.defaultTilesBSX.Length];
            for (int i = 0; i < TILEdata.Length; i++)
            {
                TILEdata[i] = ResourceAccess.defaultTilesBSX[i];
                if (i >= 0x7200 && i < (_tiles.Length + 0x7200))
                {
                    TILEdata[i] = _tiles[i - 0x7200];
                }
            }
        }

        public void InitTilesetData(ushort[] _map)
        {
            TILESETdata = new ushort[ResourceAccess.defaultTileSetBSX.Length / 2];
            for (int i = 0; i < TILESETdata.Length; i++)
            {
                TILESETdata[i] = (ushort)(ResourceAccess.defaultTileSetBSX[i * 2] | (ResourceAccess.defaultTileSetBSX[(i * 2) + 1] << 8));
                if (i >= 0xF40 && i < (_map.Length + 0xF40))
                {
                    TILESETdata[i] = _map[i - 0xF40];
                }
            }
        }

        public void InitPaletteData(Color[] _pal)
        {
            PALdata = new Color[8][];
            for (int i = 0; i < PALdata.Length; i++)
            {
                if (i != 5)
                {
                    PALdata[i] = new Color[16];
                    for (int j = 0; j < PALdata[i].Length; j++)
                    {
                        ushort colordata = (ushort)(ResourceAccess.defaultPaletteBSX[(i * 32) + (j * 2)] | (ResourceAccess.defaultPaletteBSX[(i * 32) + (j * 2) + 1] << 8));
                        int r = (int)((float)((colordata & 0x1F) / 31.0f) * 255);
                        int g = (int)((float)(((colordata >> 5) & 0x1F) / 31.0f) * 255);
                        int b = (int)((float)(((colordata >> 10) & 0x1F) / 31.0f) * 255);

                        if (j != 0)
                            PALdata[i][j] = Color.FromArgb(r, g, b);
                        else
                            PALdata[i][j] = Color.FromArgb(0, 0, 0, 0);
                    }
                }
                else
                {
                    PALdata[i] = _pal;
                }
            }
        }

        public static Bitmap DrawCell(int id)
        {
            Bitmap celltemp = new Bitmap(16, 16);

            id &= 0x3FF;

            using (Graphics g = Graphics.FromImage(celltemp))
            {
                g.DrawImageUnscaled(DrawTile(TILESETdata[id * 4 + 0] & 0x03FF, (TILESETdata[id * 4 + 0] & 0x1C00) >> 10, (TILESETdata[id * 4 + 0] & 0x4000) != 0, (TILESETdata[id * 4 + 0] & 0x8000) != 0), 0, 0);
                g.DrawImageUnscaled(DrawTile(TILESETdata[id * 4 + 1] & 0x03FF, (TILESETdata[id * 4 + 1] & 0x1C00) >> 10, (TILESETdata[id * 4 + 1] & 0x4000) != 0, (TILESETdata[id * 4 + 1] & 0x8000) != 0), 0, 8);
                g.DrawImageUnscaled(DrawTile(TILESETdata[id * 4 + 2] & 0x03FF, (TILESETdata[id * 4 + 2] & 0x1C00) >> 10, (TILESETdata[id * 4 + 2] & 0x4000) != 0, (TILESETdata[id * 4 + 2] & 0x8000) != 0), 8, 0);
                g.DrawImageUnscaled(DrawTile(TILESETdata[id * 4 + 3] & 0x03FF, (TILESETdata[id * 4 + 3] & 0x1C00) >> 10, (TILESETdata[id * 4 + 3] & 0x4000) != 0, (TILESETdata[id * 4 + 3] & 0x8000) != 0), 8, 8);
            }

            return celltemp;
        }

        public static Bitmap DrawTile(int id, int pal, bool xflip, bool yflip)
        {
            //4BPP SNES
            Bitmap tiletemp = new Bitmap(8, 8);

            id = id & 0x3FF;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int colorID = (((TILEdata[(id * 32) + (y * 2)] & (1 << (7 - x))) << x) >> 7)
                        | (((TILEdata[(id * 32) + (y * 2) + 1] & (1 << (7 - x))) << x) >> 6)
                        | (((TILEdata[(id * 32) + (y * 2) + 16] & (1 << (7 - x))) << x) >> 5)
                        | (((TILEdata[(id * 32) + (y * 2) + 16 + 1] & (1 << (7 - x))) << x) >> 4);

                    int xt = x;
                    if (xflip) xt = 7 - x;

                    int yt = y;
                    if (yflip) yt = 7 - y;

                    tiletemp.SetPixel(xt, yt, PALdata[pal][colorID]);
                }
            }

            return tiletemp;
        }

        public void UpdateTilesetImage()
        {
            Bitmap tileset = new Bitmap(tileSetImage);
            using (Graphics g = Graphics.FromImage(tileset))
            {
                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, (selectedTile % 8) * 16, (selectedTile / 8) * 16, 16, 16);
            }
            pictureBoxTileset.Image = tileset;
        }

        public void UpdateTilemapImage()
        {
            Bitmap tilemapimage = DrawTileMap();

            using (Graphics g = Graphics.FromImage(tilemapimage))
            {
                Bitmap tilemapimagetemp = new Bitmap(tilemapimage);
                g.ScaleTransform(2f, 2f);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.Clear(Color.Transparent);
                g.DrawImage(tilemapimagetemp, 0.00001f, 0.00001f);
            }

            pictureBoxBuilding.Image = tilemapimage;
        }

        public Bitmap DrawTileMap()
        {
            Bitmap tilemapimage = new Bitmap(32 * 4, 32 * 7);
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    using (Graphics g = Graphics.FromImage(tilemapimage))
                    {
                        g.DrawImageUnscaled(DrawCell(tileMap[x + (y * 4)]), x * 16, y * 16);

                        if ((GetEditorMode() == 2) && doorLocations[x + (y * 4)])
                        {
                            Brush brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                            g.FillRectangle(brush, x * 16, y * 16, 16, 16);
                        }
                    }
                }
            }

            return tilemapimage;
        }

        public int GetEditorMode()
        {
            if (radioButtonBuildingMode.Checked)
                return 0;
            else if (radioButtonDoorMode.Checked)
                return 2;
            else
                return -1;
        }

        private void pictureBoxTileset_Click(object sender, EventArgs e)
        {
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTile = (ushort)((coordinates.X / 16) + ((coordinates.Y / 16) * 8));
            UpdateTilesetImage();
        }

        private void pictureBoxBuilding_MouseEdit(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left
                && e.Location.X >= 0 && e.Location.X < (32 * 4)
                && e.Location.Y >= 0 && e.Location.Y < (32 * 7))
            {
                if (GetEditorMode() == 0)
                {
                    if (tileMap[(e.Location.X / 32) + ((e.Location.Y / 32) * 4)] != selectedTile)
                    {
                        tileMap[(e.Location.X / 32) + ((e.Location.Y / 32) * 4)] = selectedTile;
                        UpdateTilemapImage();
                    }
                }
            }
        }

        private void pictureBoxBuilding_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left
                && ((MouseEventArgs)e).Location.X >= 0 && ((MouseEventArgs)e).Location.X < (32 * 4)
                && ((MouseEventArgs)e).Location.Y >= 0 && ((MouseEventArgs)e).Location.Y < (32 * 7))
            {
                if (GetEditorMode() == 2)
                {
                    doorLocations[(((MouseEventArgs)e).Location.X / 32) + ((((MouseEventArgs)e).Location.Y / 32) * 4)] = !doorLocations[(((MouseEventArgs)e).Location.X / 32) + ((((MouseEventArgs)e).Location.Y / 32) * 4)];
                    UpdateTilemapImage();
                }
            }
        }

        private void radioButtonBuildingMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBuildingMode.Checked)
            {
                UpdateTilemapImage();
            }
        }

        private void radioButtonDoorMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDoorMode.Checked)
            {
                UpdateTilemapImage();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Import XML
            OpenFileDialog fileloadDialog = new OpenFileDialog();
            fileloadDialog.Filter = "XML File (*.xml)|*.xml|All files|*.*";
            fileloadDialog.Title = "Import Custom Event Plaza XML File...";
            fileloadDialog.Multiselect = false;

            if (fileloadDialog.ShowDialog() == DialogResult.OK)
            {
                loadXMLEventPlaza(fileloadDialog.FileName);

                InitTilesetImage();
                UpdateTilesetImage();
                UpdateTilemapImage();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export XML
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML File (*.xml)|*.xml|All files|*.*";
            saveFileDialog.Title = "Export Custom Event Plaza XML File...";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveXMLEventPlaza(saveFileDialog.FileName);
            }
        }

        private void loadXMLEventPlaza(string filepath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            if (xmlDoc.DocumentElement.Name != "eventplaza")
            {
                MessageBox.Show("This is not a valid Custom Event Plaza XML.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (XmlNode _node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (_node.Name == "palette")
                {
                    if (!(new Regex(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$").Match(_node.InnerText).Success))
                    {
                        //Check Palette data
                        MessageBox.Show("Palette Data is invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] tempPAL = Convert.FromBase64String(_node.InnerText);
                    for (int i = 0; i < PALdata[5].Length; i++)
                    {
                        PALdata[5][i] = Color.FromArgb(tempPAL[i * 3], tempPAL[(i * 3) + 1], tempPAL[(i * 3) + 2]);
                    }
                }
                else if (_node.Name == "map")
                {
                    if (!(new Regex(@"^[0-9a-fA-F]{112}$").Match(_node.InnerText).Success))
                    {
                        //Check tilemap data
                        MessageBox.Show("Map Data is invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string temp = _node.InnerText;
                    for (int i = 0; i < tileMap.Length; i++)
                    {
                        ushort _map;
                        ushort.TryParse(temp.Substring(4 * i, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _map);
                        tileMap[i] = _map;
                    }
                }
                else if (_node.Name == "tiles")
                {
                    if (!(new Regex(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$").Match(_node.InnerText).Success))
                    {
                        //Check tile data
                        MessageBox.Show("Tile Data is invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] temp = Convert.FromBase64String(_node.InnerText);
                    temp.CopyTo(TILEdata, 0x7200);
                }
                else if (_node.Name == "tileset")
                {
                    if (!(new Regex(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$").Match(_node.InnerText).Success))
                    {
                        //Check tileset data
                        MessageBox.Show("TileSet Data is invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] temp = Convert.FromBase64String(_node.InnerText);

                    for (int n = 0; n < temp.Length; n += 2)
                    {
                        TILESETdata[0xF40 + (n / 2)] = BitConverter.ToUInt16(temp, n);
                    }
                }
                else if (_node.Name == "door")
                {
                    if (!(new Regex(@"^[0-1]{28}$").Match(_node.InnerText).Success))
                    {
                        //Check Door data
                        MessageBox.Show("Door Location data in invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < doorLocations.Length; i++)
                    {
                        doorLocations[i] = (_node.InnerText[i] == '1');
                    }
                }
            }
        }

        private void saveXMLEventPlaza(string filepath)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            XmlWriter xmlWriter = XmlWriter.Create(filepath, xmlWriterSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("eventplaza");

            //Custom Palette
            xmlWriter.WriteStartElement("palette");
            List<byte> RGBmap = new List<byte>();
            foreach (Color colormap in GetCustomPalette())
            {
                RGBmap.Add(colormap.R);
                RGBmap.Add(colormap.G);
                RGBmap.Add(colormap.B);
            }
            xmlWriter.WriteString(Convert.ToBase64String(RGBmap.ToArray()));

            xmlWriter.WriteEndElement();

            //Tilemap
            xmlWriter.WriteStartElement("map");
            foreach (ushort datamap in GetTileMap())
            {
                xmlWriter.WriteString(datamap.ToString("X4"));
            }
            xmlWriter.WriteEndElement();

            //Tiles
            xmlWriter.WriteStartElement("tiles");

            xmlWriter.WriteString(Convert.ToBase64String(GetCustomTiles()));

            xmlWriter.WriteEndElement();

            //Custom Tileset
            xmlWriter.WriteStartElement("tileset");
            List<byte> tilesetbyte = new List<byte>();
            foreach (ushort tileset in GetCustomTileSet())
            {
                tilesetbyte.AddRange(BitConverter.GetBytes(tileset));
            }
            xmlWriter.WriteString(Convert.ToBase64String(tilesetbyte.ToArray()));

            xmlWriter.WriteEndElement();

            //Door locations
            xmlWriter.WriteStartElement("door");
            foreach (bool datadoor in GetDoorLocations())
            {
                if (datadoor == true)
                    xmlWriter.WriteString("1");
                else
                    xmlWriter.WriteString("0");
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void buttonSuperFamiconv_Click(object sender, EventArgs e)
        {
            EventPlazaEasyGraphicsImport gfximport = new EventPlazaEasyGraphicsImport();
            if (gfximport.ShowDialog() == DialogResult.OK)
            {
                if (gfximport.isPaletteDataImported)
                {
                    PALdata[5] = gfximport.GetCustomPalette();
                }

                if (gfximport.isTileDataImported)
                {
                    byte[] tiletemp = gfximport.GetCustomTiles();
                    for (int i = 0; i < 0xE00; i++)
                    {
                        if (i < tiletemp.Length)
                        {
                            TILEdata[0x7200 + i] = tiletemp[i];
                        }
                        else
                        {
                            TILEdata[0x7200 + i] = 0;
                        }
                    }
                }

                if (gfximport.isTilesetDataImported)
                {
                    ushort[] tilesettemp = gfximport.GetCustomTileSet();
                    for (int i = 0; i < 192; i++)
                    {
                        if (i < tilesettemp.Length)
                        {
                            TILESETdata[(0x3D0 * 4) + i] = tilesettemp[i];
                        }
                        else
                        {
                            TILESETdata[(0x3D0 * 4) + i] = 0;
                        }
                    }

                    tileMap = gfximport.GetCustomTileMap();

                    InitTilesetImage();
                    UpdateTilesetImage();
                    UpdateTilemapImage();
                }
            }
        }

        //Save
        public ushort[] GetTileMap()
        {
            return tileMap;
        }

        public bool[] GetDoorLocations()
        {
            return doorLocations;
        }

        public Color[] GetCustomPalette()
        {
            return PALdata[5];
        }

        public ushort[] GetCustomTileSet()
        {
            ushort[] temp = new ushort[188];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = TILESETdata[0xF40 + i];
            }

            return temp;
        }

        public byte[] GetCustomTiles()
        {
            byte[] temp = new byte[0xE00];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = TILEdata[0x7200 + i];
            }

            return temp;
        }
    }
}
