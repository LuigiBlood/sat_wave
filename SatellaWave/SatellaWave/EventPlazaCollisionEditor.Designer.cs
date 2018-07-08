namespace SatellaWave
{
    partial class EventPlazaCollisionEditor
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPriority = new System.Windows.Forms.CheckBox();
            this.checkBoxDiagonal = new System.Windows.Forms.CheckBox();
            this.pictureBoxTile = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTileset = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(277, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(196, 110);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPriority);
            this.groupBox1.Controls.Add(this.checkBoxDiagonal);
            this.groupBox1.Controls.Add(this.pictureBoxTile);
            this.groupBox1.Location = new System.Drawing.Point(173, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collision Setup";
            // 
            // checkBoxPriority
            // 
            this.checkBoxPriority.AutoSize = true;
            this.checkBoxPriority.Location = new System.Drawing.Point(76, 42);
            this.checkBoxPriority.Name = "checkBoxPriority";
            this.checkBoxPriority.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPriority.TabIndex = 2;
            this.checkBoxPriority.Text = "Over the Player";
            this.checkBoxPriority.UseVisualStyleBackColor = true;
            this.checkBoxPriority.CheckedChanged += new System.EventHandler(this.checkBoxPriority_CheckedChanged);
            // 
            // checkBoxDiagonal
            // 
            this.checkBoxDiagonal.AutoSize = true;
            this.checkBoxDiagonal.Location = new System.Drawing.Point(76, 19);
            this.checkBoxDiagonal.Name = "checkBoxDiagonal";
            this.checkBoxDiagonal.Size = new System.Drawing.Size(109, 17);
            this.checkBoxDiagonal.TabIndex = 1;
            this.checkBoxDiagonal.Text = "Diagonal Collision";
            this.checkBoxDiagonal.UseVisualStyleBackColor = true;
            this.checkBoxDiagonal.CheckedChanged += new System.EventHandler(this.checkBoxDiagonal_CheckedChanged);
            // 
            // pictureBoxTile
            // 
            this.pictureBoxTile.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTile.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTile.Name = "pictureBoxTile";
            this.pictureBoxTile.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxTile.TabIndex = 0;
            this.pictureBoxTile.TabStop = false;
            this.pictureBoxTile.Click += new System.EventHandler(this.pictureBoxTile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxTileset);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 89);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Tile";
            // 
            // pictureBoxTileset
            // 
            this.pictureBoxTileset.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTileset.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTileset.Name = "pictureBoxTileset";
            this.pictureBoxTileset.Size = new System.Drawing.Size(128, 64);
            this.pictureBoxTileset.TabIndex = 0;
            this.pictureBoxTileset.TabStop = false;
            this.pictureBoxTileset.Click += new System.EventHandler(this.pictureBoxTileset_Click);
            // 
            // EventPlazaCollisionEditor
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(364, 145);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EventPlazaCollisionEditor";
            this.Text = "Collision Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxPriority;
        private System.Windows.Forms.CheckBox checkBoxDiagonal;
        private System.Windows.Forms.PictureBox pictureBoxTile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxTileset;
    }
}