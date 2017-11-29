namespace SatellaWave
{
    partial class AddChannel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxChannelType = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxChannelType
            // 
            this.comboBoxChannelType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChannelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannelType.FormattingEnabled = true;
            this.comboBoxChannelType.Items.AddRange(new object[] {
            "BS-X - Welcome Message (1.1.0.4)",
            "BS-X - Town Status (1.1.0.5)",
            "BS-X - Directory (1.1.0.6)",
            "BS-X - Time Channel (1.1.0.8)",
            "Game - Time Channel (1.2.0.48)",
            "Itoi Shigesato no Bass Tsuri No. 1 - Contest 1 (1.2.130.0)",
            "Itoi Shigesato no Bass Tsuri No. 1 - Contest 2 (1.2.130.16)",
            "Itoi Shigesato no Bass Tsuri No. 1 - Contest 3 (1.2.130.32)",
            "Itoi Shigesato no Bass Tsuri No. 1 - Contest 4 (1.2.130.48)"});
            this.comboBoxChannelType.Location = new System.Drawing.Point(12, 28);
            this.comboBoxChannelType.Name = "comboBoxChannelType";
            this.comboBoxChannelType.Size = new System.Drawing.Size(346, 21);
            this.comboBoxChannelType.TabIndex = 0;
            this.comboBoxChannelType.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannelType_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(202, 68);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(283, 68);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a new channel type:";
            // 
            // AddChannel
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(370, 103);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxChannelType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChannel";
            this.ShowInTaskbar = false;
            this.Text = "Add Channel...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChannelType;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
    }
}