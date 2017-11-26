namespace SatellaWave
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newServerRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openServerRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.treeViewChn = new System.Windows.Forms.TreeView();
            this.checkedListBoxNPCs = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAudio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRadio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSeason = new System.Windows.Forms.ComboBox();
            this.groupBoxTown = new System.Windows.Forms.GroupBox();
            this.contextMenuStripChannelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditChnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBoxTown.SuspendLayout();
            this.contextMenuStripChannelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newServerRepositoryToolStripMenuItem,
            this.openServerRepositoryToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsRepositoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newServerRepositoryToolStripMenuItem
            // 
            this.newServerRepositoryToolStripMenuItem.Name = "newServerRepositoryToolStripMenuItem";
            this.newServerRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newServerRepositoryToolStripMenuItem.Text = "New Repository";
            this.newServerRepositoryToolStripMenuItem.Click += new System.EventHandler(this.newServerRepositoryToolStripMenuItem_Click);
            // 
            // openServerRepositoryToolStripMenuItem
            // 
            this.openServerRepositoryToolStripMenuItem.Name = "openServerRepositoryToolStripMenuItem";
            this.openServerRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openServerRepositoryToolStripMenuItem.Text = "Open Repository...";
            this.openServerRepositoryToolStripMenuItem.Click += new System.EventHandler(this.openServerRepositoryToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save Repository";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsRepositoryToolStripMenuItem
            // 
            this.saveAsRepositoryToolStripMenuItem.Name = "saveAsRepositoryToolStripMenuItem";
            this.saveAsRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsRepositoryToolStripMenuItem.Text = "Save as Repository...";
            this.saveAsRepositoryToolStripMenuItem.Click += new System.EventHandler(this.saveAsRepositoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChannelToolStripMenuItem});
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.channelToolStripMenuItem.Text = "Edit";
            // 
            // addChannelToolStripMenuItem
            // 
            this.addChannelToolStripMenuItem.Name = "addChannelToolStripMenuItem";
            this.addChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addChannelToolStripMenuItem.Text = "Add Channel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.channelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // treeViewChn
            // 
            this.treeViewChn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewChn.Location = new System.Drawing.Point(0, 27);
            this.treeViewChn.Name = "treeViewChn";
            this.treeViewChn.Size = new System.Drawing.Size(219, 341);
            this.treeViewChn.TabIndex = 1;
            this.treeViewChn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewChn_AfterSelect);
            // 
            // checkedListBoxNPCs
            // 
            this.checkedListBoxNPCs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxNPCs.FormattingEnabled = true;
            this.checkedListBoxNPCs.Items.AddRange(new object[] {
            "[Red Ball at Beach]",
            "Dr. Hiroshi",
            "Dororin",
            "Temple Guardian Left",
            "Temple Guardian Right",
            "Ghost",
            "Otakuman",
            "Gorou",
            "Samson",
            "Gozen Reiji",
            "Tamotsu Sekishita",
            "Mr. Arai",
            "Rinzo Charikawa",
            "Star Rarawo",
            "Manbei",
            "Kenichi",
            "Youta",
            "MIO",
            "MIO (School Uniform)",
            "Reiko",
            "Marina",
            "Akane",
            "Mako",
            "Midori",
            "Suzu Charikawa",
            "Ms. Sera",
            "Secretary Akiko",
            "Tomoko Shirase",
            "Yuka Tsutsumi",
            "Ina Sanda",
            "Fortuneteller Miki",
            "Asaji Kayo",
            "Kimono Girl",
            "Ikebe",
            "Ms. Ochiyo",
            "Old Woman",
            "Tell",
            "Sachiko",
            "Akiko",
            "Rocky (Dog)",
            "Jitsu Hyoue (Cat)",
            "Quack (Duck)",
            "TeeVee",
            "Wide TeeVee",
            "[Custom Script 1]",
            "[Custom Script 2]",
            "Fisher Take",
            "[Allow Fountain Ride]",
            "[Allow Train Station Ride]",
            "[Special Event]",
            "Name Frog",
            "Frame Frog",
            "Color Frog",
            "Arrow Frog",
            "[Allow baits at the Beach]",
            "[Ship]",
            "Mr. Money (500G)",
            "Mr. Money (1000G)",
            "Mr. Money (5000G)"});
            this.checkedListBoxNPCs.Location = new System.Drawing.Point(6, 42);
            this.checkedListBoxNPCs.Name = "checkedListBoxNPCs";
            this.checkedListBoxNPCs.Size = new System.Drawing.Size(234, 289);
            this.checkedListBoxNPCs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NPCs/Events:";
            // 
            // comboBoxAudio
            // 
            this.comboBoxAudio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudio.FormattingEnabled = true;
            this.comboBoxAudio.Items.AddRange(new object[] {
            "Full Volume",
            "Half Volume",
            "SFX only",
            "Mute"});
            this.comboBoxAudio.Location = new System.Drawing.Point(251, 254);
            this.comboBoxAudio.Name = "comboBoxAudio";
            this.comboBoxAudio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAudio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sound Mode:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Radio Mode:";
            // 
            // comboBoxRadio
            // 
            this.comboBoxRadio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxRadio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRadio.FormattingEnabled = true;
            this.comboBoxRadio.Items.AddRange(new object[] {
            "No Radio",
            "Radio Channel 1",
            "Radio Channel 2"});
            this.comboBoxRadio.Location = new System.Drawing.Point(251, 310);
            this.comboBoxRadio.Name = "comboBoxRadio";
            this.comboBoxRadio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRadio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monthly Fountain:";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "Default",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonth.Location = new System.Drawing.Point(251, 42);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMonth.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Season:";
            // 
            // comboBoxSeason
            // 
            this.comboBoxSeason.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeason.FormattingEnabled = true;
            this.comboBoxSeason.Items.AddRange(new object[] {
            "Default",
            "Spring",
            "Summer",
            "Autumn",
            "Winter"});
            this.comboBoxSeason.Location = new System.Drawing.Point(251, 92);
            this.comboBoxSeason.Name = "comboBoxSeason";
            this.comboBoxSeason.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSeason.TabIndex = 9;
            // 
            // groupBoxTown
            // 
            this.groupBoxTown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTown.Controls.Add(this.comboBoxSeason);
            this.groupBoxTown.Controls.Add(this.label5);
            this.groupBoxTown.Controls.Add(this.comboBoxMonth);
            this.groupBoxTown.Controls.Add(this.label4);
            this.groupBoxTown.Controls.Add(this.comboBoxRadio);
            this.groupBoxTown.Controls.Add(this.label3);
            this.groupBoxTown.Controls.Add(this.label2);
            this.groupBoxTown.Controls.Add(this.comboBoxAudio);
            this.groupBoxTown.Controls.Add(this.label1);
            this.groupBoxTown.Controls.Add(this.checkedListBoxNPCs);
            this.groupBoxTown.Location = new System.Drawing.Point(225, 27);
            this.groupBoxTown.Name = "groupBoxTown";
            this.groupBoxTown.Size = new System.Drawing.Size(378, 341);
            this.groupBoxTown.TabIndex = 2;
            this.groupBoxTown.TabStop = false;
            this.groupBoxTown.Text = "Town Status";
            this.groupBoxTown.Visible = false;
            // 
            // contextMenuStripChannelMenu
            // 
            this.contextMenuStripChannelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditChnInfo});
            this.contextMenuStripChannelMenu.Name = "contextMenuStripChannelMenu";
            this.contextMenuStripChannelMenu.Size = new System.Drawing.Size(208, 26);
            // 
            // toolStripMenuItemEditChnInfo
            // 
            this.toolStripMenuItemEditChnInfo.Name = "toolStripMenuItemEditChnInfo";
            this.toolStripMenuItemEditChnInfo.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemEditChnInfo.Text = "Edit Channel Information";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 372);
            this.Controls.Add(this.groupBoxTown);
            this.Controls.Add(this.treeViewChn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "SatellaWave";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxTown.ResumeLayout(false);
            this.groupBoxTown.PerformLayout();
            this.contextMenuStripChannelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newServerRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openServerRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChannelToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView treeViewChn;
        private System.Windows.Forms.CheckedListBox checkedListBoxNPCs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAudio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSeason;
        private System.Windows.Forms.GroupBox groupBoxTown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChannelMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditChnInfo;
    }
}

