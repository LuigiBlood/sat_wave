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

        public static List<Channel> ChannelMap;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static List<TreeNode> NewRepository()
        {
            //New repository needs Town Status at least
            ChannelMap = new List<Channel>();

            TownStatus _town = new TownStatus(0x0101, 0x0005, "Town Status", 0x0125);
            ChannelMap.Add(_town);

            return UpdateList();
        }

        public static void ExportBSX(string folderPath)
        {
            //Make the Service List
            List<ushort> ServiceList = new List<ushort>();
            foreach (Channel _chan in ChannelMap)
            {
                if (ServiceList.Contains(_chan.service_broadcast) == false)
                {
                    ServiceList.Add(_chan.service_broadcast);
                }
            }

            //Make BSX0124-0.bin first, it is the full channel map
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
                foreach (Channel _chan in ChannelMap)
                {
                    if (_chan.service_broadcast == _cur_service)
                    {
                        _count++;
                    }
                }

                ChannelMapFile.Add(_count);

                //Program List
                foreach (Channel _chan in ChannelMap)
                {
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
        }

        public static List<TreeNode> UpdateList()
        {
            List<TreeNode> MainList = new List<TreeNode>();
            MainList.Clear();

            for (int i = 0; i < ChannelMap.Count; i++)
            {
                TreeNode _cur = new TreeNode(ChannelMap[i].name + " (" + ChannelMap[i].GetChannelNumberString() + ")");
                _cur.Tag = i;

                MainList.Add(_cur);
            }

            return MainList;
        }

        public static void SaveTownStatus(int index, byte _apu_setup, byte _radio_setup, bool[] _npc_flags, byte _fountain, byte _season)
        {
            if (ChannelMap[index].type != 2)
                return;

            TownStatus _town = ChannelMap[index] as TownStatus;
            _town.apu_setup = _apu_setup;
            _town.radio_setup = _radio_setup;
            _town.npc_flags = _npc_flags;
            _town.fountain = _fountain;
            _town.season = _season;

            ChannelMap.RemoveAt(index);
            ChannelMap.Insert(index, _town);
        }
    }
}
