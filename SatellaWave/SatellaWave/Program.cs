using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SatellaWave
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        public static MainWindow mainWindow;
        public static ushort nextlci = 0x0120;
        public static ushort nextprgnumber = 0x0000;

        public static readonly string[] buildingList = {
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
            "Sewerage (Shop)"
        };

        public static readonly string[] peopleList =
        {
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
            "[Custom Script 2]"
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindow = new MainWindow();

            Application.Run(mainWindow);
        }

        public static void NewRepository()
        {
            //New repository needs Town Status and Directory (TODO) at least
            TownStatus _town = new TownStatus(0x0101, 0x0005, "Town Status", 0x0123);

            mainWindow.treeViewChn.Nodes.Clear();
            AddChannel(_town);
        }

        public static void AddChannel(Channel _chn)
        {
            TreeNode _node = new TreeNode(_chn.name + " (" + _chn.GetChannelNumberString() + ")");
            _node.Tag = _chn;

            if (_chn.type != (byte)ChannelType.Directory)
                _node.ContextMenuStrip = mainWindow.contextMenuStripChannelMenu;
            else
                _node.ContextMenuStrip = mainWindow.contextMenuStripDirectoryMenu;

            mainWindow.treeViewChn.Nodes.Add(_node);
            mainWindow.treeViewChn.SelectedNode = _node;
        }

        public static void AddChannel(int type)
        {
            if (type == 0)
            {
                //BS-X Welcome Message
                //Check if already present
                foreach (TreeNode _chn in mainWindow.treeViewChn.Nodes)
                {
                    if ((_chn.Tag as Channel).service_broadcast == 0x0101 && (_chn.Tag as Channel).program_number == 0x0004)
                    {
                        MessageBox.Show("There is already a BS-X Message Channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageChannel _msg = new MessageChannel(0x0101, 0x0004, "Welcome Message", 0x0121, "");
                AddChannel(_msg);
            }
            else if(type == 1)
            {
                //BS-X Town Status
                //Check if already present
                foreach (TreeNode _chn in mainWindow.treeViewChn.Nodes)
                {
                    if ((_chn.Tag as Channel).service_broadcast == 0x0101 && (_chn.Tag as Channel).program_number == 0x0005)
                    {
                        MessageBox.Show("There is already a BS-X Town Status Channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                TownStatus _town = new TownStatus(0x0101, 0x0005, "Town Status", 0x0123);
                AddChannel(_town);
            }
            else if (type == 2)
            {
                //BS-X Directory
                //Check if already present
                foreach (TreeNode _chn in mainWindow.treeViewChn.Nodes)
                {
                    if ((_chn.Tag as Channel).service_broadcast == 0x0101 && (_chn.Tag as Channel).program_number == 0x0006)
                    {
                        MessageBox.Show("There is already a BS-X Directory Channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Directory _dir = new Directory(0x0101, 0x0006, "Directory", 0x0122);
                AddChannel(_dir);
            }
        }

        public static void AddFolder(TreeNode _node)
        {
            if (_node.Tag.GetType() == typeof(Directory))
            {
                Folder _folder = new Folder();
                TreeNode _tnode = new TreeNode(_folder.name);
                _tnode.Tag = _folder;
                _node.Nodes.Add(_tnode);
                mainWindow.treeViewChn.SelectedNode = _tnode;
            }
        }

        public static void AddFile(TreeNode _node)
        {
            if (_node.Tag.GetType() == typeof(Folder))
            {
                DownloadFile _file = new DownloadFile((_node.Tag as Folder).purpose == 1);

                _file.lci = GetNextLCI();
                _file.program_number = GetNextProgramNumber();
                _file.service_broadcast = 0x0103; //Dedicated to content, more than enough

                TreeNode _tnode = new TreeNode(_file.name);
                _tnode.Tag = _file;
                _node.Nodes.Add(_tnode);
                mainWindow.treeViewChn.SelectedNode = _tnode;
            }
        }

        public static ushort GetNextLCI()
        {
            do
            {
                nextlci = (ushort)(nextlci & 0x1F | (nextlci >> 3));
                nextlci++;
                nextlci = (ushort)(nextlci | ((nextlci & 0x3E0) << 3) | 0x0020);
            } while (CheckUsedLCI(nextlci));

            return nextlci;
        }

        public static bool CheckUsedLCI(ushort _lci)
        {
            if (_lci == 0x0124)
                return true;

            foreach (TreeNode _node in mainWindow.treeViewChn.Nodes)
            {
                if (_node.Tag.GetType() == typeof(Directory))
                {
                    //Check Folders
                    foreach (TreeNode _nodeChildFolder in _node.Nodes)
                    {
                        if (_nodeChildFolder.Tag.GetType() == typeof(Folder))
                        {
                            //Check Files
                            foreach (TreeNode _nodeFile in _nodeChildFolder.Nodes)
                            {
                                if ((_nodeFile.Tag as DownloadFile).lci == _lci)
                                {
                                    return true;
                                }

                                if (_nodeFile.Nodes.Count > 0)
                                {
                                    //Check Include Files if they exist
                                    foreach (TreeNode _nodeIncFile in _nodeFile.Nodes)
                                    {
                                        if ((_nodeIncFile.Tag as DownloadFile).lci == _lci)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if ((_node.Tag as Channel).lci == _lci)
                    {
                        return true;
                    }
                }
            }

            //not found
            return false;
        }

        public static ushort GetNextProgramNumber()
        {
            nextprgnumber += 0x0100;
            return nextprgnumber;
        }

        public static void ExportBSX(string folderPath)
        {
            //2794 bytes max per file
            List<byte> ChannelFile = new List<byte>();

            //Find, make the Directory First
            foreach (TreeNode _DirectoryCheck in mainWindow.treeViewChn.Nodes)
            {
                if (_DirectoryCheck.Tag.GetType() == typeof(Directory))
                {
                    ChannelFile.Clear(); //Clear everything, just to make sure

                    //Directory Header
                    ChannelFile.Add(1); //Directory ID
                    ChannelFile.Add((byte)_DirectoryCheck.Nodes.Count); //Folder Count
                    ChannelFile.Add(0); //Unknown
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    //Folders
                    foreach (TreeNode _Folder in _DirectoryCheck.Nodes)
                    {
                        if (_Folder.Tag.GetType() == typeof(Folder))
                        {
                            ChannelFile.Add(0); //Folder Flags

                            //Count Files (including Include Files)
                            int fileCount = _Folder.Nodes.Count;
                            bool checkInclude = false;

                            foreach (TreeNode _File in _Folder.Nodes)
                            {
                                fileCount += _File.Nodes.Count;
                                checkInclude |= (_File.Nodes.Count > 0);
                            }

                            if (fileCount >= 256)
                            {
                                MessageBox.Show("Error: Folder has more than 255 files.");
                                return;
                            }

                            ChannelFile.Add((byte)fileCount); //File Count

                            //Folder Name
                            for (int i = 0; i < 20; i++)
                            {
                                if ((_Folder.Tag as Folder).name.Length > i)
                                    ChannelFile.Add((byte)(_Folder.Tag as Folder).name[i]);
                                else
                                    ChannelFile.Add(0);
                            }

                            ChannelFile.Add(0); //Name Terminator

                            ChannelFile.Add((byte)((_Folder.Tag as Folder).message.Length + 1)); //Length Message
                            foreach (char _chr in (_Folder.Tag as Folder).message)
                            {
                                ChannelFile.Add((byte)_chr);
                            }
                            ChannelFile.Add(0); //Message Terminator

                            ChannelFile.Add((byte)((_Folder.Tag as Folder).purpose
                                | ((_Folder.Tag as Folder).type << 1)
                                | (Convert.ToByte(checkInclude) << 2))); //Folder Type

                            ChannelFile.Add((byte)((_Folder.Tag as Folder).id));    //Folder ID
                            ChannelFile.Add(0); //Unknown
                            ChannelFile.Add(0); //Unknown
                            ChannelFile.Add((byte)((_Folder.Tag as Folder).mugshot));    //Folder Mugshot
                            ChannelFile.Add(0); //Unknown
                            ChannelFile.Add(0); //Unknown
                            ChannelFile.Add(0); //Unknown

                            //Files
                            foreach (TreeNode _File in _Folder.Nodes)
                            {
                                ChannelFile.Add(1); //File ID
                                ChannelFile.Add(0); //Check

                                //File Name
                                for (int i = 0; i < 20; i++)
                                {
                                    if ((_File.Tag as DownloadFile).name.Length > i)
                                        ChannelFile.Add((byte)(_File.Tag as DownloadFile).name[i]);
                                    else
                                        ChannelFile.Add(0);
                                }
                                ChannelFile.Add(0);

                                if ((_File.Tag as DownloadFile).isItem)
                                {
                                    //Item
                                    ChannelFile.Add(0x79); //Item Size

                                    //Description
                                    for (int i = 0; i < 36; i++)
                                    {
                                        if ((_File.Tag as DownloadFile).filedesc.Length > i)
                                            ChannelFile.Add((byte)(_File.Tag as DownloadFile).filedesc[i]);
                                        else
                                            ChannelFile.Add(0);
                                    }
                                    ChannelFile.Add(0);

                                    //Activation Message
                                    for (int i = 0; i < 70; i++)
                                    {
                                        if ((_File.Tag as DownloadFile).usage.Length > i)
                                            ChannelFile.Add((byte)(_File.Tag as DownloadFile).usage[i]);
                                        else
                                            ChannelFile.Add(0);
                                    }
                                    ChannelFile.Add(0);

                                    //Price
                                    foreach (char _chr in (_File.Tag as DownloadFile).price.ToString("D12"))
                                    {
                                        ChannelFile.Add((byte)_chr);
                                    }

                                    //One Use
                                    ChannelFile.Add(Convert.ToByte(!(_File.Tag as DownloadFile).oneuse));

                                    //Useless Bytes
                                    for (int i = 0; i < 26; i++)
                                        ChannelFile.Add(0);
                                }
                                else
                                {
                                    //File
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).filedesc.Length + 1)); //Description Length

                                    //Description
                                    foreach (char _chr in (_File.Tag as DownloadFile).filedesc)
                                    {
                                        ChannelFile.Add((byte)_chr);
                                    }
                                    ChannelFile.Add(0);

                                    //Service Broadcast
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).service_broadcast >> 8));
                                    ChannelFile.Add((byte)(_File.Tag as DownloadFile).service_broadcast);
                                    //Program Number
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).program_number >> 8));
                                    ChannelFile.Add((byte)(_File.Tag as DownloadFile).program_number);
                                    //File Size
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).filesize >> 16));
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).filesize >> 8));
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).filesize));
                                    //Unknown
                                    ChannelFile.Add(0);
                                    ChannelFile.Add(0);
                                    ChannelFile.Add(0);
                                    //Flags
                                    ChannelFile.Add((byte)(Convert.ToByte((_File.Tag as DownloadFile).alsoAtHome) << 2
                                        | Convert.ToByte((_File.Tag as DownloadFile).streamed) << 3));
                                    //Unknown
                                    ChannelFile.Add(0);
                                    //Destination
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).autostart
                                        | ((_File.Tag as DownloadFile).dest << 2)));
                                    //Unknown
                                    ChannelFile.Add(0);
                                    ChannelFile.Add(0);
                                    //Date
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).month << 4));
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).day << 3));
                                    //Time
                                    ChannelFile.Add((byte)(((_File.Tag as DownloadFile).hour_start << 3)
                                        | ((_File.Tag as DownloadFile).min_start >> 3)));
                                    ChannelFile.Add((byte)(((_File.Tag as DownloadFile).min_start << 5)
                                        | (_File.Tag as DownloadFile).hour_end));
                                    ChannelFile.Add((byte)((_File.Tag as DownloadFile).min_end << 2));

                                    if (_File.Nodes.Count > 0)
                                    {
                                        //Include Files

                                        //Service Broadcast
                                        ChannelFile.Add((byte)((_File.Nodes[0].Tag as DownloadFile).service_broadcast >> 8));
                                        ChannelFile.Add((byte)(_File.Nodes[0].Tag as DownloadFile).service_broadcast);
                                        //Program Number
                                        ChannelFile.Add((byte)((_File.Nodes[0].Tag as DownloadFile).program_number >> 8));
                                        ChannelFile.Add((byte)(_File.Nodes[0].Tag as DownloadFile).program_number);
                                    }
                                    else
                                    {
                                        ChannelFile.Add(0);
                                        ChannelFile.Add(0);
                                        ChannelFile.Add(0);
                                        ChannelFile.Add(0);
                                    }
                                    //Unknown
                                    ChannelFile.Add(0);
                                    ChannelFile.Add(0);

                                    if (_File.Nodes.Count > 0)
                                    {
                                        for (int inclCount = 0; inclCount < _File.Nodes.Count; inclCount++)
                                        {
                                            ChannelFile.Add(1); //File ID
                                            ChannelFile.Add(0); //Check

                                            //File Name
                                            for (int i = 0; i < 20; i++)
                                            {
                                                if ((_File.Nodes[inclCount].Tag as DownloadFile).name.Length > i)
                                                    ChannelFile.Add((byte)(_File.Nodes[inclCount].Tag as DownloadFile).name[i]);
                                                else
                                                    ChannelFile.Add(0);
                                            }
                                            ChannelFile.Add(0);

                                            //File
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).filedesc.Length + 1)); //Description Length

                                            //Description
                                            foreach (char _chr in (_File.Nodes[inclCount].Tag as DownloadFile).filedesc)
                                            {
                                                ChannelFile.Add((byte)_chr);
                                            }
                                            ChannelFile.Add(0);

                                            //Service Broadcast
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).service_broadcast >> 8));
                                            ChannelFile.Add((byte)(_File.Nodes[inclCount].Tag as DownloadFile).service_broadcast);
                                            //Program Number
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).program_number >> 8));
                                            ChannelFile.Add((byte)(_File.Nodes[inclCount].Tag as DownloadFile).program_number);
                                            //File Size
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).filesize >> 16));
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).filesize >> 8));
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).filesize));
                                            //Unknown
                                            ChannelFile.Add(0);
                                            ChannelFile.Add(0);
                                            ChannelFile.Add(0);
                                            //Flags
                                            ChannelFile.Add((byte)(Convert.ToByte((_File.Nodes[inclCount].Tag as DownloadFile).alsoAtHome) << 2
                                                | Convert.ToByte((_File.Nodes[inclCount].Tag as DownloadFile).streamed) << 3));
                                            //Unknown
                                            ChannelFile.Add(0);
                                            //Destination
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).autostart
                                                | ((_File.Nodes[inclCount].Tag as DownloadFile).dest << 2)));
                                            //Unknown
                                            ChannelFile.Add(0);
                                            ChannelFile.Add(0);
                                            //Date
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).month << 4));
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).day << 3));
                                            //Time
                                            ChannelFile.Add((byte)(((_File.Nodes[inclCount].Tag as DownloadFile).hour_start << 3)
                                                | ((_File.Nodes[inclCount].Tag as DownloadFile).min_start >> 3)));
                                            ChannelFile.Add((byte)(((_File.Nodes[inclCount].Tag as DownloadFile).min_start << 5)
                                                | (_File.Nodes[inclCount].Tag as DownloadFile).hour_end));
                                            ChannelFile.Add((byte)((_File.Nodes[inclCount].Tag as DownloadFile).min_end << 2));

                                            if (_File.Nodes.Count > inclCount)
                                            {
                                                //Service Broadcast
                                                ChannelFile.Add((byte)((_File.Nodes[inclCount + 1].Tag as DownloadFile).service_broadcast >> 8));
                                                ChannelFile.Add((byte)(_File.Nodes[inclCount + 1].Tag as DownloadFile).service_broadcast);
                                                //Program Number
                                                ChannelFile.Add((byte)((_File.Nodes[inclCount + 1].Tag as DownloadFile).program_number >> 8));
                                                ChannelFile.Add((byte)(_File.Nodes[inclCount + 1].Tag as DownloadFile).program_number);
                                            }
                                            else
                                            {
                                                ChannelFile.Add(0);
                                                ChannelFile.Add(0);
                                                ChannelFile.Add(0);
                                                ChannelFile.Add(0);
                                            }

                                            ChannelFile.Add(0);
                                            ChannelFile.Add(0);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //Expansion Packet (TODO)

                    //Write File
                    SaveChannelFile(ChannelFile.ToArray(), (_DirectoryCheck.Tag as Directory).lci, folderPath);
                }
            }

            foreach (TreeNode _Channel in mainWindow.treeViewChn.Nodes)
            {
                if (_Channel.Tag.GetType() == typeof(MessageChannel))
                {
                    //Message
                    ChannelFile.Clear();

                    foreach (char _chr in (_Channel.Tag as MessageChannel).message.ToCharArray())
                    {
                        ChannelFile.Add((byte)_chr);
                    }
                    ChannelFile.Add(0);

                    SaveChannelFile(ChannelFile.ToArray(), (_Channel.Tag as MessageChannel).lci, folderPath);
                }
                else if (_Channel.Tag.GetType() == typeof(TownStatus))
                {
                    //Town Status
                    ChannelFile.Clear();

                    ChannelFile.Add(0); //Flag
                    ChannelFile.Add(1); //Town Status ID
                    ChannelFile.Add(1); //Directory ID

                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    ChannelFile.Add((byte)(((_Channel.Tag as TownStatus).radio_setup << 6) | ((_Channel.Tag as TownStatus).apu_setup << 4)));
                    ChannelFile.Add(0);

                    //NPC/Event Flags
                    for (int x = 0; x < 8; x++)
                    {
                        byte _flag = 0;
                        for (int y = 0; y < 8; y++)
                        {
                            if ((_Channel.Tag as TownStatus).npc_flags[x * 8 + y] == true)
                                _flag |= (byte)(1 << y);
                        }
                        ChannelFile.Add(_flag);
                    }

                    ushort townsetup = 0;
                    townsetup = (ushort)(1 << ((_Channel.Tag as TownStatus).fountain - 1));
                    townsetup |= (ushort)((1 << ((_Channel.Tag as TownStatus).season - 1) << 12));

                    ChannelFile.Add((byte)townsetup);
                    ChannelFile.Add((byte)(townsetup >> 8));

                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    ChannelFile.Add(0); //Number of file IDs, 0 because no files implemented

                    if (ChannelFile.Count > 256)
                    {
                        MessageBox.Show("Error: Town Status is more than 256 bytes.");
                        return;
                    }

                    SaveChannelFile(ChannelFile.ToArray(), (_Channel.Tag as TownStatus).lci, folderPath);
                }
            }

            //Make the Service List
            List<ushort> ServiceList = new List<ushort>();
            foreach (TreeNode _node in mainWindow.treeViewChn.Nodes)
            {
                Channel _chan = _node.Tag as Channel;

                if (ServiceList.Contains(_chan.service_broadcast) == false)
                {
                    ServiceList.Add(_chan.service_broadcast);
                }
            }

            //Make BSX0124-0.bin, it is the full channel map
            List<byte> ChannelMapFile = new List<byte>();

            //Header part
            ChannelMapFile.Add((byte)'S');
            ChannelMapFile.Add((byte)'F');
            ChannelMapFile.Add(0);
            ChannelMapFile.Add(0);
            ChannelMapFile.Add(0);
            ChannelMapFile.Add(0);
            ChannelMapFile.Add((byte)ServiceList.Count);
            byte chksum = 0;
            foreach (byte _chk in ChannelMapFile)
            {
                chksum += _chk;
            }
            ChannelMapFile.Add(chksum);

            //Service Broadcast List
            foreach (ushort _cur_service in ServiceList)
            {
                ChannelMapFile.Add((byte)(_cur_service >> 8));
                ChannelMapFile.Add((byte)_cur_service);

                //Counter
                byte _count = 0;
                foreach (TreeNode _node in mainWindow.treeViewChn.Nodes)
                {
                    Channel _chan = _node.Tag as Channel;
                    if (_chan.service_broadcast == _cur_service)
                    {
                        _count++;
                    }
                }

                ChannelMapFile.Add(_count);

                //Program List
                foreach (TreeNode _node in mainWindow.treeViewChn.Nodes)
                {
                    Channel _chan = _node.Tag as Channel;
                    if (_chan.service_broadcast == _cur_service)
                    {
                        ChannelMapFile.Add(_chan.type);
                        ChannelMapFile.Add((byte)(_chan.program_number >> 8));
                        ChannelMapFile.Add((byte)_chan.program_number);

                        ChannelMapFile.Add(0);
                        ChannelMapFile.Add(0);
                        ChannelMapFile.Add(0);
                        ChannelMapFile.Add(0);
                        ChannelMapFile.Add(0);

                        ChannelMapFile.Add((byte)(_chan.timeout >> 8));
                        ChannelMapFile.Add((byte)_chan.timeout);

                        ChannelMapFile.Add(0); //Autostart stuff

                        ChannelMapFile.Add((byte)_chan.lci);
                        ChannelMapFile.Add((byte)(_chan.lci >> 8));
                    }
                }
            }

            //Finalize Channel Map File
            int size = ChannelMapFile.Count;
            ChannelMapFile.Insert(0, (byte)size);
            ChannelMapFile.Insert(0, (byte)(size >> 8));
            ChannelMapFile.Insert(0, (byte)(size >> 16));
            ChannelMapFile.Insert(0, 0);
            ChannelMapFile.Insert(0, 0);

            FileStream mapfile = new FileStream(folderPath + "\\BSX0124-0.bin", FileMode.Create);
            mapfile.Write(ChannelMapFile.ToArray(), 0, ChannelMapFile.Count);
            mapfile.Close();

            MessageBox.Show("Export succeeded");
        }

        public static void SaveChannelFile(byte[] filedata, ushort lci, string folderPath)
        {
            //Max size per file = 2794 bytes (including 10 byte header)
            int fileAmount = (int)Math.Ceiling(filedata.Length / 2784.0);

            for (int i = 0; i < fileAmount; i++)
            {
                FileStream chnfile = new FileStream(folderPath + "\\BSX" + lci.ToString("X4") + "-" + i.ToString() + ".bin", FileMode.Create);

                chnfile.WriteByte(0); //Data Group ID
                chnfile.WriteByte((byte)i); //Data Group Continuity

                if (i == fileAmount - 1)
                {
                    //Data Group Size
                    chnfile.WriteByte((byte)((filedata.Length + 5) >> 16));
                    chnfile.WriteByte((byte)((filedata.Length + 5) >> 8));
                    chnfile.WriteByte((byte)(filedata.Length + 5));

                    chnfile.WriteByte(1); //Fixed
                    chnfile.WriteByte((byte)fileAmount);    //Amount of fragments

                    chnfile.WriteByte((byte)((i * 2784) >> 16));
                    chnfile.WriteByte((byte)((i * 2784) >> 8));
                    chnfile.WriteByte((byte)(i * 2784));

                    chnfile.Write(filedata, (i * 2784), filedata.Length);
                }
                else
                {
                    chnfile.WriteByte(0x00);
                    chnfile.WriteByte(0x0A);
                    chnfile.WriteByte(0xE5);

                    chnfile.WriteByte(1); //Fixed
                    chnfile.WriteByte((byte)fileAmount);    //Amount of fragments

                    chnfile.WriteByte((byte)((i * 2784) >> 16));
                    chnfile.WriteByte((byte)((i * 2784) >> 8));
                    chnfile.WriteByte((byte)(i * 2784));

                    chnfile.Write(filedata, (i * 2784), 2784);
                }
                chnfile.Close();
            }
        }
    }
}
