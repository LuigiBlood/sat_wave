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
            SaveLast();

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

        /* OTHER FUNCTIONS */

        private void SaveLast()
        {
            if (treeViewChn.SelectedNode != null)
            {
                if (treeViewChn.SelectedNode.Tag.GetType() == typeof(MessageChannel))
                    SaveMessage(treeViewChn.SelectedNode);
                else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(TownStatus))
                    SaveTownStatus(treeViewChn.SelectedNode);
                else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Folder))
                    SaveFolder(treeViewChn.SelectedNode);
                else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(DownloadFile))
                    SaveFile(treeViewChn.SelectedNode);
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

        private void SaveFolder(TreeNode _node)
        {
            (_node.Tag as Folder).name = textBoxFolderName.Text;
            (_node.Tag as Folder).message = textBoxFolderMessage.Text;

            if (_node.Nodes.Count <= 0)
            {
                (_node.Tag as Folder).purpose = comboBoxFolderPurpose.SelectedIndex;
            }
            else if ((_node.Tag as Folder).purpose != comboBoxFolderPurpose.SelectedIndex)
            {
                if (MessageBox.Show("This will change all the files created into the other type. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    (_node.Tag as Folder).purpose = comboBoxFolderPurpose.SelectedIndex;
                    foreach (TreeNode __node in _node.Nodes)
                    {
                        (__node.Tag as DownloadFile).isItem = (_node.Tag as Folder).purpose == 1;
                    }
                }
                else
                {
                    comboBoxFolderPurpose.SelectedIndex = (_node.Tag as Folder).purpose;
                }
            }

            (_node.Tag as Folder).type = comboBoxFolderType.SelectedIndex;
            (_node.Tag as Folder).id = comboBoxFolderID.SelectedIndex;
            (_node.Tag as Folder).mugshot = comboBoxFolderMugshot.SelectedIndex;

            _node.Text = (_node.Tag as Folder).name;
        }

        private void SaveFile(TreeNode _node)
        {

        }

        /* OTHER EVENTS */

        private void treeViewChn_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SaveLast();
        }

        private void treeViewChn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            groupBoxTown.Visible = false;
            groupBoxMessage.Visible = false;
            groupBoxDirectory.Visible = false;
            groupBoxFolder.Visible = false;
            groupBoxFileItem.Visible = false;

            if (treeViewChn.SelectedNode.Tag.GetType() == typeof(MessageChannel))
            {
                textBoxMessage.Text = (treeViewChn.SelectedNode.Tag as MessageChannel).message;

                groupBoxMessage.Visible = true;
            }
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(TownStatus))
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
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Directory))
            {
                groupBoxDirectory.Visible = true;
            }
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Folder))
            {
                groupBoxFolder.Visible = true;

                textBoxFolderName.Text = (treeViewChn.SelectedNode.Tag as Folder).name;
                textBoxFolderMessage.Text = (treeViewChn.SelectedNode.Tag as Folder).message;

                comboBoxFolderPurpose.SelectedIndex = (treeViewChn.SelectedNode.Tag as Folder).purpose;
                comboBoxFolderType.SelectedIndex = (treeViewChn.SelectedNode.Tag as Folder).type;

                comboBoxFolderID.SelectedIndex = (treeViewChn.SelectedNode.Tag as Folder).id;

                comboBoxFolderMugshot.SelectedIndex = (treeViewChn.SelectedNode.Tag as Folder).mugshot;
            }
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(DownloadFile))
            {
                groupBoxFileItem.Visible = true;

                groupBoxFileItem_Item.Visible = false;
                groupBoxFileItem_File.Visible = false;

                textBoxFileItem_Name.Text = (treeViewChn.SelectedNode.Tag as DownloadFile).name;
                textBoxFileItemDesc.Text = (treeViewChn.SelectedNode.Tag as DownloadFile).filedesc;

                textBoxFileItemUsage.Text = (treeViewChn.SelectedNode.Tag as DownloadFile).usage;
                numericUpDownFileItemPrice.Value = (treeViewChn.SelectedNode.Tag as DownloadFile).price;
                checkBoxFileItemOneUse.Checked = (treeViewChn.SelectedNode.Tag as DownloadFile).oneuse;

                textBoxFileItem_FilePath.Text = (treeViewChn.SelectedNode.Tag as DownloadFile).filepath;
                checkBoxFileItem_AtHome.Checked = (treeViewChn.SelectedNode.Tag as DownloadFile).alsoAtHome;
                checkBoxFileItem_Streaming.Checked = (treeViewChn.SelectedNode.Tag as DownloadFile).streamed;
                comboBoxFileItem_AutoStart.SelectedIndex = (treeViewChn.SelectedNode.Tag as DownloadFile).autostart;
                comboBoxFileItem_Destination.SelectedIndex = (treeViewChn.SelectedNode.Tag as DownloadFile).dest;

                dateTimePickerFileItem_Date.Value = new DateTime(1995, (treeViewChn.SelectedNode.Tag as DownloadFile).month, (treeViewChn.SelectedNode.Tag as DownloadFile).day);
                dateTimePickerFileItem_TimeStart.Value = new DateTime(1995, 04, 23, (treeViewChn.SelectedNode.Tag as DownloadFile).hour_start, (treeViewChn.SelectedNode.Tag as DownloadFile).min_start, 0);
                dateTimePickerFileItem_TimeEnd.Value = new DateTime(1995, 04, 23, (treeViewChn.SelectedNode.Tag as DownloadFile).hour_end, (treeViewChn.SelectedNode.Tag as DownloadFile).min_end, 0);

                if ((treeViewChn.SelectedNode.Tag as DownloadFile).isItem == true)
                {
                    groupBoxFileItem_Item.Visible = true;
                }
                else
                {
                    groupBoxFileItem_File.Visible = true;
                }
            }
        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {
            labelMessageCharLeft.Text = (99 - textBoxMessage.Text.Length).ToString() + " characters left";
        }

        private void toolStripMenuItemChannel_Delete_Click(object sender, EventArgs e)
        {
            treeViewChn.SelectedNode.Remove();

            //If there's no nodes, don't make the menus appear
            if (treeViewChn.Nodes.Count <= 0)
            {
                groupBoxTown.Visible = false;
                groupBoxMessage.Visible = false;
                groupBoxDirectory.Visible = false;
                groupBoxFolder.Visible = false;
            }
        }

        private void treeViewChn_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Allow right click to select nodes
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeViewChn.SelectedNode = e.Node;
            }
        }

        private void createFolder(object sender, EventArgs e)
        {
            SaveLast();
            Program.AddFolder(treeViewChn.SelectedNode);
        }

        private void createFile(object sender, EventArgs e)
        {
            SaveLast();
            Program.AddFile(treeViewChn.SelectedNode);
        }

        private void comboBoxFolderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFolderID.Items.Clear();
            if (comboBoxFolderType.SelectedIndex == 0)
            {
                labelFolderID.Text = "Building:";
                comboBoxFolderID.Items.AddRange(Program.buildingList);
            }
            else
            {
                labelFolderID.Text = "Person:";
                comboBoxFolderID.Items.AddRange(Program.peopleList);
            }

            comboBoxFolderID.SelectedIndex = 0;
        }
    }
}
