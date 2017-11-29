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
            TreeNode _node = new TreeNode(_chn.name);
            _node.Tag = _chn;
            _node.ContextMenuStrip = mainWindow.contextMenuStripChannelMenu;

            mainWindow.treeViewChn.Nodes.Add(_node);
        }

        public static void AddChannel(int type)
        {
            if (type == 0)
            {
                //Welcome Message
                //Check if already present
                foreach (TreeNode _chn in mainWindow.treeViewChn.Nodes)
                {
                    if ((_chn.Tag as Channel).service_broadcast == 0x0101 && (_chn.Tag as Channel).program_number == 0x0004)
                    {
                        MessageBox.Show("There is already a Message Channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageChannel _msg = new MessageChannel(0x0101, 0x0004, "Welcome Message", 0x0121, "");
                AddChannel(_msg);
            }
        }

        public static void ExportBSX(string folderPath)
        {
            //Make other stuff before
            List<byte> ChannelFile = new List<byte>();

            for (int i = 0; i < mainWindow.treeViewChn.Nodes.Count; i++)
            {
                if ((mainWindow.treeViewChn.Nodes[i].Tag as Channel).type == (byte)ChannelType.Message)
                {
                    //Message
                    MessageChannel _msg = mainWindow.treeViewChn.Nodes[i].Tag as MessageChannel;

                    ChannelFile.Clear();

                    //Header
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add((byte)(_msg.message.Length + 5 + 1)); //can only be under 255 bytes
                    ChannelFile.Add(1);
                    ChannelFile.Add(1);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    //Message
                    foreach (char _chr in _msg.message.ToCharArray())
                    {
                        ChannelFile.Add((byte)_chr);
                    }
                    ChannelFile.Add(0);

                    FileStream chnfile = new FileStream(folderPath + "\\BSX" + _msg.lci.ToString("X4") + "-0.bin", FileMode.Create);
                    chnfile.Write(ChannelFile.ToArray(), 0, ChannelFile.Count);
                    chnfile.Close();
                }
                else if ((mainWindow.treeViewChn.Nodes[i].Tag as Channel).type == (byte)ChannelType.Town)
                {
                    //Town Status
                    TownStatus _town = mainWindow.treeViewChn.Nodes[i].Tag as TownStatus;

                    ChannelFile.Clear();

                    ChannelFile.Add(0); //Flag
                    ChannelFile.Add(1); //Town Status ID
                    ChannelFile.Add(1); //Directory ID

                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    ChannelFile.Add((byte)((_town.radio_setup << 6) | (_town.apu_setup << 4)));
                    ChannelFile.Add(0);

                    //NPC/Event Flags
                    for (int x = 0; x < 8; x++)
                    {
                        byte _flag = 0;
                        for (int y = 0; y < 8; y++)
                        {
                            if (_town.npc_flags[x * 8 + y] == true)
                                _flag |= (byte)(1 << y);
                        }
                        ChannelFile.Add(_flag);
                    }

                    ushort townsetup = 0;
                    townsetup = (ushort)(1 << (_town.fountain - 1));
                    townsetup |= (ushort)((1 << (_town.season - 1) << 12));

                    ChannelFile.Add((byte)townsetup);
                    ChannelFile.Add((byte)(townsetup >> 8));

                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);
                    ChannelFile.Add(0);

                    ChannelFile.Add(0); //Number of file IDs, 0 because no files implemented

                    int filesize = ChannelFile.Count;
                    if (filesize > 256)
                    {
                        MessageBox.Show("Error: Town Status is more than 256 bytes.");
                        return;
                    }

                    //Target Offset
                    ChannelFile.Insert(0, 0);
                    ChannelFile.Insert(0, 0);
                    ChannelFile.Insert(0, 0);
                    //Number of Fragments (1)
                    ChannelFile.Insert(0, 1);
                    //Fixed
                    ChannelFile.Insert(0, 1);
                    //Data Group Size
                    ChannelFile.Insert(0, (byte)filesize);
                    ChannelFile.Insert(0, (byte)(filesize >> 8));
                    ChannelFile.Insert(0, (byte)(filesize >> 16));
                    //Data Group Continuity
                    ChannelFile.Insert(0, 0);
                    //Data Group ID 1
                    ChannelFile.Insert(0, 0);

                    FileStream chnfile = new FileStream(folderPath + "\\BSX"+ _town.lci.ToString("X4") + "-0.bin", FileMode.Create);
                    chnfile.Write(ChannelFile.ToArray(), 0, ChannelFile.Count);
                    chnfile.Close();
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
    }
}
