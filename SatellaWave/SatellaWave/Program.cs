using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatellaWave
{
    class Channel
    {
        //Default Channel content

        public byte[] channel_number;
            //?.?.?.? format
        public byte type;
            //0 = Nothing
            //1 = Welcome Message
            //2 = Town Status
            //3 = Directory
            //4 = SNES Patch
            //5 = Download File
        public string name;
            //Name
        public UInt16 lci;
            //Logical Channel
        public UInt16 timeout;
            //In Seconds

        public Channel()
        {
            channel_number = new byte[4];
            type = 0;
            name = "";
            lci = 0x0000;
            timeout = 10;
        }

        public Channel(byte nb1, byte nb2, byte nb3, byte nb4, string _name, UInt16 _lci)
        {
            channel_number = new byte[4];
            channel_number[0] = nb1;
            channel_number[1] = nb2;
            channel_number[2] = nb3;
            channel_number[3] = nb4;

            type = 0;
            name = _name;
            lci = _lci;
            timeout = 10;
        }

        public Channel(byte nb1, byte nb2, byte nb3, byte nb4, string _name, UInt16 _lci, UInt16 _timeout)
        {
            channel_number = new byte[4];
            channel_number[0] = nb1;
            channel_number[1] = nb2;
            channel_number[2] = nb3;
            channel_number[3] = nb4;

            type = 0;
            name = _name;
            lci = _lci;
            timeout = _timeout;
        }

        public string GetChannelNumberString()
        {
            return channel_number[0].ToString() + "." + channel_number[1].ToString() + "." + channel_number[2].ToString() + "." + channel_number[3].ToString();
        }
    }

    class MessageChannel : Channel
    {
        public string message;

        public MessageChannel() : base()
        {
            type = 1;
            message = "";
        }

        public MessageChannel(byte nb1, byte nb2, byte nb3, byte nb4, string _name, UInt16 _lci, string _msg) : base(nb1, nb2, nb3, nb4, _name, _lci)
        {
            type = 1;
            message = _msg;
        }

        public MessageChannel(byte nb1, byte nb2, byte nb3, byte nb4, string _name, UInt16 _lci, UInt16 _timeout, string _msg) : base(nb1, nb2, nb3, nb4, _name, _lci, _timeout)
        {
            type = 1;
            message = _msg;
        }
    }

    class TownStatus : Channel
    {
        public byte apu_setup;
        public byte radio_setup;
        public bool[] npc_flags;
        public byte fountain;
        public byte season;

        public TownStatus() : base()
        {
            type = 2;
            apu_setup = 3;
            radio_setup = 0;
            npc_flags = new bool[64];
            fountain = 0;
            season = 0;
        }

        public TownStatus(byte nb1, byte nb2, byte nb3, byte nb4, string _name, UInt16 _lci) : base(nb1, nb2, nb3, nb4, _name, _lci)
        {
            type = 2;
            apu_setup = 3;
            radio_setup = 0;
            npc_flags = new bool[64];
            fountain = 0;
            season = 0;
        }
    }

    class DownloadFile : Channel
    {
        string filename;
        byte autostart;
            //0 = No
            //1 = Optional
            //2 = Yes
        byte dest;
            //0 = WRAM
            //1 = PSRAM
            //2 = FLASH (All)
            //3 = FLASH (Free Space)
        
        public DownloadFile() : base()
        {
            filename = "";
            autostart = 0;
            dest = 0;
        }
    }

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

        public static void NewRepository()
        {
            //New repository needs Town Status at least
            ChannelMap = new List<Channel>();

            TownStatus _town = new TownStatus(1, 1, 0, 5, "Town Status", 0x0125);
            ChannelMap.Add(_town);
        }
    }
}
