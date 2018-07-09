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
    public partial class EventPlazaTilesetEditor : Form
    {
        private static byte[] tile8;
        private static ushort[] tileSet;
        private static Color[][] palette;

        private static int selectedTileSet;
        private static int selectedTile;

        public EventPlazaTilesetEditor(byte[] _tile8, ushort[] _tileSet, Color[][] _pal)
        {
            InitializeComponent();

            tile8 = _tile8;
            palette = _pal;

            tileSet = new ushort[_tileSet.Length];
            _tileSet.CopyTo(tileSet, 0);

            selectedTileSet = 0;
            selectedTile = 0;

            UpdateTileSetImage();
            UpdateTileSetup();
            UpdateTile8Image();
        }

        private void UpdateTileSetImage()
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

                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, (selectedTileSet % 8) * 16, (selectedTileSet / 8) * 16, 16, 16);
            }

            pictureBoxTilesetSelect.Image = customTileSetImage;
        }

        private void UpdateTileSetup()
        {
            Bitmap customTileSetupImage = new Bitmap(64, 64);

            using (Graphics g = Graphics.FromImage(customTileSetupImage))
            {
                g.ScaleTransform(4f, 4f);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.DrawImage(DrawCell(0x3D0 + selectedTileSet), 0, 0);

                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, ((selectedTile >> 1) & 1) * 8, ((selectedTile >> 0) & 1) * 8, 8, 8);
            }

            pictureBoxTileEditor.Image = customTileSetupImage;

            numericUpDownPAL.Value = (tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x1C00) >> 10;
            checkBoxFlipX.Checked = ((tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x4000) != 0);
            checkBoxFlipY.Checked = ((tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x8000) != 0);
        }

        private void UpdateTile8Image()
        {
            Bitmap customTileImage = new Bitmap(16 * 8, 16 * 128);

            using (Graphics g = Graphics.FromImage(customTileImage))
            {
                g.ScaleTransform(2f, 2f);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                for (int y = 0; y < 128; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        g.DrawImage(DrawTile(x + y * 8, ((tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x1C00) >> 10)), 8 * x, 8 * y);
                    }
                }

                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, ((tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x03FF) % 8) * 8, ((tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] & 0x03FF) / 8) * 8, 8, 8);
            }

            pictureBoxTileData.Image = customTileImage;
        }

        private static Bitmap DrawCell(int id)
        {
            Bitmap celltemp = new Bitmap(16, 16);

            id &= 0x3FF;

            using (Graphics g = Graphics.FromImage(celltemp))
            {
                g.DrawImageUnscaled(DrawTile(tileSet[id * 4 + 0] & 0x03FF, (tileSet[id * 4 + 0] & 0x1C00) >> 10, (tileSet[id * 4 + 0] & 0x4000) != 0, (tileSet[id * 4 + 0] & 0x8000) != 0), 0, 0);
                g.DrawImageUnscaled(DrawTile(tileSet[id * 4 + 1] & 0x03FF, (tileSet[id * 4 + 1] & 0x1C00) >> 10, (tileSet[id * 4 + 1] & 0x4000) != 0, (tileSet[id * 4 + 1] & 0x8000) != 0), 0, 8);
                g.DrawImageUnscaled(DrawTile(tileSet[id * 4 + 2] & 0x03FF, (tileSet[id * 4 + 2] & 0x1C00) >> 10, (tileSet[id * 4 + 2] & 0x4000) != 0, (tileSet[id * 4 + 2] & 0x8000) != 0), 8, 0);
                g.DrawImageUnscaled(DrawTile(tileSet[id * 4 + 3] & 0x03FF, (tileSet[id * 4 + 3] & 0x1C00) >> 10, (tileSet[id * 4 + 3] & 0x4000) != 0, (tileSet[id * 4 + 3] & 0x8000) != 0), 8, 8);
            }

            return celltemp;
        }

        private static Bitmap DrawTile(int id, int pal, bool xflip = false, bool yflip = false)
        {
            //4BPP SNES
            Bitmap tiletemp = new Bitmap(8, 8);

            id = id & 0x3FF;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int colorID = (((tile8[(id * 32) + (y * 2)] & (1 << (7 - x))) << x) >> 7)
                        | (((tile8[(id * 32) + (y * 2) + 1] & (1 << (7 - x))) << x) >> 6)
                        | (((tile8[(id * 32) + (y * 2) + 16] & (1 << (7 - x))) << x) >> 5)
                        | (((tile8[(id * 32) + (y * 2) + 16 + 1] & (1 << (7 - x))) << x) >> 4);

                    int xt = x;
                    if (xflip) xt = 7 - x;

                    int yt = y;
                    if (yflip) yt = 7 - y;

                    tiletemp.SetPixel(xt, yt, palette[pal][colorID]);
                }
            }

            return tiletemp;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxTileEditor_Click(object sender, EventArgs e)
        {
            //Set Collision
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTile = ((coordinates.Y / 32) + ((coordinates.X / 32) * 2));

            UpdateTileSetup();
            UpdateTile8Image();
        }

        private void pictureBoxTilesetSelect_Click(object sender, EventArgs e)
        {
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTileSet = ((coordinates.X / 16) + ((coordinates.Y / 16) * 8));

            UpdateTileSetImage();
            UpdateTileSetup();
            UpdateTile8Image();
        }

        private void numericUpDownPAL_ValueChanged(object sender, EventArgs e)
        {
            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] &= 0xE3FF;
            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] |= (ushort)(Convert.ToUInt16(numericUpDownPAL.Value) << 10);

            UpdateTileSetImage();
            UpdateTileSetup();
            UpdateTile8Image();
        }

        private void checkBoxFlipX_CheckedChanged(object sender, EventArgs e)
        {
            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] &= 0xBFFF;
            if (checkBoxFlipX.Checked)
            {
                tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] |= 0x4000;
            }

            UpdateTileSetImage();
            UpdateTileSetup();
        }

        private void checkBoxFlipY_CheckedChanged(object sender, EventArgs e)
        {
            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] &= 0x7FFF;
            if (checkBoxFlipY.Checked)
            {
                tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] |= 0x8000;
            }

            UpdateTileSetImage();
            UpdateTileSetup();
        }

        private void pictureBoxTileData_Click(object sender, EventArgs e)
        {
            Point coordinates = ((MouseEventArgs)e).Location;
            int selectedTileData = ((coordinates.X / 16) + ((coordinates.Y / 16) * 8));

            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] &= 0xFC00;
            tileSet[((0x3D0 + selectedTileSet) * 4) + selectedTile] += (ushort)(selectedTileData & 0x3FF);

            UpdateTileSetImage();
            UpdateTileSetup();
            UpdateTile8Image();
        }

        public ushort[] GetNewTileSet()
        {
            return tileSet;
        }
    }
}
