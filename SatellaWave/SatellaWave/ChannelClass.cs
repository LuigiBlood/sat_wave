using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatellaWave
{
    //All Channel Classes
    enum ServiceType : ushort
    {
        BSX = 0x0101,
        Game = 0x0102,
    };

    enum ChannelType : byte
    {
        None, Message, Town, Directory, Patch, DownloadFile, Data
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

        public TownStatus(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout) : base(_pv, _pr, _name, _lci, _timeout)
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

        public Directory(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout) : base(_pv, _pr, _name, _lci, _timeout)
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

        public Folder(string _name, string _message, int _type, int _purpose, int _id, int _mugshot)
        {
            name = _name;
            message = _message;
            type = _type;
            purpose = _purpose;
            id = _id;
            mugshot = _mugshot;
        }
    }

    class DownloadFile : Channel
    {
        public bool isItem;    //Is this file an item?
        public byte fileID;     //File ID for Town Status

        public string filedesc;    //Description of the File/Item

        //Item only     (Ignored if isItem is false)
        public string usage;   //Message when Item is used
        public ulong price;      //Price in G
        public bool oneuse;    //Item can only be used once or not

        //File only     (Ignored if isItem is true)
        public string filepath;
        //Filename
        public byte autostart;
        //0 = No
        //1 = Optional
        //2 = Yes
        public byte dest;
        //0 = WRAM
        //1 = PSRAM
        //2 = FLASH (All)
        //3 = FLASH (Free Space)

        public int filesize;
        //File Size
        public bool alsoAtHome;
        //Accessible at Home (32 max)
        public bool streamed;
        //File is a streamed executable

        public byte month;
        //Month (1-12)
        public byte day;
        //Day (1-31)

        public byte hour_start;
        public byte min_start;
        //HH:MM Begin
        public byte hour_end;
        public byte min_end;
        //HH:MM End

        public DownloadFile(bool _isItem, byte _id) : base()
        {
            type = (byte)ChannelType.DownloadFile;

            isItem = _isItem;
            fileID = _id;

            name = "File";
            filedesc = "This is a file.";

            usage = "I use the item.";
            price = 0;
            oneuse = false;

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

        public string GetTimeStart()
        {
            return hour_start.ToString("D2") + ":" + min_start.ToString("D2");
        }

        public string GetTimeEnd()
        {
            return hour_end.ToString("D2") + ":" + min_end.ToString("D2");
        }
    }

    class GenericData : Channel
    {
        public int fileType;    //0 = None, 1 = File Path, 2 = Array
        public string filePath;
        public byte[] array;

        public GenericData(ushort _pv, ushort _pr, string _name, ushort _lci) : base(_pv, _pr, _name, _lci)
        {
            type = (byte)ChannelType.Data;
            fileType = 0;
        }

        public GenericData(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout) : base(_pv, _pr, _name, _lci, _timeout)
        {
            type = (byte)ChannelType.Data;
            fileType = 0;
        }

        public void SetFilePath(string _path)
        {
            fileType = 1;
            filePath = _path;
            array = null;
        }

        public void SetByteArray(byte[] _array)
        {
            fileType = 2;
            filePath = null;
            array = _array;
        }

        public void SetNone()
        {
            fileType = 0;
            filePath = null;
            array = null;
        }
    }

    class Patch : GenericData
    {
        public int patchType;   //0 = Latest BS-X Update, 1 = File Path

        public Patch(ushort _pv, ushort _pr, string _name, ushort _lci) : base(_pv, _pr, _name, _lci)
        {
            patchType = 0;
            type = (byte)ChannelType.Patch;
        }

        public Patch(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout) : base(_pv, _pr, _name, _lci, _timeout)
        {
            patchType = 0;
            type = (byte)ChannelType.Patch;
        }
    }

    class EventPlaza
    {
        public string name;
        public ushort[] tilemap; //4*7 16x16 tiles

        //TODO: Animations

        //Custom Building
        public Color[] palette;        //16 color palette
        public byte[] tiles;           //Custom Graphic data
        public ushort[] tileset;       //Custom Tileset out of the tiles
        //public byte[] tilesetconfig;   //Custom Tileset config (solid, priority)
        public bool[] doors;             //Door locations (4*7)

        public EventPlaza()
        {
            name = "Event Plaza";
            tilemap = new ushort[4 * 7];
            doors = new bool[4 * 7];
            palette = new Color[16];
            for (int i = 0; i < palette.Length; i++)
            {
                palette[i] = new Color();
            }
            tiles = new byte[4];
            tileset = new ushort[4];
        }

        public EventPlaza(string _name)
        {
            name = _name;
            tilemap = new ushort[4 * 7];
            doors = new bool[4 * 7];
            palette = new Color[16];
            for (int i = 0; i < palette.Length; i++)
            {
                palette[i] = new Color();
            }
            tiles = new byte[4];
            tileset = new ushort[4];
        }

        public ushort[] GetPaletteExport()
        {
            ushort[] temp = new ushort[16];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = (ushort)((ushort)((palette[i].R / 255f) * 31)
                    | ((ushort)((palette[i].G / 255f) * 31) << 5)
                    | ((ushort)((palette[i].B / 255f) * 31) << 10));
            }

            return temp;
        }

        public ushort[] GetTileMapExport()
        {
            ushort[] tilemaptemp = tilemap;

            for (int i = 0; i < tilemaptemp.Length; i++)
            {
                if (doors[i])
                {
                    tilemaptemp[i] |= 0x8000;   //Bit15 must be set for doors
                }
            }

            return tilemaptemp;
        }

        //TODO: Animations

        public byte[] GetTileDataExport()
        {
            return tiles;
        }

        public ushort[] GetTilesetExport()
        {
            return tileset;
        }

        public byte[] GetDoorLocationsExport()
        {
            List<byte> doortemp = new List<byte>();

            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i])
                {
                    doortemp.Add((byte)(0x06 + (i % 4))); //X Coordinate
                    doortemp.Add((byte)(0x0D + (i / 4))); //Y Coordinate
                }
            }

            return doortemp.ToArray();
        }
    }
}
    