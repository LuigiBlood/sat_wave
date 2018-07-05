namespace SatellaWave
{
    partial class EventPlazaEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxBuilding = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDoorMode = new System.Windows.Forms.RadioButton();
            this.radioButtonAnimationMode = new System.Windows.Forms.RadioButton();
            this.radioButtonBuildingMode = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuilding)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxTileset);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 325);
            this.panel1.TabIndex = 1;
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTileset.Image = global::SatellaWave.Properties.Resources.Tileset;
            this.pictureBoxTileset.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(128, 2048);
            this.pictureBoxTileset.TabIndex = 0;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Click += new System.EventHandler(this.pictureBoxTileset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxBuilding);
            this.groupBox1.Location = new System.Drawing.Point(152, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 254);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Building";
            // 
            // pictureBoxBuilding
            // 
            this.pictureBoxBuilding.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBuilding.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxBuilding.Name = "pictureBoxBuilding";
            this.pictureBoxBuilding.Size = new System.Drawing.Size(128, 224);
            this.pictureBoxBuilding.TabIndex = 0;
            this.pictureBoxBuilding.TabStop = false;
            this.pictureBoxBuilding.Click += new System.EventHandler(this.pictureBoxBuilding_Click);
            this.pictureBoxBuilding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBuilding_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonDoorMode);
            this.groupBox2.Controls.Add(this.radioButtonAnimationMode);
            this.groupBox2.Controls.Add(this.radioButtonBuildingMode);
            this.groupBox2.Location = new System.Drawing.Point(152, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modes";
            // 
            // radioButtonDoorMode
            // 
            this.radioButtonDoorMode.AutoSize = true;
            this.radioButtonDoorMode.Location = new System.Drawing.Point(169, 16);
            this.radioButtonDoorMode.Name = "radioButtonDoorMode";
            this.radioButtonDoorMode.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDoorMode.TabIndex = 2;
            this.radioButtonDoorMode.TabStop = true;
            this.radioButtonDoorMode.Text = "Door";
            this.radioButtonDoorMode.UseVisualStyleBackColor = true;
            this.radioButtonDoorMode.CheckedChanged += new System.EventHandler(this.radioButtonDoorMode_CheckedChanged);
            // 
            // radioButtonAnimationMode
            // 
            this.radioButtonAnimationMode.AutoSize = true;
            this.radioButtonAnimationMode.Enabled = false;
            this.radioButtonAnimationMode.Location = new System.Drawing.Point(83, 16);
            this.radioButtonAnimationMode.Name = "radioButtonAnimationMode";
            this.radioButtonAnimationMode.Size = new System.Drawing.Size(71, 17);
            this.radioButtonAnimationMode.TabIndex = 1;
            this.radioButtonAnimationMode.TabStop = true;
            this.radioButtonAnimationMode.Text = "Animation";
            this.radioButtonAnimationMode.UseVisualStyleBackColor = true;
            this.radioButtonAnimationMode.CheckedChanged += new System.EventHandler(this.radioButtonAnimationMode_CheckedChanged);
            // 
            // radioButtonBuildingMode
            // 
            this.radioButtonBuildingMode.AutoSize = true;
            this.radioButtonBuildingMode.Checked = true;
            this.radioButtonBuildingMode.Location = new System.Drawing.Point(6, 16);
            this.radioButtonBuildingMode.Name = "radioButtonBuildingMode";
            this.radioButtonBuildingMode.Size = new System.Drawing.Size(62, 17);
            this.radioButtonBuildingMode.TabIndex = 0;
            this.radioButtonBuildingMode.TabStop = true;
            this.radioButtonBuildingMode.Text = "Building";
            this.radioButtonBuildingMode.UseVisualStyleBackColor = true;
            this.radioButtonBuildingMode.CheckedChanged += new System.EventHandler(this.radioButtonBuildingMode_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(401, 75);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // EventPlazaEditor
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 354);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EventPlazaEditor";
            this.ShowIcon = false;
            this.Text = "Event Plaza Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuilding)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxTileset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxBuilding;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonDoorMode;
        private System.Windows.Forms.RadioButton radioButtonAnimationMode;
        private System.Windows.Forms.RadioButton radioButtonBuildingMode;
        private System.Windows.Forms.Button buttonSave;
    }
}