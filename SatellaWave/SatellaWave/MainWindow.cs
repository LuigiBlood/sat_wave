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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newServerRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.NewRepository();
            treeViewChn.Nodes.Clear();

            treeViewChn.Nodes.Add(Program.ChannelMap[0].name + " (" + Program.ChannelMap[0].GetChannelNumberString() + ")").Tag = 0;
        }

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
    }
}
