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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /* MENU */

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newServerRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewChn.Nodes.Clear();

            foreach (TreeNode _node in Program.NewRepository())
            {
                _node.ContextMenuStrip = contextMenuStripChannelMenu;
                treeViewChn.Nodes.Add(_node);
            }
        }

        private void openServerRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();

            FolderSelect.FolderSelectDialog fsd = new FolderSelect.FolderSelectDialog();
            fsd.Title = "Select Export BS-X File Folder...";
            if (fsd.ShowDialog())
            {
                //No \ at the end
                Program.ExportBSX(fsd.FileName);
            }
        }

        /* OTHER EVENTS */

        private void treeViewChn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            byte _typeCheck = Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag].type;

            if (_typeCheck == 2)
            {
                //Set stuff
                comboBoxAudio.SelectedIndex = (Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag] as TownStatus).apu_setup ^ 3;
                comboBoxRadio.SelectedIndex = (Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag] as TownStatus).radio_setup;
                comboBoxMonth.SelectedIndex = (Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag] as TownStatus).fountain;
                comboBoxSeason.SelectedIndex = (Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag] as TownStatus).season;

                //0-58
                for (int i = 0; i <= 58; i++)
                    checkedListBoxNPCs.SetItemChecked(i, (Program.ChannelMap[(int)treeViewChn.SelectedNode.Tag] as TownStatus).npc_flags[i]);

                //Make it appear
                groupBoxTown.Visible = true;
            }
            else
            {
                groupBoxTown.Visible = false;
            }
        }

        /* OTHER FUNCTIONS */

        private void SaveAll()
        {
            SaveTownStatus();
        }

        private void SaveTownStatus()
        {
            bool[] _npc_flags = new bool[64];

            for (int i = 0; i <= 58; i++)
                _npc_flags[i] = checkedListBoxNPCs.GetItemChecked(i);

            Program.SaveTownStatus((int)treeViewChn.SelectedNode.Tag, (byte)(comboBoxAudio.SelectedIndex ^ 3),
                (byte)comboBoxRadio.SelectedIndex, _npc_flags, (byte)comboBoxMonth.SelectedIndex, (byte)comboBoxSeason.SelectedIndex);
        }
    }
}
