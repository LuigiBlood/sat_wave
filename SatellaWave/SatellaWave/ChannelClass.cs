using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatellaWave
{
    //All Channel Classes
    enum ServiceType : ushort
    {
        BSX=0x0101,
        Game=0x0102,
    };

    enum ChannelType : byte
    {
        None, Message, Town, Directory, Patch, DownloadFile
    };

    enum FolderType
    {
        Download, Shop
    }

    enum FileType
    {
        File, Item
    }

    class Channel
    {
        //Default Channel content
        public ushort service_broadcast;
        public ushort program_number;
            //?.?.?.? format
        public byte type;
            //Channel Type enum
        public string name;
            //Name
        public ushort lci;
            //Logical Channel
        public ushort timeout;
            //In Seconds

        public Channel()
        {
            service_broadcast = 0;
            program_number = 0;
            type = (byte)ChannelType.None;
            name = "";
            lci = 0x0000;
            timeout = 10;
        }

        public Channel(ushort _pv, ushort _pr, string _name, ushort _lci)
        {
            service_broadcast = _pv;
            program_number = _pr;

            type = (byte)ChannelType.None;
            name = _name;
            lci = _lci;
            timeout = 10;
        }

        public Channel(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout)
        {
            service_broadcast = _pv;
            program_number = _pr;

            type = (byte)ChannelType.None;
            name = _name;
            lci = _lci;
            timeout = _timeout;
        }

        public string GetChannelNumberString()
        {
            return (service_broadcast >> 8).ToString()
                + "." + (service_broadcast & 0xFF).ToString()
                + "." + (program_number >> 8).ToString()
                + "." + (program_number & 0xFF).ToString();
        }
    }

    class MessageChannel : Channel
    {
        public string message;
            //Message that appears at the start (99 chars + 0x00)

        public MessageChannel() : base()
        {
            type = (byte)ChannelType.Message;
            message = "";
        }

        public MessageChannel(ushort _pv, ushort _pr, string _name, ushort _lci, string _msg) : base(_pv, _pr, _name, _lci)
        {
            type = (byte)ChannelType.Message;
            message = _msg;
        }

        public MessageChannel(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout, string _msg) : base(_pv, _pr, _name, _lci, _timeout)
        {
            type = (byte)ChannelType.Message;
            message = _msg;
        }
    }

    class TownStatus : Channel
    {
        public byte apu_setup;
            //0 = Mute
            //1 = SFX Only
            //2 = Half Volume (Music + SFX)
            //3 = Full Volume (Music + SFX)
        public byte radio_setup;
            //0 = No Radio
            //1 = Radio (0x00 sent to $2199)
            //2 = Radio (0x88 sent to $2199)
        public bool[] npc_flags;
            //All NPC flags (0-63)
        public byte fountain;
            //Monthly Fountain
        public byte season;
            //Season

        public TownStatus() : base()
        {
            type = (byte)ChannelType.Town;
            apu_setup = 3;
            radio_setup = 0;
            npc_flags = new bool[64];
            fountain = 0;
            season = 0;
        }

        public TownStatus(ushort _pv, ushort _pr, string _name, ushort _lci) : base(_pv, _pr, _name, _lci)
        {
            type = (byte)ChannelType.Town;
            apu_setup = 3;
            radio_setup = 0;
            npc_flags = new bool[64];
            fountain = 0;
            season = 0;
        }
    }

    class Directory : Channel
    {
        public Directory() : base()
        {
            type = (byte)ChannelType.Directory;
        }

        public Directory(ushort _pv, ushort _pr, string _name, ushort _lci) : base(_pv, _pr, _name, _lci)
        {
            type = (byte)ChannelType.Directory;
        }
    }

    class Folder
    {
        public string name;        //Name
        public string message;     //Message
        public int purpose;        //0 = Files, 1 = Shop with Items
        public int type;           //0 = Building, 1 = NPC
        public int id;             //ID of the building/NPC
        public int mugshot;        //Mugshot in the Building/NPC screen

        public Folder()
        {
            name = "Folder";
            message = "This is a folder.";
            type = 0;
            purpose = 1;
            id = 0;
            mugshot = 0;
        }
    }

    class DownloadFile : Channel
    {
        bool isItem;    //Is this file an item?
                        //If true, ignore the rest
        
        string filename;    //Name of the File/Item
        string filedesc;    //Description of the File/Item

        //Item only     (Ignored if isItem is false)
        string usage;   //Message when Item is used
        int price;      //Price in G
        bool oneuse;    //Item can only be used once or not

        //File only     (Ignored if isItem is true)
        string filepath;
            //Filename
        byte autostart;
            //0 = No
            //1 = Optional
            //2 = Yes
        byte dest;
            //0 = WRAM
            //1 = PSRAM
            //2 = FLASH (All)
            //3 = FLASH (Free Space)

        int filesize;
            //File Size
        bool alsoAtHome;
            //Accessible at Home (32 max)
        bool streamed;
            //File is a streamed executable

        byte month;
            //Month (1-12)
        byte day;
            //Day (1-31)

        byte hour_start;
        byte min_start;
            //HH:MM Begin
        byte hour_end;
        byte min_end;
            //HH:MM End

        public DownloadFile() : base()
        {
            type = (byte)ChannelType.DownloadFile;

            filepath = "";
            autostart = 0;
            dest = 0;
            filesize = 0;
            alsoAtHome = false;
            streamed = false;
            month = 1;
            day = 1;
            hour_start = 0;
            min_start = 0;
            hour_end = 23;
            min_end = 59;
        }
    }
}
