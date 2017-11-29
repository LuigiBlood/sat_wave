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
    public partial class AddChannel : Form
    {
        public int returnChannelType { get; set; }

        public AddChannel()
        {
            InitializeComponent();
            comboBoxChannelType.SelectedIndex = 0;
            returnChannelType = comboBoxChannelType.SelectedIndex;
        }

        private void comboBoxChannelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnChannelType = comboBoxChannelType.SelectedIndex;
        }
    }
}
