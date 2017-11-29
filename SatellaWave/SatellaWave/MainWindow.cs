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
        private TreeNode previousSelectedNode;

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
            Program.NewRepository();
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

        private void addChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddChannel())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.AddChannel(dialog.returnChannelType);
                }
            }
        }

        /* OTHER EVENTS */

        private void treeViewChn_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewChn.SelectedNode != null)
            {
                byte _typeCheck = (treeViewChn.SelectedNode.Tag as Channel).type;

                if (_typeCheck == (byte)ChannelType.Message)
                {
                    SaveMessage(treeViewChn.SelectedNode);
                }
                else if (_typeCheck == (byte)ChannelType.Town)
                {
                    SaveTownStatus(treeViewChn.SelectedNode);
                }
            }
        }

        private void treeViewChn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            byte _typeCheck = (treeViewChn.SelectedNode.Tag as Channel).type;

            groupBoxTown.Visible = false;
            groupBoxMessage.Visible = false;

            if (_typeCheck == (byte)ChannelType.Message)
            {
                textBoxMessage.Text = (treeViewChn.SelectedNode.Tag as MessageChannel).message;

                groupBoxMessage.Visible = true;
            }
            else if (_typeCheck == (byte)ChannelType.Town)
            {
                //Set stuff
                comboBoxAudio.SelectedIndex = (treeViewChn.SelectedNode.Tag as TownStatus).apu_setup ^ 3;
                comboBoxRadio.SelectedIndex = (treeViewChn.SelectedNode.Tag as TownStatus).radio_setup;
                comboBoxMonth.SelectedIndex = (treeViewChn.SelectedNode.Tag as TownStatus).fountain;
                comboBoxSeason.SelectedIndex = (treeViewChn.SelectedNode.Tag as TownStatus).season;

                //0-58
                for (int i = 0; i <= 58; i++)
                    checkedListBoxNPCs.SetItemChecked(i, (treeViewChn.SelectedNode.Tag as TownStatus).npc_flags[i]);

                //Make it appear
                groupBoxTown.Visible = true;
            }
        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {
            labelMessageCharLeft.Text = (99 - textBoxMessage.Text.Length).ToString() + " characters left";
        }

        /* OTHER FUNCTIONS */

        private void SaveAll()
        {
            foreach (TreeNode _node in treeViewChn.Nodes)
            {
                if ((_node.Tag as Channel).type == (byte)ChannelType.Message)
                    SaveMessage(_node);
                else if ((_node.Tag as Channel).type == (byte)ChannelType.Town)
                    SaveTownStatus(_node);
            }
        }

        private void SaveMessage(TreeNode _node)
        {
            (_node.Tag as MessageChannel).message = textBoxMessage.Text;
        }

        private void SaveTownStatus(TreeNode _node)
        {
            (_node.Tag as TownStatus).apu_setup = (byte)(comboBoxAudio.SelectedIndex ^ 3);
            (_node.Tag as TownStatus).radio_setup = (byte)comboBoxRadio.SelectedIndex;
            (_node.Tag as TownStatus).fountain = (byte)comboBoxMonth.SelectedIndex;
            (_node.Tag as TownStatus).season = (byte)comboBoxSeason.SelectedIndex;

            //0-58
            for (int i = 0; i <= 58; i++)
                (_node.Tag as TownStatus).npc_flags[i] = checkedListBoxNPCs.GetItemChecked(i);
        }
    }
}
