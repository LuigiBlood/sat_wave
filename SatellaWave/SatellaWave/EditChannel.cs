using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatellaWave
{
    public partial class EditChannel : Form
    {
        public string _ret_name;
        public string _ret_channel;
        public ushort _ret_service;
        public ushort _ret_program;
        public ushort _ret_lci;
        public ushort _ret_timeout;

        public EditChannel(string _name, string _broadcast, ushort _lci, ushort _timeout)
        {
            InitializeComponent();

            textBoxChannelName.Text = _name;
            textBoxChannelService.Text = _broadcast;
            textBoxChannelLCI.Text = _lci.ToString("X4");
            numericUpDownTimeout.Value = _timeout;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //Get Name
            _ret_name = textBoxChannelName.Text;

            //Check Software Channel integrity
            Regex regex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (!regex.Match(textBoxChannelService.Text).Success)
            {
                MessageBox.Show("This is not a correct Software Channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ret_channel = textBoxChannelService.Text;
            _ret_service = (ushort)((Convert.ToByte(textBoxChannelService.Text.Split('.')[0]) << 8) | Convert.ToByte(textBoxChannelService.Text.Split('.')[1]));
            _ret_program = (ushort)((Convert.ToByte(textBoxChannelService.Text.Split('.')[2]) << 8) | Convert.ToByte(textBoxChannelService.Text.Split('.')[3]));

            //Check LCI
            regex = new Regex(@"^[0-9a-fA-F]{4}$");
            if (!regex.Match(textBoxChannelLCI.Text).Success)
            {
                MessageBox.Show("This is not a correct Logical Channel (must be 4 hexadecimal digit number).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ushort.TryParse(textBoxChannelLCI.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _ret_lci);

            _ret_timeout = (ushort)numericUpDownTimeout.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
