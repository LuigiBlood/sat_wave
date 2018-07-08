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
    public partial class EventPlazaCollisionEditor : Form
    {
        static Bitmap tileset;
        static byte[] collision;
        static ushort selectedTile;

        public EventPlazaCollisionEditor(Bitmap _set, byte[] _col)
        {
            InitializeComponent();

            tileset = _set;

            collision = new byte[_col.Length];
            _col.CopyTo(collision, 0);

            selectedTile = 0;

            UpdateTilesetImage();
            UpdateTileImage();

            checkBoxDiagonal.Checked = (collision[selectedTile] & 0x10) != 0;
            checkBoxPriority.Checked = (collision[selectedTile] & 0x20) != 0;
        }

        private void UpdateTilesetImage()
        {
            Bitmap update = new Bitmap(tileset);
            using (Graphics g = Graphics.FromImage(update))
            {
                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, (selectedTile % 8) * 16, (selectedTile / 8) * 16, 16, 16);
            }

            pictureBoxTileset.Image = update;
        }

        private void UpdateTileImage()
        {
            Bitmap tile = new Bitmap(16, 16);

            //Copy Tile Data
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    tile.SetPixel(x, y, tileset.GetPixel(((selectedTile % 8) * 16) + x, ((selectedTile / 8) * 16) + y));
                }
            }

            using (Graphics g = Graphics.FromImage(tile))
            {
                
                if ((collision[selectedTile] & 0x10) != 0)
                {
                    //Diagonal Collision
                    Brush brush = new SolidBrush(Color.FromArgb(170, 255, 255, 100));
                    g.DrawLine(new Pen(brush), 11, 0, 4, 15);
                }
                else
                {
                    Brush brush = new SolidBrush(Color.FromArgb(170, 255, 0, 100));
                    if ((collision[selectedTile] & 0x01) != 0)
                    {
                        //Top Left
                        g.FillRectangle(brush, 0, 0, 8, 8);
                    }
                    if ((collision[selectedTile] & 0x02) != 0)
                    {
                        //Bottom Left
                        g.FillRectangle(brush, 0, 8, 8, 8);
                    }
                    if ((collision[selectedTile] & 0x04) != 0)
                    {
                        //Top Right
                        g.FillRectangle(brush, 8, 0, 8, 8);
                    }
                    if ((collision[selectedTile] & 0x08) != 0)
                    {
                        //Bottom Right
                        g.FillRectangle(brush, 8, 8, 8, 8);
                    }
                }
            }

            Bitmap tileUpdate = new Bitmap(64, 64);

            using (Graphics g = Graphics.FromImage(tileUpdate))
            {
                g.ScaleTransform(4f, 4f);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(tile, 0f, 0f);

                if ((collision[selectedTile] & 0x10) == 0)
                {
                    //Diagonal Collision
                    g.ScaleTransform(0.25f, 0.25f);
                    g.DrawLine(new Pen(Brushes.White), 32, 0, 32, 64);
                    g.DrawLine(new Pen(Brushes.White), 0, 32, 64, 32);
                }
            }

            pictureBoxTile.Image = tileUpdate;
        }

        private void pictureBoxTileset_Click(object sender, EventArgs e)
        {
            //Select Tile
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTile = (ushort)((coordinates.X / 16) + ((coordinates.Y / 16) * 8));

            checkBoxDiagonal.Checked = (collision[selectedTile] & 0x10) != 0;
            checkBoxPriority.Checked = (collision[selectedTile] & 0x20) != 0;

            UpdateTilesetImage();
            UpdateTileImage();
        }

        private void pictureBoxTile_Click(object sender, EventArgs e)
        {
            //Set Collision
            Point coordinates = ((MouseEventArgs)e).Location;
            int coltemp = ((coordinates.Y / 32) + ((coordinates.X / 32) * 2));
            collision[selectedTile] ^= (byte)(1 << coltemp);

            UpdateTileImage();
        }

        private void checkBoxDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            collision[selectedTile] &= 0x2F;
            collision[selectedTile] |= (byte)(Convert.ToByte(checkBoxDiagonal.Checked) * 0x10);
            UpdateTileImage();
        }

        private void checkBoxPriority_CheckedChanged(object sender, EventArgs e)
        {
            collision[selectedTile] &= 0x1F;
            collision[selectedTile] |= (byte)(Convert.ToByte(checkBoxPriority.Checked) * 0x20);
        }

        public byte[] GetCollisions()
        {
            for (int i = 0; i < collision.Length; i++)
            {
                if ((collision[i] & 0x10) != 0)
                    collision[i] &= 0x30;
            }

            return collision;
        }
    }
}
