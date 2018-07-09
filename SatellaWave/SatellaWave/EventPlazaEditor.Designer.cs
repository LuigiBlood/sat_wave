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
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxBuilding = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDoorMode = new System.Windows.Forms.RadioButton();
            this.radioButtonBuildingMode = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCustomGFXEditor = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCollisionEditor = new System.Windows.Forms.Button();
            this.buttonSuperFamiconv = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuilding)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveQuitToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // saveQuitToolStripMenuItem
            // 
            this.saveQuitToolStripMenuItem.Name = "saveQuitToolStripMenuItem";
            this.saveQuitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveQuitToolStripMenuItem.Text = "Save && Quit";
            this.saveQuitToolStripMenuItem.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxTileset);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 311);
            this.panel1.TabIndex = 1;
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackColor = System.Drawing.Color.DimGray;
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
            this.groupBox1.Text = "Building Editor";
            // 
            // pictureBoxBuilding
            // 
            this.pictureBoxBuilding.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxBuilding.Location = new System.Drawing.Point(5, 19);
            this.pictureBoxBuilding.Name = "pictureBoxBuilding";
            this.pictureBoxBuilding.Size = new System.Drawing.Size(128, 224);
            this.pictureBoxBuilding.TabIndex = 0;
            this.pictureBoxBuilding.TabStop = false;
            this.pictureBoxBuilding.Click += new System.EventHandler(this.pictureBoxBuilding_Click);
            this.pictureBoxBuilding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBuilding_MouseEdit);
            this.pictureBoxBuilding.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBuilding_MouseEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonDoorMode);
            this.groupBox2.Controls.Add(this.radioButtonBuildingMode);
            this.groupBox2.Location = new System.Drawing.Point(152, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor Mode";
            // 
            // radioButtonDoorMode
            // 
            this.radioButtonDoorMode.AutoSize = true;
            this.radioButtonDoorMode.Location = new System.Drawing.Point(91, 16);
            this.radioButtonDoorMode.Name = "radioButtonDoorMode";
            this.radioButtonDoorMode.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDoorMode.TabIndex = 2;
            this.radioButtonDoorMode.TabStop = true;
            this.radioButtonDoorMode.Text = "Door";
            this.radioButtonDoorMode.UseVisualStyleBackColor = true;
            this.radioButtonDoorMode.CheckedChanged += new System.EventHandler(this.radioButtonDoorMode_CheckedChanged);
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
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(6, 225);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save & Quit";
            this.buttonSave.UseMnemonic = false;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCustomGFXEditor
            // 
            this.buttonCustomGFXEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustomGFXEditor.Enabled = false;
            this.buttonCustomGFXEditor.Location = new System.Drawing.Point(6, 183);
            this.buttonCustomGFXEditor.Name = "buttonCustomGFXEditor";
            this.buttonCustomGFXEditor.Size = new System.Drawing.Size(103, 36);
            this.buttonCustomGFXEditor.TabIndex = 5;
            this.buttonCustomGFXEditor.Text = "Advanced Graphics Editor";
            this.buttonCustomGFXEditor.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.Location = new System.Drawing.Point(6, 19);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(103, 23);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.Text = "Import...";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(6, 48);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(103, 23);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export...";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonCollisionEditor);
            this.groupBox3.Controls.Add(this.buttonSuperFamiconv);
            this.groupBox3.Controls.Add(this.buttonImport);
            this.groupBox3.Controls.Add(this.buttonExport);
            this.groupBox3.Controls.Add(this.buttonSave);
            this.groupBox3.Controls.Add(this.buttonCustomGFXEditor);
            this.groupBox3.Location = new System.Drawing.Point(305, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 254);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Menu";
            // 
            // buttonCollisionEditor
            // 
            this.buttonCollisionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCollisionEditor.Location = new System.Drawing.Point(6, 147);
            this.buttonCollisionEditor.Name = "buttonCollisionEditor";
            this.buttonCollisionEditor.Size = new System.Drawing.Size(103, 30);
            this.buttonCollisionEditor.TabIndex = 9;
            this.buttonCollisionEditor.Text = "Collision Editor";
            this.buttonCollisionEditor.UseVisualStyleBackColor = true;
            this.buttonCollisionEditor.Click += new System.EventHandler(this.buttonCollisionEditor_Click);
            // 
            // buttonSuperFamiconv
            // 
            this.buttonSuperFamiconv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSuperFamiconv.Location = new System.Drawing.Point(6, 91);
            this.buttonSuperFamiconv.Name = "buttonSuperFamiconv";
            this.buttonSuperFamiconv.Size = new System.Drawing.Size(103, 50);
            this.buttonSuperFamiconv.TabIndex = 8;
            this.buttonSuperFamiconv.Text = "Easy Import SuperFamiconv Graphics...";
            this.buttonSuperFamiconv.UseVisualStyleBackColor = true;
            this.buttonSuperFamiconv.Click += new System.EventHandler(this.buttonSuperFamiconv_Click);
            // 
            // EventPlazaEditor
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 340);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton radioButtonBuildingMode;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveQuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button buttonCustomGFXEditor;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSuperFamiconv;
        private System.Windows.Forms.Button buttonCollisionEditor;
    }
}