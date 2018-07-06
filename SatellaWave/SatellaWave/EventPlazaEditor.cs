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

        public EventPlazaEditor()
        {
            InitializeComponent();
            selectedTile = 0;
            tileMap = new ushort[7 * 4];
            doorLocations = new bool[7 * 4];

            UpdateTilesetImage();
            UpdateTilemapImage();
        }

        public EventPlazaEditor(ushort[] _tilemap, bool[] _doors)
        {
            InitializeComponent();
            selectedTile = 0;
            tileMap = _tilemap;
            doorLocations = _doors;

            UpdateTilesetImage();
            UpdateTilemapImage();
        }

        public void UpdateTilesetImage()
        {
            Bitmap tileset = new Bitmap(ResourceAccess.tilesetBSX);
            using (Graphics g = Graphics.FromImage(tileset))
            {
                g.DrawRectangle(Pens.Red, (selectedTile % 8) * 16, (selectedTile / 8) * 16, 15, 15);
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
                        g.DrawImageUnscaled(GetTileImage(tileMap[x + (y * 4)]), x * 16, y * 16);

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

        public Bitmap GetTileImage(int id)
        {
            Bitmap tile = new Bitmap(16, 16);
            Bitmap tileset = ResourceAccess.tilesetBSX;

            id = id & 0x3FF;

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    tile.SetPixel(x, y, tileset.GetPixel((id % 8) * 16 + x, ((id / 8) * 16) + y));
                }
            }

            return tile;
        }

        public ushort[] GetTileMap()
        {
            return tileMap;
        }

        public bool[] GetDoorLocations()
        {
            return doorLocations;
        }

        private void pictureBoxTileset_Click(object sender, EventArgs e)
        {
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTile = (ushort)((coordinates.X / 16) + ((coordinates.Y / 16) * 8));
            UpdateTilesetImage();
        }

        private void pictureBoxBuilding_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left
                && e.Location.X >= 0 && e.Location.X < (32 * 4)
                && e.Location.Y >= 0 && e.Location.Y < (32 * 7))
            {
                if (GetEditorMode() == 0)
                {
                    ushort[] tileMapTemp = tileMap;
                    tileMapTemp[(e.Location.X / 32) + ((e.Location.Y / 32) * 4)] = selectedTile;
                    if (tileMapTemp.Equals(tileMap))
                    {
                        tileMap = tileMapTemp;
                        UpdateTilemapImage();
                    }
                }
            }
        }

        private void pictureBoxBuilding_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left
                && e.Location.X >= 0 && e.Location.X < (32 * 4)
                && e.Location.Y >= 0 && e.Location.Y < (32 * 7))
            {
                if (GetEditorMode() == 0)
                {
                    ushort[] tileMapTemp = tileMap;
                    tileMapTemp[(e.Location.X / 32) + ((e.Location.Y / 32) * 4)] = selectedTile;
                    if (tileMapTemp.Equals(tileMap))
                    {
                        tileMap = tileMapTemp;
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

        private void pictureBoxBuilding_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void radioButtonBuildingMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBuildingMode.Checked)
            {
                UpdateTilemapImage();
            }
        }

        private void radioButtonAnimationMode_CheckedChanged(object sender, EventArgs e)
        {

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
                if (_node.Name == "map")
                {
                    if (!(new Regex(@"^[0-9a-fA-F]{112}$").Match(_node.InnerText).Success))
                    {
                        //Check tilemap data
                        MessageBox.Show("Map Data is invalid in Event Plaza Expansion " + _node.BaseURI + " (" + _node.Attributes["name"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else if (_node.Name == "door")
                {
                    if (!(new Regex(@"^[0-1]{28}$").Match(_node.InnerText).Success))
                    {
                        //Check Door data
                        MessageBox.Show("Door Location data in invalid in Event Plaza Expansion " + _node.BaseURI + " (" + _node.Attributes["name"].Value + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //Tilemap
            xmlWriter.WriteStartElement("map");
            foreach (ushort datamap in GetTileMap())
            {
                xmlWriter.WriteString(datamap.ToString("X4"));
            }
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
    }
}
