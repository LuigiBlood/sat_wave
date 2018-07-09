namespace SatellaWave
{
    partial class EventPlazaEasyGraphicsImport
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPAL = new System.Windows.Forms.TextBox();
            this.buttonBrowsePAL = new System.Windows.Forms.Button();
            this.textBoxGFX = new System.Windows.Forms.TextBox();
            this.buttonBrowseGFX = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBrowseMAP = new System.Windows.Forms.Button();
            this.textBoxMAP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(208, 193);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(289, 193);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "16-color Palette:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "8x8 Tile Graphics Data:";
            // 
            // textBoxPAL
            // 
            this.textBoxPAL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPAL.Location = new System.Drawing.Point(15, 58);
            this.textBoxPAL.Name = "textBoxPAL";
            this.textBoxPAL.Size = new System.Drawing.Size(268, 20);
            this.textBoxPAL.TabIndex = 4;
            // 
            // buttonBrowsePAL
            // 
            this.buttonBrowsePAL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePAL.Location = new System.Drawing.Point(289, 56);
            this.buttonBrowsePAL.Name = "buttonBrowsePAL";
            this.buttonBrowsePAL.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePAL.TabIndex = 5;
            this.buttonBrowsePAL.Text = "Browse...";
            this.buttonBrowsePAL.UseVisualStyleBackColor = true;
            this.buttonBrowsePAL.Click += new System.EventHandler(this.buttonBrowsePAL_Click);
            // 
            // textBoxGFX
            // 
            this.textBoxGFX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGFX.Location = new System.Drawing.Point(15, 107);
            this.textBoxGFX.Name = "textBoxGFX";
            this.textBoxGFX.Size = new System.Drawing.Size(268, 20);
            this.textBoxGFX.TabIndex = 6;
            // 
            // buttonBrowseGFX
            // 
            this.buttonBrowseGFX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseGFX.Location = new System.Drawing.Point(289, 105);
            this.buttonBrowseGFX.Name = "buttonBrowseGFX";
            this.buttonBrowseGFX.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseGFX.TabIndex = 7;
            this.buttonBrowseGFX.Text = "Browse...";
            this.buttonBrowseGFX.UseVisualStyleBackColor = true;
            this.buttonBrowseGFX.Click += new System.EventHandler(this.buttonBrowseGFX_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "8x8 SuperFamiconv Building Tile Map (original picture must be 64x112):";
            // 
            // buttonBrowseMAP
            // 
            this.buttonBrowseMAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseMAP.Location = new System.Drawing.Point(289, 154);
            this.buttonBrowseMAP.Name = "buttonBrowseMAP";
            this.buttonBrowseMAP.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseMAP.TabIndex = 9;
            this.buttonBrowseMAP.Text = "Browse...";
            this.buttonBrowseMAP.UseVisualStyleBackColor = true;
            this.buttonBrowseMAP.Click += new System.EventHandler(this.buttonBrowseMAP_Click);
            // 
            // textBoxMAP
            // 
            this.textBoxMAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMAP.Location = new System.Drawing.Point(15, 156);
            this.textBoxMAP.Name = "textBoxMAP";
            this.textBoxMAP.Size = new System.Drawing.Size(268, 20);
            this.textBoxMAP.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "You can just import your palette / tiles\r\nand make your tileset manually.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EventPlazaEasyGraphicsImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 228);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMAP);
            this.Controls.Add(this.buttonBrowseMAP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBrowseGFX);
            this.Controls.Add(this.textBoxGFX);
            this.Controls.Add(this.buttonBrowsePAL);
            this.Controls.Add(this.textBoxPAL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EventPlazaEasyGraphicsImport";
            this.Text = "Easy Import SuperFamiconv Graphics...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EventPlazaEasyGraphicsImport_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPAL;
        private System.Windows.Forms.Button buttonBrowsePAL;
        private System.Windows.Forms.TextBox textBoxGFX;
        private System.Windows.Forms.Button buttonBrowseGFX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBrowseMAP;
        private System.Windows.Forms.TextBox textBoxMAP;
        private System.Windows.Forms.Label label4;
    }
}