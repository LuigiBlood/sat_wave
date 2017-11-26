using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatellaWave
{
    //All Channel Classes
    class Channel
    {
        //Default Channel content

        public ushort service_broadcast;
        public ushort program_number;
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
        public ushort lci;
        //Logical Channel
        public ushort timeout;
        //In Seconds

        public Channel()
        {
            service_broadcast = 0;
            program_number = 0;
            type = 0;
            name = "";
            lci = 0x0000;
            timeout = 10;
        }

        public Channel(ushort _pv, ushort _pr, string _name, ushort _lci)
        {
            service_broadcast = _pv;
            program_number = _pr;

            type = 0;
            name = _name;
            lci = _lci;
            timeout = 10;
        }

        public Channel(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout)
        {
            service_broadcast = _pv;
            program_number = _pr;

            type = 0;
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
            type = 1;
            message = "";
        }

        public MessageChannel(ushort _pv, ushort _pr, string _name, ushort _lci, string _msg) : base(_pv, _pr, _name, _lci)
        {
            type = 1;
            message = _msg;
        }

        public MessageChannel(ushort _pv, ushort _pr, string _name, ushort _lci, ushort _timeout, string _msg) : base(_pv, _pr, _name, _lci, _timeout)
        {
            type = 1;
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
            type = 2;
            apu_setup = 3;
            radio_setup = 0;
            npc_flags = new bool[64];
            fountain = 0;
            season = 0;
        }

        public TownStatus(ushort _pv, ushort _pr, string _name, ushort _lci) : base(_pv, _pr, _name, _lci)
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

        public DownloadFile() : base()
        {
            filename = "";
            autostart = 0;
            dest = 0;
        }
    }
}
