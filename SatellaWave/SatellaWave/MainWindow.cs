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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Text = "SatellaWave " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void setTitle(string fileName)
        {
            this.Text = "SatellaWave " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (fileName != "")
            {
                this.Text += " [" + fileName + "]";
            }
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
            OpenFileDialog fileloadDialog = new OpenFileDialog();
            fileloadDialog.Filter = "XML File (*.xml)|*.xml|All files|*.*";
            fileloadDialog.Title = "Load Repository XML File...";
            fileloadDialog.Multiselect = false;

            if (fileloadDialog.ShowDialog() == DialogResult.OK)
            {
                Program.LoadBSXRepository(fileloadDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLast();

            if (Program.lastSavedXMLFile != "")
            {
                Program.SaveBSXRepository();
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML File (*.xml)|*.xml|All files|*.*";
                saveFileDialog.Title = "Save Repository XML File...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Program.SaveBSXRepository(saveFileDialog.FileName);
                }
            }
        }

        private void saveAsRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLast();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML File (*.xml)|*.xml|All files|*.*";
            saveFileDialog.Title = "Save Repository XML File...";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.SaveBSXRepository(saveFileDialog.FileName);
            }
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

        private void ButtonFileItem_FileBrowse_Click(object sender, EventArgs e)
        {
            //Browse File for Download
            OpenFileDialog fileloadDialog = new OpenFileDialog();
            fileloadDialog.Filter = "Broadcast Satellite SNES Files (*.bs)|*.bs|All files|*.*";
            fileloadDialog.Title = "Load Downloadable File...";
            fileloadDialog.Multiselect = false;

            if (fileloadDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFileItem_FilePath.Text = fileloadDialog.FileName;
                Stream _getFileData = fileloadDialog.OpenFile();
                if (_getFileData.Length <= 0x80000)
                {
                    comboBoxFileItem_Destination.SelectedIndex = 3;
                }
                else
                {
                    comboBoxFileItem_Destination.SelectedIndex = 2;
                }

                _getFileData.Close();
            }
        }

        private void buttonPatchFileBrowse_Click(object sender, EventArgs e)
        {
            //Browse File for Download
            OpenFileDialog fileloadDialog = new OpenFileDialog();
            fileloadDialog.Filter = "BS-X Compatible Patch Files (*.bin)|*.bin|All files|*.*";
            fileloadDialog.Title = "Load BS-X Patch File...";
            fileloadDialog.Multiselect = false;

            if (fileloadDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPatchFilePath.Text = fileloadDialog.FileName;
            }
        }

        /* OTHER FUNCTIONS */

        private void UpdateWindow()
        {
            groupBoxTown.Visible = false;
            groupBoxMessage.Visible = false;
            groupBoxDirectory.Visible = false;
            groupBoxFolder.Visible = false;
            groupBoxFileItem.Visible = false;
            groupBoxPatch.Visible = false;
            groupBoxEventPlaza.Visible = false;

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

                if ((treeViewChn.SelectedNode.Tag as DownloadFile).isItem == true)
                {
                    groupBoxFileItem_Item.Visible = true;
                }
                else
                {
                    groupBoxFileItem_File.Visible = true;
                }

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
            }
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Patch))
            {
                groupBoxPatch.Visible = true;
                comboBoxPatchType.SelectedIndex = (treeViewChn.SelectedNode.Tag as Patch).patchType;
                textBoxPatchFilePath.Text = (treeViewChn.SelectedNode.Tag as Patch).filePath;
            }
            else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(EventPlaza))
            {
                groupBoxEventPlaza.Visible = true;
                textBoxEventPlazaName.Text = (treeViewChn.SelectedNode.Tag as EventPlaza).name;
            }
        }

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
                else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Patch))
                    SavePatch(treeViewChn.SelectedNode);
                else if (treeViewChn.SelectedNode.Tag.GetType() == typeof(EventPlaza))
                    SaveEventPlaza(treeViewChn.SelectedNode);
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
                string MessageString = "This will change all the files created into the other type. Are you sure?";
                if (comboBoxFolderPurpose.SelectedIndex == 1)
                    MessageString = "This will change all the files created into the other type.\nIt will also remove all include files in each file.\nYou will not be able to recover them.\nAre you sure?";

                if (MessageBox.Show(MessageString, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    (_node.Tag as Folder).purpose = comboBoxFolderPurpose.SelectedIndex;
                    foreach (TreeNode __node in _node.Nodes)
                    {
                        (__node.Tag as DownloadFile).isItem = (_node.Tag as Folder).purpose == 1;
                        __node.Nodes.Clear();
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
            (_node.Tag as DownloadFile).name = textBoxFileItem_Name.Text;
            (_node.Tag as DownloadFile).filedesc = textBoxFileItemDesc.Text;

            (_node.Tag as DownloadFile).usage = textBoxFileItemUsage.Text;
            (_node.Tag as DownloadFile).price = (ulong)numericUpDownFileItemPrice.Value;
            (_node.Tag as DownloadFile).oneuse = checkBoxFileItemOneUse.Checked;

            (_node.Tag as DownloadFile).filepath = textBoxFileItem_FilePath.Text;
            (_node.Tag as DownloadFile).alsoAtHome = checkBoxFileItem_AtHome.Checked;
            (_node.Tag as DownloadFile).streamed = checkBoxFileItem_Streaming.Checked;
            (_node.Tag as DownloadFile).autostart = (byte)comboBoxFileItem_AutoStart.SelectedIndex;
            (_node.Tag as DownloadFile).dest = (byte)comboBoxFileItem_Destination.SelectedIndex;

            (_node.Tag as DownloadFile).month = (byte)dateTimePickerFileItem_Date.Value.Month;
            (_node.Tag as DownloadFile).day = (byte)dateTimePickerFileItem_Date.Value.Day;

            (_node.Tag as DownloadFile).hour_start = (byte)dateTimePickerFileItem_TimeStart.Value.Hour;
            (_node.Tag as DownloadFile).min_start = (byte)dateTimePickerFileItem_TimeStart.Value.Minute;

            (_node.Tag as DownloadFile).hour_end = (byte)dateTimePickerFileItem_TimeEnd.Value.Hour;
            (_node.Tag as DownloadFile).min_end = (byte)dateTimePickerFileItem_TimeEnd.Value.Minute;

            _node.Text = (_node.Tag as DownloadFile).name;
        }

        private void SavePatch(TreeNode _node)
        {
            (_node.Tag as Patch).patchType = comboBoxPatchType.SelectedIndex;

            if ((_node.Tag as Patch).patchType == 0)
            {
                (_node.Tag as Patch).SetNone();
            }
            else
            {
                (_node.Tag as Patch).SetFilePath(textBoxPatchFilePath.Text);
            }
        }

        private void SaveEventPlaza(TreeNode _node)
        {
            (_node.Tag as EventPlaza).name = textBoxEventPlazaName.Text;
        }

        private string UpdateNodeName(TreeNode _node)
        {
            if (_node.Tag.GetType() == typeof(MessageChannel))
                return (_node.Tag as MessageChannel).name + " (" + (_node.Tag as MessageChannel).GetChannelNumberString() + ")";
            else if (_node.Tag.GetType() == typeof(TownStatus))
                return (_node.Tag as TownStatus).name + " (" + (_node.Tag as TownStatus).GetChannelNumberString() + ")";
            else if (_node.Tag.GetType() == typeof(Directory))
                return (_node.Tag as Directory).name + " (" + (_node.Tag as Directory).GetChannelNumberString() + ")";
            else if (_node.Tag.GetType() == typeof(Patch))
                return (_node.Tag as Patch).name + " (" + (_node.Tag as Patch).GetChannelNumberString() + ")";
            else if (_node.Tag.GetType() == typeof(DownloadFile))
                return (_node.Tag as DownloadFile).name;

            return _node.Text;
        }

        /* OTHER EVENTS */

        private void treeViewChn_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SaveLast();
        }

        private void treeViewChn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateWindow();
        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {
            labelMessageCharLeft.Text = (99 - Program.ConvertToBSXStringBytes(textBoxMessage.Text).Length).ToString() + " characters left";
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
                groupBoxFileItem.Visible = false;
                groupBoxEventPlaza.Visible = false;
            }
        }

        private void toolStripMenuItemChannel_Edit_Click(object sender, EventArgs e)
        {
            if (treeViewChn.SelectedNode.Tag.GetType() == typeof(Folder))
                return;

            EditChannel editform = new EditChannel((treeViewChn.SelectedNode.Tag as Channel).name, (treeViewChn.SelectedNode.Tag as Channel).GetChannelNumberString(), (treeViewChn.SelectedNode.Tag as Channel).lci, (treeViewChn.SelectedNode.Tag as Channel).timeout);

            if (editform.ShowDialog() == DialogResult.OK)
            {
                if (Program.CheckUsedChannel(editform._ret_channel, treeViewChn.SelectedNode))
                {
                    if (MessageBox.Show("Software Channel " + editform._ret_channel + " already exists in another channel.\nThis will create a conflict. Are you sure you want to save it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (Program.CheckUsedLCI(editform._ret_lci, treeViewChn.SelectedNode))
                {
                    if (MessageBox.Show("Logical Channel " + editform._ret_lci.ToString("X4") + " already exists in another channel.\nThis will create a conflict. Are you sure you want to save it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }

                (treeViewChn.SelectedNode.Tag as Channel).name = editform._ret_name;
                (treeViewChn.SelectedNode.Tag as Channel).service_broadcast = editform._ret_service;
                (treeViewChn.SelectedNode.Tag as Channel).program_number = editform._ret_program;
                (treeViewChn.SelectedNode.Tag as Channel).lci = editform._ret_lci;
                (treeViewChn.SelectedNode.Tag as Channel).timeout = editform._ret_timeout;

                treeViewChn.SelectedNode.Text = UpdateNodeName(treeViewChn.SelectedNode);

                UpdateWindow();
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

        private void createEventPlaza(object sender, EventArgs e)
        {
            SaveLast();
            Program.AddExpansionPlaza(treeViewChn.SelectedNode);
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

        private void contextMenuStripFileMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treeViewChn.SelectedNode.Tag.GetType() == typeof(DownloadFile))
            {
                toolStripMenuItemAddIncludeFile.Enabled = !(treeViewChn.SelectedNode.Tag as DownloadFile).isItem;
            }
        }

        private void comboBoxFolderMugshot_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox_FolderMugshot.Image = ResourceAccess.mugshotImageList[comboBoxFolderMugshot.SelectedIndex];
        }

        private void checkedListBoxNPCs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Prevent user from selecting more than 5 NPCs/Events (BS-X would not make them appear)
            int checkAmount = 0;
            for (int i = 0; i < 47; i++)
            {
                if (checkedListBoxNPCs.GetItemCheckState(i) == CheckState.Checked)
                    checkAmount++;
            }

            for (int i = 56; i < 59; i++)
            {
                if (checkedListBoxNPCs.GetItemCheckState(i) == CheckState.Checked)
                    checkAmount++;
            }

            if ((checkAmount >= 5) && (e.Index < 47 | e.Index >= 56) && (e.NewValue == CheckState.Checked))
            {
                MessageBox.Show("You cannot check more than 5 NPCs/Events by the exception of the ones ending with (!).", "NPC Limitation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void textBoxFolderName_TextChanged(object sender, EventArgs e)
        {
            //Limit Characters dynamically
            textBoxFolderName.MaxLength = 20;
            byte[] stringbytes = Encoding.Convert(Encoding.GetEncoding(932), Encoding.UTF8, Program.ConvertToBSXStringBytes(textBoxFolderName.Text).Take<byte>(20).ToArray<byte>());

            if (Program.ConvertToBSXStringBytes(textBoxFolderName.Text).Length >= 20)
            {
                textBoxFolderName.Text = Encoding.UTF8.GetString(stringbytes);
                textBoxFolderName.MaxLength = Encoding.UTF8.GetString(stringbytes).Length;
            }
        }

        private void textBoxFileItem_Name_TextChanged(object sender, EventArgs e)
        {
            //Limit Characters dynamically
            textBoxFileItem_Name.MaxLength = 20;
            byte[] stringbytes = Encoding.Convert(Encoding.GetEncoding(932), Encoding.UTF8, Program.ConvertToBSXStringBytes(textBoxFileItem_Name.Text).Take<byte>(20).ToArray<byte>());

            if (Program.ConvertToBSXStringBytes(textBoxFileItem_Name.Text).Length >= 20)
            {
                textBoxFileItem_Name.Text = Encoding.UTF8.GetString(stringbytes);
                textBoxFileItem_Name.MaxLength = Encoding.UTF8.GetString(stringbytes).Length;
            }
        }

        private void textBoxEventPlazaName_TextChanged(object sender, EventArgs e)
        {
            //Limit Characters dynamically
            textBoxEventPlazaName.MaxLength = 16;
            byte[] stringbytes = Encoding.Convert(Encoding.GetEncoding(932), Encoding.UTF8, Program.ConvertToBSXStringBytes(textBoxEventPlazaName.Text).Take<byte>(16).ToArray<byte>());

            if (Program.ConvertToBSXStringBytes(textBoxEventPlazaName.Text).Length >= 16)
            {
                textBoxEventPlazaName.Text = Encoding.UTF8.GetString(stringbytes);
                textBoxEventPlazaName.MaxLength = Encoding.UTF8.GetString(stringbytes).Length;
            }
        }

        private void textBoxFileItemDesc_TextChanged(object sender, EventArgs e)
        {
            //Limit Characters dynamically
            textBoxFileItemDesc.MaxLength = 254;
            byte[] stringbytes = Encoding.Convert(Encoding.GetEncoding(932), Encoding.UTF8, Program.ConvertToBSXStringBytes(textBoxFileItemDesc.Text).Take<byte>(254).ToArray<byte>());

            if (Program.ConvertToBSXStringBytes(textBoxFileItemDesc.Text).Length >= 254)
            {
                textBoxFileItemDesc.Text = Encoding.UTF8.GetString(stringbytes);
                textBoxFileItemDesc.MaxLength = Encoding.UTF8.GetString(stringbytes).Length;
            }
        }

        private void textBoxFolderMessage_TextChanged(object sender, EventArgs e)
        {
            //Limit Characters dynamically
            textBoxFolderMessage.MaxLength = 254;
            byte[] stringbytes = Encoding.Convert(Encoding.GetEncoding(932), Encoding.UTF8, Program.ConvertToBSXStringBytes(textBoxFolderMessage.Text).Take<byte>(254).ToArray<byte>());

            if (Program.ConvertToBSXStringBytes(textBoxFolderMessage.Text).Length >= 254)
            {
                textBoxFolderMessage.Text = Encoding.UTF8.GetString(stringbytes);
                textBoxFolderMessage.MaxLength = Encoding.UTF8.GetString(stringbytes).Length;
            }
        }

        private void comboBoxPatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatchType.SelectedIndex == 0)
            {
                textBoxPatchFilePath.Enabled = false;
                buttonPatchFileBrowse.Enabled = false;
            }
            else
            {
                textBoxPatchFilePath.Enabled = true;
                buttonPatchFileBrowse.Enabled = true;
            }
        }

        private void buttonEventPlazaEditor_Click(object sender, EventArgs e)
        {
            EventPlazaEditor editor = new EventPlazaEditor((treeViewChn.SelectedNode.Tag as EventPlaza).tilemap, (treeViewChn.SelectedNode.Tag as EventPlaza).doors);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                (treeViewChn.SelectedNode.Tag as EventPlaza).tilemap = editor.GetTileMap();
                (treeViewChn.SelectedNode.Tag as EventPlaza).doors = editor.GetDoorLocations();
            }
        }
    }
}
