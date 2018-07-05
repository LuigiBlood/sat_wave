using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatellaWave
{
    public partial class EventPlazaEditor : Form
    {
        static ushort selectedTile = 0;
        public static ushort[] tileMap;
        public static bool[] doorLocations;

        public EventPlazaEditor()
        {
            InitializeComponent();

            tileMap = new ushort[7 * 4];
            doorLocations = new bool[7 * 4];

            UpdateTilesetImage();
            UpdateTilemapImage();
        }

        public EventPlazaEditor(ushort[] _tilemap, bool[] _doors)
        {
            InitializeComponent();

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
                g.DrawImage(tilemapimagetemp, 0, 0);
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
            if (e.Button == MouseButtons.Left)
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
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
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
    }
}
