namespace SatellaWave
{
    partial class EventPlazaGFXEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBoxCustomTileset = new System.Windows.Forms.PictureBox();
            this.pictureBoxPalettes = new System.Windows.Forms.PictureBox();
            this.buttonPaletteImport = new System.Windows.Forms.Button();
            this.buttonPaletteExport = new System.Windows.Forms.Button();
            this.buttonTilesetImport = new System.Windows.Forms.Button();
            this.buttonTilesetExport = new System.Windows.Forms.Button();
            this.buttonTileImport = new System.Windows.Forms.Button();
            this.buttonTileExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalettes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTilesetExport);
            this.groupBox1.Controls.Add(this.buttonTilesetImport);
            this.groupBox1.Controls.Add(this.pictureBoxCustomTileset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom 16x16 Tileset";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(397, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "16x16 Tile Editor";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(286, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Collision Editor";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonPaletteExport);
            this.groupBox4.Controls.Add(this.buttonPaletteImport);
            this.groupBox4.Controls.Add(this.pictureBoxPalettes);
            this.groupBox4.Location = new System.Drawing.Point(12, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 115);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Palette";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonTileExport);
            this.groupBox5.Controls.Add(this.buttonTileImport);
            this.groupBox5.Location = new System.Drawing.Point(12, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 208);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select Tiles";
            // 
            // pictureBoxCustomTileset
            // 
            this.pictureBoxCustomTileset.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCustomTileset.Location = new System.Drawing.Point(6, 46);
            this.pictureBoxCustomTileset.Name = "pictureBoxCustomTileset";
            this.pictureBoxCustomTileset.Size = new System.Drawing.Size(256, 48);
            this.pictureBoxCustomTileset.TabIndex = 0;
            this.pictureBoxCustomTileset.TabStop = false;
            // 
            // pictureBoxPalettes
            // 
            this.pictureBoxPalettes.BackColor = System.Drawing.Color.Black;
            this.pictureBoxPalettes.Location = new System.Drawing.Point(6, 45);
            this.pictureBoxPalettes.Name = "pictureBoxPalettes";
            this.pictureBoxPalettes.Size = new System.Drawing.Size(256, 64);
            this.pictureBoxPalettes.TabIndex = 0;
            this.pictureBoxPalettes.TabStop = false;
            // 
            // buttonPaletteImport
            // 
            this.buttonPaletteImport.Location = new System.Drawing.Point(6, 19);
            this.buttonPaletteImport.Name = "buttonPaletteImport";
            this.buttonPaletteImport.Size = new System.Drawing.Size(83, 23);
            this.buttonPaletteImport.TabIndex = 1;
            this.buttonPaletteImport.Text = "Import Palette";
            this.buttonPaletteImport.UseVisualStyleBackColor = true;
            // 
            // buttonPaletteExport
            // 
            this.buttonPaletteExport.Location = new System.Drawing.Point(179, 19);
            this.buttonPaletteExport.Name = "buttonPaletteExport";
            this.buttonPaletteExport.Size = new System.Drawing.Size(83, 23);
            this.buttonPaletteExport.TabIndex = 2;
            this.buttonPaletteExport.Text = "Export Palette";
            this.buttonPaletteExport.UseVisualStyleBackColor = true;
            // 
            // buttonTilesetImport
            // 
            this.buttonTilesetImport.Location = new System.Drawing.Point(6, 19);
            this.buttonTilesetImport.Name = "buttonTilesetImport";
            this.buttonTilesetImport.Size = new System.Drawing.Size(83, 23);
            this.buttonTilesetImport.TabIndex = 1;
            this.buttonTilesetImport.Text = "Import Tileset";
            this.buttonTilesetImport.UseVisualStyleBackColor = true;
            // 
            // buttonTilesetExport
            // 
            this.buttonTilesetExport.Location = new System.Drawing.Point(179, 19);
            this.buttonTilesetExport.Name = "buttonTilesetExport";
            this.buttonTilesetExport.Size = new System.Drawing.Size(83, 23);
            this.buttonTilesetExport.TabIndex = 2;
            this.buttonTilesetExport.Text = "Export Tileset";
            this.buttonTilesetExport.UseVisualStyleBackColor = true;
            // 
            // buttonTileImport
            // 
            this.buttonTileImport.Location = new System.Drawing.Point(6, 19);
            this.buttonTileImport.Name = "buttonTileImport";
            this.buttonTileImport.Size = new System.Drawing.Size(95, 23);
            this.buttonTileImport.TabIndex = 0;
            this.buttonTileImport.Text = "Import Tile Data";
            this.buttonTileImport.UseVisualStyleBackColor = true;
            // 
            // buttonTileExport
            // 
            this.buttonTileExport.Location = new System.Drawing.Point(165, 19);
            this.buttonTileExport.Name = "buttonTileExport";
            this.buttonTileExport.Size = new System.Drawing.Size(97, 23);
            this.buttonTileExport.TabIndex = 1;
            this.buttonTileExport.Text = "Export Tile Data";
            this.buttonTileExport.UseVisualStyleBackColor = true;
            // 
            // EventPlazaGFXEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 459);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EventPlazaGFXEditor";
            this.Text = "Custom Graphics Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalettes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonTilesetExport;
        private System.Windows.Forms.Button buttonTilesetImport;
        private System.Windows.Forms.PictureBox pictureBoxCustomTileset;
        private System.Windows.Forms.Button buttonPaletteExport;
        private System.Windows.Forms.Button buttonPaletteImport;
        private System.Windows.Forms.PictureBox pictureBoxPalettes;
        private System.Windows.Forms.Button buttonTileExport;
        private System.Windows.Forms.Button buttonTileImport;
    }
}