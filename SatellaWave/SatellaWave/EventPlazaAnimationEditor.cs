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
    public partial class EventPlazaAnimationEditor : Form
    {
        static List<EventPlazaAnimationFrame> frames;
        static int currentFrame;
        static Bitmap tileSet;
        static Bitmap tileMap;
        static ushort selectedTile;

        public EventPlazaAnimationEditor(Bitmap _tileSet, Bitmap _tileMap, List<EventPlazaAnimationFrame> _frames)
        {
            InitializeComponent();
            frames = new List<EventPlazaAnimationFrame>();
            frames.AddRange(_frames);

            if (frames.Count == 0)
            {
                frames.Add(new EventPlazaAnimationFrame());
            }

            tileSet = _tileSet;
            tileMap = _tileMap;
            selectedTile = 0;
            currentFrame = 0;
            hScrollBar1.Maximum = frames.Count - 1;
            hScrollBar1.Value = currentFrame;

            UpdateTilesetImage();
            UpdateTilemapImage();
            UpdateFrameLabel();
        }

        private void UpdateFrameLabel()
        {
            labelFrame.Text = "Frame " + (currentFrame + 1).ToString() + "/" + frames.Count.ToString();
            numericUpDownDuration.Value = frames[currentFrame].duration;
        }

        private void UpdateTilesetImage()
        {
            Bitmap updateTileSet = new Bitmap(tileSet);

            using (Graphics g = Graphics.FromImage(updateTileSet))
            {
                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.FillRectangle(brush, (selectedTile % 8) * 16, (selectedTile / 8) * 16, 16, 16);
            }

            pictureBoxTileset.Image = updateTileSet;
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

        private Bitmap DrawTileMap()
        {
            Bitmap tilemapimage = new Bitmap(32 * 4, 32 * 7);

            using (Graphics g = Graphics.FromImage(tilemapimage))
            {
                g.DrawImageUnscaled(tileMap, 0, 0);

                //Draw previous to current frames
                for (int i = 0; i < currentFrame; i++)
                {
                    foreach (EventPlazaAnimationTile tile in frames[i].tiles)
                    {
                        for (int yt = 0; yt < 16; yt++)
                        {
                            for (int xt = 0; xt < 16; xt++)
                            {
                                if (tile.bg1_tile < 0x400 && (tile.x >= 6 && tile.x <= 9) && (tile.y >= 0xD && tile.x <= 0x13))
                                {
                                    tilemapimage.SetPixel(((tile.x - 0x6) * 16) + xt, ((tile.y - 0xD) * 16) + yt, tileSet.GetPixel(((tile.bg1_tile % 8) * 16) + xt, ((tile.bg1_tile / 8) * 16) + yt));
                                }
                            }
                        }
                    }
                }

                //Make it transparent
                for (int yt = 0; yt < 16 * 7; yt++)
                {
                    for (int xt = 0; xt < 16 * 4; xt++)
                    {
                        Color temp = Color.FromArgb(100, tilemapimage.GetPixel(xt, yt).R, tilemapimage.GetPixel(xt, yt).G, tilemapimage.GetPixel(xt, yt).B);
                        tilemapimage.SetPixel(xt, yt, temp);
                    }
                }

                foreach (EventPlazaAnimationTile tile in frames[currentFrame].tiles)
                {
                    for (int yt = 0; yt < 16; yt++)
                    {
                        for (int xt = 0; xt < 16; xt++)
                        {
                            if (tile.bg1_tile < 0x400 && (tile.x >= 6 && tile.x <= 9) && (tile.y >= 0xD && tile.x <= 0x13))
                            {
                                tilemapimage.SetPixel(((tile.x - 0x6) * 16) + xt, ((tile.y - 0xD) * 16) + yt, tileSet.GetPixel(((tile.bg1_tile % 8) * 16) + xt, ((tile.bg1_tile / 8) * 16) + yt));
                            }
                        }
                    }

                    if (checkBoxHighlight.Checked)
                    {
                        Brush brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
                        g.FillRectangle(brush, (tile.x - 0x6) * 16, (tile.y - 0xD) * 16, 16, 16);
                    }
                }
            }

            return tilemapimage;
        }

        private void pictureBoxTileset_Click(object sender, EventArgs e)
        {
            Point coordinates = ((MouseEventArgs)e).Location;
            selectedTile = (ushort)((coordinates.X / 16) + ((coordinates.Y / 16) * 8));
            UpdateTilesetImage();
        }

        private void pictureBoxBuilding_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button != MouseButtons.None
                && ((MouseEventArgs)e).Location.X >= 0 && ((MouseEventArgs)e).Location.X < (32 * 4)
                && ((MouseEventArgs)e).Location.Y >= 0 && ((MouseEventArgs)e).Location.Y < (32 * 7))
            {
                if (frames[currentFrame].tiles.Count > 0)
                {
                    for (int i = 0; i < frames[currentFrame].tiles.Count; i++)
                    {
                        if ((frames[currentFrame].tiles[i].x - 0x6) == (((MouseEventArgs)e).Location.X / 32)
                            && (frames[currentFrame].tiles[i].y - 0xD) == (((MouseEventArgs)e).Location.Y / 32))
                        {
                            if (((MouseEventArgs)e).Button == MouseButtons.Left)
                            {
                                frames[currentFrame].tiles[i].bg1_tile = selectedTile;
                            }
                            else if (((MouseEventArgs)e).Button == MouseButtons.Right)
                            {
                                frames[currentFrame].tiles.RemoveAt(i);
                            }
                            UpdateTilemapImage();
                            return;
                        }
                    }
                }

                if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    EventPlazaAnimationTile data = new EventPlazaAnimationTile((ushort)((((MouseEventArgs)e).Location.X / 32) + 0x6), (ushort)((((MouseEventArgs)e).Location.Y / 32) + 0xD), selectedTile);
                    frames[currentFrame].tiles.Add(data);

                    UpdateTilemapImage();
                }
            }
        }

        private void checkBoxHighlight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTilemapImage();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            currentFrame = hScrollBar1.Value;
            UpdateFrameLabel();
            UpdateTilemapImage();
        }

        private void numericUpDownDuration_ValueChanged(object sender, EventArgs e)
        {
            frames[currentFrame].duration = (ushort)numericUpDownDuration.Value;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            frames.Add(new EventPlazaAnimationFrame());
            currentFrame = frames.Count - 1;
            hScrollBar1.Maximum = frames.Count - 1;
            hScrollBar1.Value = currentFrame;
            UpdateFrameLabel();
            UpdateTilemapImage();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            frames.Insert(currentFrame, new EventPlazaAnimationFrame());
            hScrollBar1.Maximum = frames.Count - 1;
            hScrollBar1.Value = currentFrame;
            UpdateFrameLabel();
            UpdateTilemapImage();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (frames.Count > 1)
            {
                frames.RemoveAt(currentFrame);
            }
            else
            {
                frames[currentFrame].tiles.Clear();
                frames[currentFrame].duration = 1;
            }

            if (currentFrame >= frames.Count)
            {
                currentFrame = frames.Count - 1;
            }
            hScrollBar1.Maximum = frames.Count - 1;
            hScrollBar1.Value = currentFrame;
            UpdateFrameLabel();
            UpdateTilemapImage();
        }

        private void buttonRemoveLast_Click(object sender, EventArgs e)
        {
            if (frames.Count > 1)
            {
                frames.RemoveAt(frames.Count - 1);
            }
            else
            {
                frames[frames.Count - 1].tiles.Clear();
                frames[frames.Count - 1].duration = 1;
            }

            if (currentFrame >= frames.Count)
            {
                currentFrame = frames.Count - 1;
            }
            hScrollBar1.Maximum = frames.Count - 1;
            hScrollBar1.Value = currentFrame;
            UpdateFrameLabel();
            UpdateTilemapImage();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the animation? You will not be able to restore it.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frames.Clear();
                frames.Add(new EventPlazaAnimationFrame());

                currentFrame = 0;

                hScrollBar1.Maximum = frames.Count - 1;
                hScrollBar1.Value = currentFrame;

                UpdateTilemapImage();
                UpdateFrameLabel();
            }
        }

        public List<EventPlazaAnimationFrame> GetFrameData()
        {
            return frames;
        }

        private void EventPlazaAnimationEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //If there's only one frame, and there's no animation data, then clear it.
            if (frames.Count == 1)
            {
                if (frames[0].tiles.Count == 0)
                {
                    frames.Clear();
                }
            }
        }
    }
}
