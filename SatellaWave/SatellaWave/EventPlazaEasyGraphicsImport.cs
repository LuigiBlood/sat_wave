using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatellaWave
{
    public partial class EventPlazaEasyGraphicsImport : Form
    {
        Color[] PALdata;
        byte[] TILEdata;
        ushort[] TILESETdata;

        public bool isPaletteDataImported;
        public bool isTileDataImported;
        public bool isTilesetDataImported;

        public EventPlazaEasyGraphicsImport()
        {
            InitializeComponent();
            isPaletteDataImported = false;
            isTileDataImported = false;
            isTilesetDataImported = false;
        }

        private void buttonBrowsePAL_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Open Binary Palette File...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPAL.Text = ofd.FileName;
            }
        }

        private void buttonBrowseGFX_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Open Binary Tile Graphics File...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxGFX.Text = ofd.FileName;
            }
        }

        private void buttonBrowseMAP_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Open Binary Tile Map File...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxMAP.Text = ofd.FileName;
            }
        }

        private void LoadPaletteData()
        {
            if (!File.Exists(textBoxPAL.Text))
            {
                isPaletteDataImported = false;
                return;
            }

            Stream file = new FileStream(textBoxPAL.Text, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(file);

            PALdata = new Color[16];
            for (int j = 0; j < PALdata.Length; j++)
            {
                ushort colordata = binaryReader.ReadUInt16();
                int r = (int)((float)((colordata & 0x1F) / 31.0f) * 255);
                int g = (int)((float)(((colordata >> 5) & 0x1F) / 31.0f) * 255);
                int b = (int)((float)(((colordata >> 10) & 0x1F) / 31.0f) * 255);

                if (j != 0)
                    PALdata[j] = Color.FromArgb(r, g, b);
                else
                    PALdata[j] = Color.FromArgb(0, 0, 0, 0);
            }

            binaryReader.Close();
            file.Close();

            isPaletteDataImported = true;
        }

        private void LoadTileData()
        {
            if (!File.Exists(textBoxGFX.Text))
            {
                isTileDataImported = false;
                return;
            }

            Stream file = new FileStream(textBoxGFX.Text, FileMode.Open);

            TILEdata = new byte[file.Length];
            file.Read(TILEdata, 0, (int)file.Length);

            file.Close();
            isTileDataImported = true;
        }

        private void LoadTileSetData()
        {
            if (!File.Exists(textBoxMAP.Text))
            {
                isTilesetDataImported = false;
                return;
            }

            Stream file = new FileStream(textBoxMAP.Text, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(file);
            List<ushort> MAPtemp = new List<ushort>();

            //Load TileSet in order
            for (int i = 0; i < (4 * 7); i++)
            {
                file.Seek(((i / 4) * 32) + (((i % 4) * 4)), SeekOrigin.Begin);
                MAPtemp.Add(binaryReader.ReadUInt16());
                file.Seek(((i / 4) * 32) + (((i % 4) * 4) + 16), SeekOrigin.Begin);
                MAPtemp.Add(binaryReader.ReadUInt16());
                file.Seek(((i / 4) * 32) + (((i % 4) * 4) + 2), SeekOrigin.Begin);
                MAPtemp.Add(binaryReader.ReadUInt16());
                file.Seek(((i / 4) * 32) + (((i % 4) * 4) + 16 + 2), SeekOrigin.Begin);
                MAPtemp.Add(binaryReader.ReadUInt16());
            }

            //Adapt data for BS-X VRAM
            for (int i = 0; i < MAPtemp.Count; i++)
            {
                MAPtemp[i] = (ushort)((MAPtemp[i] + 0x390) | 0x3400);
                //First Custom Tile ID is 0x390, select Custom Palette (Palette 5), BG Priority
            }

            TILESETdata = MAPtemp.ToArray();

            file.Close();

            isTilesetDataImported = true;
        }

        private void EventPlazaEasyGraphicsImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                LoadPaletteData();
                LoadTileData();
                LoadTileSetData();
            }
        }

        public Color[] GetCustomPalette()
        {
            return PALdata;
        }

        public byte[] GetCustomTiles()
        {
            return TILEdata;
        }

        public ushort[] GetCustomTileSet()
        {
            return TILESETdata;
        }

        public ushort[] GetCustomTileMap()
        {
            ushort[] temp = new ushort[4 * 7];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = (ushort)(0x03D0 + i);
            }
            return temp;
        }
    }
}
