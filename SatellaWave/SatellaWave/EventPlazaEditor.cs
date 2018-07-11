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
        public static byte[] COLdata;  //0x4200 - 0x4600 WRAM (Solid/Priority)
        public static List<EventPlazaAnimationFrame> frames;

        public EventPlazaEditor(ushort[] _tilemap, bool[] _doors, Color[] _pal, byte[] _tiles, ushort[] _map, byte[] _col, List<EventPlazaAnimationFrame> _frames)
        {
            InitializeComponent();
            selectedTile = 0;

            tileMap = new ushort[_tilemap.Length];
            _tilemap.CopyTo(tileMap, 0);

            doorLocations = new bool[_doors.Length];
            _doors.CopyTo(doorLocations, 0);

            COLdata = new byte[_col.Length];
            _col.CopyTo(COLdata, 0);

            frames = new List<EventPlazaAnimationFrame>();
            frames.AddRange(_frames);

            InitPaletteData(_pal);
            InitTileData(_tiles);
            InitTilesetData(_map);

            InitTilesetImage();
            UpdateTilesetImage();
            UpdateTilemapImage();
        }

        private void InitTilesetImage()
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

        private void InitTileData()
        {
            TILEdata = new byte[ResourceAccess.defaultTilesBSX.Length];
            for (int i = 0; i < TILEdata.Length; i++)
            {
                TILEdata[i] = ResourceAccess.defaultTilesBSX[i];
            }
        }

        private void InitTileData(byte[] _tiles)
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

        private void InitTilesetData()
        {
            TILESETdata = new ushort[ResourceAccess.defaultTileSetBSX.Length / 2];
            for (int i = 0; i < TILESETdata.Length; i++)
            {
                TILESETdata[i] = (ushort)(ResourceAccess.defaultTileSetBSX[i * 2] | (ResourceAccess.defaultTileSetBSX[(i * 2) + 1] << 8));
            }
        }

        private void InitTilesetData(ushort[] _map)
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

        private void InitPaletteData()
        {
            PALdata = new Color[8][];
            for (int i = 0; i < PALdata.Length; i++)
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
        }

        private void InitPaletteData(Color[] _pal)
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

        private static Bitmap DrawCell(int id)
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

        private static Bitmap DrawTile(int id, int pal, bool xflip, bool yflip)
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

        private void UpdateTilesetImage()
        {
            Bitmap tileset = new Bitmap(tileSetImage);
            using (Graphics g = Graphics.FromImage(tileset))
            {
                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, (selectedTile % 8) * 16, (selectedTile / 8) * 16, 16, 16);
            }
            pictureBoxTileset.Image = tileset;
        }

        private void UpdateTilemapImage()
        {
            Bitmap tilemapimage = DrawTileMap();

            using (Graphics g = Graphics.FromImage(tilemapimage))
            {
                Bitmap tilemapimagetemp = new Bitmap(tilemapimage);
                g.ScaleTransform(2f, 2f);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(tilemapimagetemp, 0f, 0f);
            }

            pictureBoxBuilding.Image = tilemapimage;
        }

        private Bitmap DrawTileMap(bool noOverlay = false)
        {
            Bitmap tilemapimage = new Bitmap(32 * 4, 32 * 7);
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    using (Graphics g = Graphics.FromImage(tilemapimage))
                    {
                        g.DrawImageUnscaled(DrawCell(tileMap[x + (y * 4)]), x * 16, y * 16);

                        if ((GetEditorMode() == 2) && doorLocations[x + (y * 4)] && !noOverlay)
                        {
                            Brush brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                            g.FillRectangle(brush, x * 16, y * 16, 16, 16);
                        }
                    }
                }
            }

            return tilemapimage;
        }

        private int GetEditorMode()
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
                        if (i != 0)
                        {
                            PALdata[5][i] = Color.FromArgb(tempPAL[i * 3], tempPAL[(i * 3) + 1], tempPAL[(i * 3) + 2]);
                        }
                        else
                        {
                            PALdata[5][i] = Color.FromArgb(0, tempPAL[i * 3], tempPAL[(i * 3) + 1], tempPAL[(i * 3) + 2]);
                        }
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
                else if (_node.Name == "animation")
                {
                    List<EventPlazaAnimationFrame> _animation = new List<EventPlazaAnimationFrame>();

                    if (_node.HasChildNodes)
                    {
                        foreach (XmlNode _frameNode in _node.ChildNodes)
                        {
                            if (_frameNode.Name == "frame")
                            {
                                if (!(new Regex(@"^[0-9]+$").Match(_frameNode.Attributes["duration"].Value).Success))
                                {
                                    //Duration Check
                                    MessageBox.Show("Duration is invalid in Event Plaza Expansion Animation " + _frameNode.BaseURI + " (" + _frameNode.Attributes["duration"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                //Tile Data
                                List<EventPlazaAnimationTile> _tiles = new List<EventPlazaAnimationTile>();
                                if (_frameNode.HasChildNodes)
                                {
                                    foreach (XmlNode _tileNode in _frameNode.ChildNodes)
                                    {
                                        if (!(new Regex(@"^[0-9]+$").Match(_tileNode.Attributes["x"].Value).Success))
                                        {
                                            //X Position Check
                                            MessageBox.Show("X Position is invalid in Event Plaza Expansion Animation Tile " + _tileNode.BaseURI + " (" + _tileNode.Attributes["x"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        if (!(new Regex(@"^[0-9]+$").Match(_tileNode.Attributes["y"].Value).Success))
                                        {
                                            //Y Position Check
                                            MessageBox.Show("Y Position is invalid in Event Plaza Expansion Animation Tile " + _tileNode.BaseURI + " (" + _tileNode.Attributes["y"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        if (!(new Regex(@"^[0-9a-fA-F]{4}$").Match(_tileNode.Attributes["bg1tile"].Value).Success))
                                        {
                                            //BG1 Tile Check
                                            MessageBox.Show("BG1 Tile is invalid in Event Plaza Expansion Animation Tile " + _tileNode.BaseURI + " (" + _tileNode.Attributes["bg1tile"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        if (!(new Regex(@"^[0-9a-fA-F]{4}$").Match(_tileNode.Attributes["bg2tile"].Value).Success))
                                        {
                                            //BG2 Tile Check
                                            MessageBox.Show("BG2 Tile is invalid in Event Plaza Expansion Animation Tile " + _tileNode.BaseURI + " (" + _tileNode.Attributes["bg2tile"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        ushort _x = Convert.ToUInt16(_tileNode.Attributes["x"].Value);
                                        ushort _y = Convert.ToUInt16(_tileNode.Attributes["y"].Value);
                                        ushort _bg1tile;
                                        ushort.TryParse(_tileNode.Attributes["bg1tile"].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _bg1tile);
                                        ushort _bg2tile;
                                        ushort.TryParse(_tileNode.Attributes["bg2tile"].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _bg2tile);

                                        _tiles.Add(new EventPlazaAnimationTile(_x, _y, _bg1tile, _bg2tile));
                                    }
                                }

                                EventPlazaAnimationFrame _frame = new EventPlazaAnimationFrame(_tiles, Convert.ToUInt16(_frameNode.Attributes["duration"].Value));
                                _animation.Add(_frame);
                            }
                        }
                    }
                    frames = _animation;
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
                else if (_node.Name == "collisions")
                {
                    if (!(new Regex(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$").Match(_node.InnerText).Success))
                    {
                        //Check tile data
                        MessageBox.Show("Collision Data is invalid in Event Plaza Expansion " + _node.BaseURI, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    byte[] temp = Convert.FromBase64String(_node.InnerText);
                    temp.CopyTo(COLdata, 0);
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

            //Animation (Frames -> Tiles)
            xmlWriter.WriteStartElement("animation");
            foreach (EventPlazaAnimationFrame dataframe in GetFrameData())
            {
                xmlWriter.WriteStartElement("frame");
                xmlWriter.WriteAttributeString("duration", dataframe.duration.ToString());

                foreach (EventPlazaAnimationTile datatile in dataframe.tiles)
                {
                    xmlWriter.WriteStartElement("tile");
                    xmlWriter.WriteAttributeString("x", datatile.x.ToString());
                    xmlWriter.WriteAttributeString("y", datatile.y.ToString());
                    xmlWriter.WriteAttributeString("bg1tile", datatile.bg1_tile.ToString("X4"));
                    xmlWriter.WriteAttributeString("bg2tile", datatile.bg2_tile.ToString("X4"));
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
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

            //Custom Collisions
            xmlWriter.WriteStartElement("collisions");

            xmlWriter.WriteString(Convert.ToBase64String(GetCustomCollisions()));

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
            using (EventPlazaEasyGraphicsImport gfximport = new EventPlazaEasyGraphicsImport())
            {
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
        }

        private void buttonCollisionEditor_Click(object sender, EventArgs e)
        {
            Bitmap customTileSetImage = new Bitmap(16 * 8, 16 * 6);

            using (Graphics g = Graphics.FromImage(customTileSetImage))
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        g.DrawImageUnscaled(DrawCell(0x3D0 + x + y * 8), 16 * x, 16 * y);
                    }
                }
            }

            using (EventPlazaCollisionEditor coleditor = new EventPlazaCollisionEditor(customTileSetImage, COLdata))
            {
                if (coleditor.ShowDialog() == DialogResult.OK)
                {
                    COLdata = coleditor.GetCollisions();
                }
            }
        }

        private void buttonTilesetEditor_Click(object sender, EventArgs e)
        {
            using (EventPlazaTilesetEditor tilesetEditor = new EventPlazaTilesetEditor(TILEdata, TILESETdata, PALdata))
            {
                if (tilesetEditor.ShowDialog() == DialogResult.OK)
                {
                    TILESETdata = tilesetEditor.GetNewTileSet();
                    InitTilesetImage();
                    UpdateTilesetImage();
                    UpdateTilemapImage();
                }
            }
        }

        private void buttonAnimationEditor_Click(object sender, EventArgs e)
        {
            using (EventPlazaAnimationEditor animEditor = new EventPlazaAnimationEditor(tileSetImage, DrawTileMap(true), frames))
            {
                if (animEditor.ShowDialog() == DialogResult.OK)
                {
                    frames.Clear();
                    frames.AddRange(animEditor.GetFrameData());
                }
            }
        }

        private void resetBuildingMapDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the building data?", "Reset Building Map Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tileMap = new ushort[4 * 7];
                doorLocations = new bool[4 * 7];
                UpdateTilemapImage();
            }
        }

        private void resetTileDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the tile graphics data?", "Reset Tile Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InitTileData();
                InitTilesetImage();
                UpdateTilesetImage();
                UpdateTilemapImage();
            }
        }

        private void resetTilesetDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the tileset data?", "Reset Tileset Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InitTilesetData();
                InitTilesetImage();
                UpdateTilesetImage();
                UpdateTilemapImage();
            }
        }

        private void resetCollisionDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the collision data?", "Reset Collision Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                COLdata = new byte[0x30];
                UpdateTilemapImage();
            }
        }

        private void resetAnimationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the animation data?", "Reset Animation Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frames.Clear();
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

        public byte[] GetCustomCollisions()
        {
            return COLdata;
        }

        public List<EventPlazaAnimationFrame> GetFrameData()
        {
            return frames;
        }
    }
}
