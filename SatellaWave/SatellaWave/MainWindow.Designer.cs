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
            this.toolStripMenuItemChannel_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.labelMessageCharLeft = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.contextMenuStripDirectoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDirectory_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDirectory_NewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDirectory_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemChannel_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDirectory = new System.Windows.Forms.GroupBox();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.textBoxFolderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFolderMessage = new System.Windows.Forms.TextBox();
            this.comboBoxFolderPurpose = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxFolderType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxFolderID = new System.Windows.Forms.ComboBox();
            this.labelFolderID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxFolderMugshot = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxTown.SuspendLayout();
            this.contextMenuStripChannelMenu.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.contextMenuStripDirectoryMenu.SuspendLayout();
            this.groupBoxDirectory.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
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
            this.addChannelToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addChannelToolStripMenuItem.Text = "Add Channel";
            this.addChannelToolStripMenuItem.Click += new System.EventHandler(this.addChannelToolStripMenuItem_Click);
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
            this.treeViewChn.HideSelection = false;
            this.treeViewChn.Location = new System.Drawing.Point(0, 27);
            this.treeViewChn.Name = "treeViewChn";
            this.treeViewChn.Size = new System.Drawing.Size(219, 341);
            this.treeViewChn.TabIndex = 1;
            this.treeViewChn.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewChn_BeforeSelect);
            this.treeViewChn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewChn_AfterSelect);
            this.treeViewChn.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewChn_NodeMouseClick);
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
            this.toolStripMenuItemChannel_Edit,
            this.toolStripMenuItemChannel_Delete});
            this.contextMenuStripChannelMenu.Name = "contextMenuStripChannelMenu";
            this.contextMenuStripChannelMenu.Size = new System.Drawing.Size(208, 48);
            // 
            // toolStripMenuItemChannel_Edit
            // 
            this.toolStripMenuItemChannel_Edit.Name = "toolStripMenuItemChannel_Edit";
            this.toolStripMenuItemChannel_Edit.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemChannel_Edit.Text = "Edit Channel Information";
            // 
            // groupBoxMessage
            // 
            this.groupBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMessage.Controls.Add(this.labelMessageCharLeft);
            this.groupBoxMessage.Controls.Add(this.textBoxMessage);
            this.groupBoxMessage.Location = new System.Drawing.Point(225, 27);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Size = new System.Drawing.Size(378, 341);
            this.groupBoxMessage.TabIndex = 4;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "Welcome Message";
            this.groupBoxMessage.Visible = false;
            // 
            // labelMessageCharLeft
            // 
            this.labelMessageCharLeft.AutoSize = true;
            this.labelMessageCharLeft.Location = new System.Drawing.Point(119, 95);
            this.labelMessageCharLeft.Name = "labelMessageCharLeft";
            this.labelMessageCharLeft.Size = new System.Drawing.Size(89, 13);
            this.labelMessageCharLeft.TabIndex = 1;
            this.labelMessageCharLeft.Text = "99 characters left";
            this.labelMessageCharLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Location = new System.Drawing.Point(9, 26);
            this.textBoxMessage.MaxLength = 99;
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(199, 63);
            this.textBoxMessage.TabIndex = 0;
            this.textBoxMessage.Text = "Line1\r\nLine2\r\nLine3\r\nLine4";
            this.textBoxMessage.TextChanged += new System.EventHandler(this.textBoxMessage_TextChanged);
            // 
            // contextMenuStripDirectoryMenu
            // 
            this.contextMenuStripDirectoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDirectory_NewFolder,
            this.toolStripSeparator3,
            this.toolStripMenuItemDirectory_Edit,
            this.toolStripMenuItemDirectory_Delete});
            this.contextMenuStripDirectoryMenu.Name = "contextMenuStripDirectoryMenu";
            this.contextMenuStripDirectoryMenu.Size = new System.Drawing.Size(208, 76);
            // 
            // toolStripMenuItemDirectory_Edit
            // 
            this.toolStripMenuItemDirectory_Edit.Name = "toolStripMenuItemDirectory_Edit";
            this.toolStripMenuItemDirectory_Edit.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemDirectory_Edit.Text = "Edit Channel Information";
            // 
            // toolStripMenuItemDirectory_NewFolder
            // 
            this.toolStripMenuItemDirectory_NewFolder.Name = "toolStripMenuItemDirectory_NewFolder";
            this.toolStripMenuItemDirectory_NewFolder.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemDirectory_NewFolder.Text = "Create New Folder";
            this.toolStripMenuItemDirectory_NewFolder.Click += new System.EventHandler(this.createFolder);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // toolStripMenuItemDirectory_Delete
            // 
            this.toolStripMenuItemDirectory_Delete.Name = "toolStripMenuItemDirectory_Delete";
            this.toolStripMenuItemDirectory_Delete.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemDirectory_Delete.Text = "Delete Channel";
            this.toolStripMenuItemDirectory_Delete.Click += new System.EventHandler(this.toolStripMenuItemChannel_Delete_Click);
            // 
            // toolStripMenuItemChannel_Delete
            // 
            this.toolStripMenuItemChannel_Delete.Name = "toolStripMenuItemChannel_Delete";
            this.toolStripMenuItemChannel_Delete.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemChannel_Delete.Text = "Delete Channel";
            this.toolStripMenuItemChannel_Delete.Click += new System.EventHandler(this.toolStripMenuItemChannel_Delete_Click);
            // 
            // groupBoxDirectory
            // 
            this.groupBoxDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDirectory.Controls.Add(this.buttonAddFolder);
            this.groupBoxDirectory.Location = new System.Drawing.Point(225, 27);
            this.groupBoxDirectory.Name = "groupBoxDirectory";
            this.groupBoxDirectory.Size = new System.Drawing.Size(378, 341);
            this.groupBoxDirectory.TabIndex = 2;
            this.groupBoxDirectory.TabStop = false;
            this.groupBoxDirectory.Text = "Directory";
            this.groupBoxDirectory.Visible = false;
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(9, 19);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(168, 73);
            this.buttonAddFolder.TabIndex = 0;
            this.buttonAddFolder.Text = "Create New Folder";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.createFolder);
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFolder.Controls.Add(this.comboBoxFolderMugshot);
            this.groupBoxFolder.Controls.Add(this.label10);
            this.groupBoxFolder.Controls.Add(this.labelFolderID);
            this.groupBoxFolder.Controls.Add(this.comboBoxFolderID);
            this.groupBoxFolder.Controls.Add(this.label9);
            this.groupBoxFolder.Controls.Add(this.comboBoxFolderType);
            this.groupBoxFolder.Controls.Add(this.label8);
            this.groupBoxFolder.Controls.Add(this.comboBoxFolderPurpose);
            this.groupBoxFolder.Controls.Add(this.textBoxFolderMessage);
            this.groupBoxFolder.Controls.Add(this.label7);
            this.groupBoxFolder.Controls.Add(this.label6);
            this.groupBoxFolder.Controls.Add(this.textBoxFolderName);
            this.groupBoxFolder.Location = new System.Drawing.Point(225, 27);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Size = new System.Drawing.Size(378, 341);
            this.groupBoxFolder.TabIndex = 1;
            this.groupBoxFolder.TabStop = false;
            this.groupBoxFolder.Text = "Folder";
            this.groupBoxFolder.Visible = false;
            // 
            // textBoxFolderName
            // 
            this.textBoxFolderName.Location = new System.Drawing.Point(74, 26);
            this.textBoxFolderName.Name = "textBoxFolderName";
            this.textBoxFolderName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFolderName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Message:";
            // 
            // textBoxFolderMessage
            // 
            this.textBoxFolderMessage.Location = new System.Drawing.Point(74, 58);
            this.textBoxFolderMessage.Multiline = true;
            this.textBoxFolderMessage.Name = "textBoxFolderMessage";
            this.textBoxFolderMessage.Size = new System.Drawing.Size(175, 66);
            this.textBoxFolderMessage.TabIndex = 3;
            // 
            // comboBoxFolderPurpose
            // 
            this.comboBoxFolderPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolderPurpose.FormattingEnabled = true;
            this.comboBoxFolderPurpose.Items.AddRange(new object[] {
            "Download",
            "Shop"});
            this.comboBoxFolderPurpose.Location = new System.Drawing.Point(74, 139);
            this.comboBoxFolderPurpose.Name = "comboBoxFolderPurpose";
            this.comboBoxFolderPurpose.Size = new System.Drawing.Size(175, 21);
            this.comboBoxFolderPurpose.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Type:";
            // 
            // comboBoxFolderType
            // 
            this.comboBoxFolderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolderType.FormattingEnabled = true;
            this.comboBoxFolderType.Items.AddRange(new object[] {
            "Building",
            "People"});
            this.comboBoxFolderType.Location = new System.Drawing.Point(74, 166);
            this.comboBoxFolderType.Name = "comboBoxFolderType";
            this.comboBoxFolderType.Size = new System.Drawing.Size(175, 21);
            this.comboBoxFolderType.TabIndex = 6;
            this.comboBoxFolderType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFolderType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Purpose:";
            // 
            // comboBoxFolderID
            // 
            this.comboBoxFolderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolderID.FormattingEnabled = true;
            this.comboBoxFolderID.Items.AddRange(new object[] {
            "Robot Tower",
            "News Wall",
            "Broadcast Station",
            "Burger Shop",
            "Police Box",
            "Calculator Building",
            "Beach House (Shop)",
            "Stadium",
            "Convenience Center (Shop)",
            "Girls School",
            "Game Factory",
            "Department Store",
            "Game Museum",
            "Abacus Building",
            "Tofu Hall",
            "Event Plaza",
            "Bagpotamia Temple",
            "Celebrity House",
            "Private House",
            "Telephone Booth",
            "Sewerage (Shop)"});
            this.comboBoxFolderID.Location = new System.Drawing.Point(74, 193);
            this.comboBoxFolderID.Name = "comboBoxFolderID";
            this.comboBoxFolderID.Size = new System.Drawing.Size(175, 21);
            this.comboBoxFolderID.TabIndex = 8;
            // 
            // labelFolderID
            // 
            this.labelFolderID.AutoSize = true;
            this.labelFolderID.Location = new System.Drawing.Point(15, 196);
            this.labelFolderID.Name = "labelFolderID";
            this.labelFolderID.Size = new System.Drawing.Size(50, 13);
            this.labelFolderID.TabIndex = 9;
            this.labelFolderID.Text = "Identifier:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Mugshot:";
            // 
            // comboBoxFolderMugshot
            // 
            this.comboBoxFolderMugshot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolderMugshot.FormattingEnabled = true;
            this.comboBoxFolderMugshot.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "0A",
            "0B",
            "0C",
            "0D",
            "0E",
            "0F",
            "10 (BS-X Logo)"});
            this.comboBoxFolderMugshot.Location = new System.Drawing.Point(74, 233);
            this.comboBoxFolderMugshot.Name = "comboBoxFolderMugshot";
            this.comboBoxFolderMugshot.Size = new System.Drawing.Size(175, 21);
            this.comboBoxFolderMugshot.TabIndex = 11;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 372);
            this.Controls.Add(this.groupBoxFolder);
            this.Controls.Add(this.groupBoxDirectory);
            this.Controls.Add(this.groupBoxMessage);
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
            this.groupBoxMessage.ResumeLayout(false);
            this.groupBoxMessage.PerformLayout();
            this.contextMenuStripDirectoryMenu.ResumeLayout(false);
            this.groupBoxDirectory.ResumeLayout(false);
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChannel_Edit;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelMessageCharLeft;
        public System.Windows.Forms.TreeView treeViewChn;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripChannelMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDirectory_NewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDirectory_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDirectory_Delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChannel_Delete;
        private System.Windows.Forms.GroupBox groupBoxDirectory;
        private System.Windows.Forms.Button buttonAddFolder;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripDirectoryMenu;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private System.Windows.Forms.TextBox textBoxFolderName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFolderMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxFolderPurpose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxFolderType;
        private System.Windows.Forms.Label labelFolderID;
        private System.Windows.Forms.ComboBox comboBoxFolderID;
        private System.Windows.Forms.ComboBox comboBoxFolderMugshot;
        private System.Windows.Forms.Label label10;
    }
}

