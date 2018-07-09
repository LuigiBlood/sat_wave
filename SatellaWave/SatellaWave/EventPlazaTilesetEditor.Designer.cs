namespace SatellaWave
{
    partial class EventPlazaTilesetEditor
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
            this.pictureBoxTileData = new System.Windows.Forms.PictureBox();
            this.panelTiles = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTileEditor = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxFlipX = new System.Windows.Forms.CheckBox();
            this.checkBoxFlipY = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureBoxTilesetSelect = new System.Windows.Forms.PictureBox();
            this.numericUpDownPAL = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileData)).BeginInit();
            this.panelTiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileEditor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPAL)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxTileData
            // 
            this.pictureBoxTileData.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxTileData.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTileData.Name = "pictureBoxTileData";
            this.pictureBoxTileData.Size = new System.Drawing.Size(128, 2048);
            this.pictureBoxTileData.TabIndex = 0;
            this.pictureBoxTileData.TabStop = false;
            this.pictureBoxTileData.Click += new System.EventHandler(this.pictureBoxTileData_Click);
            // 
            // panelTiles
            // 
            this.panelTiles.AutoScroll = true;
            this.panelTiles.Controls.Add(this.pictureBoxTileData);
            this.panelTiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTiles.Location = new System.Drawing.Point(0, 0);
            this.panelTiles.Name = "panelTiles";
            this.panelTiles.Size = new System.Drawing.Size(145, 298);
            this.panelTiles.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxTileEditor);
            this.groupBox1.Location = new System.Drawing.Point(151, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(76, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Setup";
            // 
            // pictureBoxTileEditor
            // 
            this.pictureBoxTileEditor.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxTileEditor.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTileEditor.Name = "pictureBoxTileEditor";
            this.pictureBoxTileEditor.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxTileEditor.TabIndex = 0;
            this.pictureBoxTileEditor.TabStop = false;
            this.pictureBoxTileEditor.Click += new System.EventHandler(this.pictureBoxTileEditor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxTilesetSelect);
            this.groupBox2.Location = new System.Drawing.Point(151, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select 16x16 Tile";
            // 
            // checkBoxFlipX
            // 
            this.checkBoxFlipX.AutoSize = true;
            this.checkBoxFlipX.Location = new System.Drawing.Point(11, 45);
            this.checkBoxFlipX.Name = "checkBoxFlipX";
            this.checkBoxFlipX.Size = new System.Drawing.Size(52, 17);
            this.checkBoxFlipX.TabIndex = 1;
            this.checkBoxFlipX.Text = "Flip X";
            this.checkBoxFlipX.UseVisualStyleBackColor = true;
            this.checkBoxFlipX.CheckedChanged += new System.EventHandler(this.checkBoxFlipX_CheckedChanged);
            // 
            // checkBoxFlipY
            // 
            this.checkBoxFlipY.AutoSize = true;
            this.checkBoxFlipY.Location = new System.Drawing.Point(11, 68);
            this.checkBoxFlipY.Name = "checkBoxFlipY";
            this.checkBoxFlipY.Size = new System.Drawing.Size(52, 17);
            this.checkBoxFlipY.TabIndex = 2;
            this.checkBoxFlipY.Text = "Flip Y";
            this.checkBoxFlipY.UseVisualStyleBackColor = true;
            this.checkBoxFlipY.CheckedChanged += new System.EventHandler(this.checkBoxFlipY_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(249, 263);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(249, 234);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBoxTilesetSelect
            // 
            this.pictureBoxTilesetSelect.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxTilesetSelect.Location = new System.Drawing.Point(22, 16);
            this.pictureBoxTilesetSelect.Name = "pictureBoxTilesetSelect";
            this.pictureBoxTilesetSelect.Size = new System.Drawing.Size(128, 96);
            this.pictureBoxTilesetSelect.TabIndex = 0;
            this.pictureBoxTilesetSelect.TabStop = false;
            this.pictureBoxTilesetSelect.Click += new System.EventHandler(this.pictureBoxTilesetSelect_Click);
            // 
            // numericUpDownPAL
            // 
            this.numericUpDownPAL.Location = new System.Drawing.Point(53, 19);
            this.numericUpDownPAL.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownPAL.Name = "numericUpDownPAL";
            this.numericUpDownPAL.Size = new System.Drawing.Size(30, 20);
            this.numericUpDownPAL.TabIndex = 3;
            this.numericUpDownPAL.ValueChanged += new System.EventHandler(this.numericUpDownPAL_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Palette:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownPAL);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.checkBoxFlipX);
            this.groupBox3.Controls.Add(this.checkBoxFlipY);
            this.groupBox3.Location = new System.Drawing.Point(233, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 89);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tile Setting";
            // 
            // EventPlazaTilesetEditor
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(336, 298);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelTiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EventPlazaTilesetEditor";
            this.Text = "Tileset Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileData)).EndInit();
            this.panelTiles.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileEditor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTilesetSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPAL)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTileData;
        private System.Windows.Forms.Panel panelTiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxTileEditor;
        private System.Windows.Forms.CheckBox checkBoxFlipY;
        private System.Windows.Forms.CheckBox checkBoxFlipX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureBoxTilesetSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPAL;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}