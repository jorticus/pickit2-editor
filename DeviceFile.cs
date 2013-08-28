using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

using KONST = PICkit2V2.Constants;
using System.Reflection;
using PicKit2_Script_Editor;
using System.ComponentModel;
using System.Drawing.Design;

namespace PICkit2V2
{
    public class DeviceFile
    {
        public string Filename;
        public DeviceFileParams Info = new DeviceFileParams();
        public DeviceFamilyParams[] Families;
        public DevicePartParams[] PartsList;
        public DeviceScripts[] Scripts;

        public void AddFamily(DeviceFamilyParams family)
        {
            Families = Families.Concat(new DeviceFamilyParams[] { family }).ToArray();
            Info.NumberFamilies++;
        }
        public void AddPart(DevicePartParams part)
        {
            part.ConfigMasks = (ushort[])part.ConfigMasks.Clone();
            part.ConfigBlank = (ushort[])part.ConfigBlank.Clone();
            PartsList = PartsList.Concat(new DevicePartParams[] { part }).ToArray();
            Info.NumberParts++;
        }
        public void AddScript(DeviceScripts script)
        {
            script.Script = (ushort[])script.Script.Clone();
            Scripts = Scripts.Concat(new DeviceScripts[] { script }).ToArray();
            Info.NumberScripts++;
        }

        public struct DeviceFileParams
        {
            // One instance of this structure is included at the start of the Device File
            public int VersionMajor;    // Device file version number major.minor.dot
            public int VersionMinor;
            public int VersionDot;

            public string VersionNotes; // Max 512 characters

            public int NumberFamilies;  // # number of DeviceFamilyParams sets
            public int NumberParts;     // # number of DevicePartParams sets
            public int NumberScripts;   // # number of DeviceScripts sets
            public byte Compatibility;
            public byte UNUSED1A;
            public ushort UNUSED1B;
            public uint UNUSED2;

        }

        public struct DeviceFamilyParams
        {
            // a single struct instance describes the parameters for an entire part family.
            public ushort FamilyID;             // # essentially, its array index number.
            public ushort FamilyType;           // also used as the display order in the Device Family Menu - lower first
            public ushort SearchPriority;
            public string FamilyName;           // 16 -> 24 chars max (v2.50)
            public ushort ProgEntryScript;
            public ushort ProgExitScript;
            public ushort ReadDevIDScript;
            public uint DeviceIDMask;           // HEX
            public uint BlankValue;             // HEX
            public byte BytesPerLocation;
            public byte AddressIncrement;
            public bool PartDetect;
            public ushort ProgEntryVPPScript;   // program entry VPP first
            public ushort UNUSED1;
            public byte EEMemBytesPerWord;
            public byte EEMemAddressIncrement;
            public byte UserIDHexBytes;
            public byte UserIDBytes;
            public byte ProgMemHexBytes;   // added 7-10-06
            public byte EEMemHexBytes;   // added 7-10-06
            public byte ProgMemShift;   // added 7-10-06
            public uint TestMemoryStart;        // HEX
            public ushort TestMemoryLength;
            public float Vpp;
        }

        public struct DevicePartParams
        {
            public override string ToString()
            {
                return PartName;
            }

            // a single struct instance describes parameters for a single silicon part.
            [Category("Device"), Description("Device name, maximum 20 chars")]
            public string PartName { get; set; }             // 20 chars max
            [Category("Device"), Description("Corresponds to FamilyID"), TypeConverter(typeof(HexConverter))]
            public ushort Family { get; set; }               // references FamilyID in DeviceFamilyParams
            [Category("Device"), Description("Device ID, see Programmer's Manual to find"), TypeConverter(typeof(HexConverter))]
            public uint DeviceID { get; set; }
            [Category("Device"), Description("Size of flash memory. Calculate from the datasheet using this: ProgramMem = DatasheetValue * 2 + 1"), TypeConverter(typeof(HexConverter))]
            public uint ProgramMem { get; set; }
            [Category("EEPROM"), Description("Size of EEPROM, in bytes"), TypeConverter(typeof(HexConverter))]
            public ushort EEMem { get; set; }
            [Category("EEPROM"), Description("Starting address of EEPROM memory"), TypeConverter(typeof(HexConverter))]
            public uint EEAddr { get; set; }

            [Category("Masks"), Description("The number of config registers")]
            public byte ConfigWords { get; set; }
            [Category("Masks"), Description("The address of the highest config register, eg. CONFIG4. Calculate from the datasheet using this: ConfigAddr = CONFIG[n]Address * 2"), TypeConverter(typeof(HexConverter))]
            public uint ConfigAddr { get; set; }             // HEX
            [Category("Masks")]
            public byte UserIDWords { get; set; }
            [Category("Masks"), TypeConverter(typeof(HexConverter))]
            public uint UserIDAddr { get; set; }             // HEX
            [Category("Masks"), TypeConverter(typeof(HexConverter))]
            public uint BandGapMask { get; set; }            // HEX
            [Category("Masks"), Description("Mask unused Masks. This can be found in the device datasheet. To find the value, set all the reserved bits to 0, and all other bits to 1.")]
            public ushort[] ConfigMasks { get; set; }        // HEX 
            [Category("Masks"), Description("Sets the default config bit values. Check the device datasheet to see what the reserved bits should be set to. Set to 0xFFFF if unsure, though that's not guaranteed to work.")]
            public ushort[] ConfigBlank { get; set; }        // HEX 
            [Category("Masks"), Description("Masks out the code-protect bits so the GUI can detect if code-protect is active"), TypeConverter(typeof(HexConverter))]
            public ushort CPMask { get; set; }               // HEX
            [Category("Masks"), Description("Specifies the config register which contains the code-protect bits. CPConfig is 1-based, not 0-based.")]
            public byte CPConfig { get; set; }
            [Category("Misc")]
            public bool OSSCALSave { get; set; }
            [Category("Misc"), TypeConverter(typeof(HexConverter))]
            public uint IgnoreAddress { get; set; }          // HEX
            [Category("Device"), Description("Minimum allowable Vdd")]
            public float VddMin { get; set; }
            [Category("Device"), Description("Maximum allowable Vdd")]
            public float VddMax { get; set; }
            [Category("Device"), Description("Minimum Vdd required to erase")]
            public float VddErase { get; set; }
            [Category("Misc")]
            public byte CalibrationWords { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ChipEraseScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ProgMemAddrSetScript { get; set; }
            public byte ProgMemAddrBytes { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ProgMemRdScript { get; set; }
            public ushort ProgMemRdWords { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EERdPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EERdScript { get; set; }
            [Category("Misc")]
            public ushort EERdLocations { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort UserIDRdPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort UserIDRdScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ConfigRdPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ConfigRdScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ProgMemWrPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ProgMemWrScript { get; set; }
            [Category("Misc")]
            public ushort ProgMemWrWords { get; set; }
            [Category("Misc")]
            public byte ProgMemPanelBufs { get; set; }
            [Category("Misc")]
            public uint ProgMemPanelOffset { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EEWrPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EEWrScript { get; set; }
            public ushort EEWrLocations { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort UserIDWrPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort UserIDWrScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ConfigWrPrepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ConfigWrScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort OSCCALRdScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort OSCCALWrScript { get; set; }
            [Category("Masks"), TypeConverter(typeof(HexConverter))]
            public ushort DPMask { get; set; }
            [Category("Misc")]
            public bool WriteCfgOnErase { get; set; }
            [Category("Misc")]
            public bool BlankCheckSkipUsrIDs { get; set; }
            [Category("Misc")]
            public ushort IgnoreBytes { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ChipErasePrepScript { get; set; }
            [Category("Misc")]
            public uint BootFlash { get; set; }
            //public uint UNUSED4;
            [Category("Masks"), TypeConverter(typeof(HexConverter))]
            public ushort Config9Mask { get; set; }
            [Category("Masks")]
            public ushort Config9Blank { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ProgMemEraseScript { get; set; } // added 7-10-06
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EEMemEraseScript { get; set; } // added 7-10-06
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort ConfigMemEraseScript { get; set; } // added 7-10-06
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort reserved1EraseScript { get; set; } // added 7-10-06
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort reserved2EraseScript { get; set; } // added 7-10-06
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort TestMemoryRdScript { get; set; }
            [Category("Misc")]
            public ushort TestMemoryRdWords { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort EERowEraseScript { get; set; }
            [Category("Misc")]
            public ushort EERowEraseWords { get; set; }
            [Category("Misc")]
            public bool ExportToMPLAB { get; set; }

            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugHaltScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugRunScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugStatusScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReadExecVerScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugSingleStepScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugBulkWrDataScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugBulkRdDataScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugWriteVectorScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReadVectorScript { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugRowEraseScript { get; set; }
            [Category("Misc")]
            public ushort DebugRowEraseSize { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReserved5Script { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReserved6Script { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReserved7Script { get; set; }
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort DebugReserved8Script { get; set; }
            //public ushort DebugReserved9Script;
            [Category("Scripts"), Editor(typeof(ScriptEditor), typeof(UITypeEditor)), TypeConverter(typeof(ScriptConverter))]
            public ushort LVPScript { get; set; }
        }

        public class Opcode
        {
            public byte index;
            public byte opcode;
            public byte[] data;

            public override string ToString()
            {
                string s = string.Format("{0:X2}", opcode);
                foreach (byte v in data)
                    s += " " + string.Format("{0:X2}", v);
                return s;
            }

            public string Parse()
            {
                // Return the enum name that corresponds to this opcode, or just the HEX value otherwise.
                string s = Enum.GetName(typeof(OPCODES), (OPCODES)opcode).Substring(1);
                if (s == null) s = string.Format("{0:X2}", opcode);
                return s;
            }

            public string ParseInst()
            {
                var op = (OPCODES)opcode;
                if (op == OPCODES._COREINST24)
                {
                    var instdata = new byte[data.Length - 1];
                    for (int i = 0; i < instdata.Length; i++)
                        instdata[i] = data[i + 1];

                    return CoreInst24.ParseCoreInst24(data[0], instdata);
                }
                else
                {
                    return string.Join(" ", data.Select(v => string.Format("{0:X2}", v)));
                }
            }
        }

        public struct DeviceScripts
        {
            [Description("Index of the script")]
            public ushort ScriptNumber { get; set; }         // # Essentially, its array index number - 1 based 0 reserved for no script
            // referred to in the XxxxxxScript fields of DevicePartParams
            [Description("Name of the script, maximum 20 characters")]
            public string ScriptName { get; set; }           // 20 Chars max
            [Description("Increment this if you change the script")]
            public ushort ScriptVersion { get; set; }        // increments on each change
            public uint UNUSED1;
            public ushort ScriptLength;
            public ushort[] Script;
            [Description("Script description, maximum 20 characters")]
            public string Comment { get; set; }            // 20 max

            public List<Opcode> ParseScript()
            {

                var script = new List<Opcode>();
                int idx = 0;

                var data = new List<byte>();
                Opcode opcode = null;

                while (idx < ScriptLength)
                {
                    ushort v = Script[idx++];
                    ushort typ = (ushort)(v & 0xFF00);

                    // Opcode
                    if (typ == 0xAA00)
                    {
                        // Add last opcode to the parsed script
                        if (opcode != null)
                        {
                            data.Reverse();
                            opcode.data = data.ToArray();
                            script.Add(opcode);
                            data = new List<byte>();
                        }

                        opcode = new Opcode();
                        opcode.opcode = (byte)(v & 0x00FF);
                        opcode.index = (byte)(idx - 1);
                    }
                    
                    // Data word (0xBBxx or 0x00xx) (Not sure of difference between BB and 00 though)
                    else
                    {
                        data.Add((byte)(v & 0x00FF));
                    }

                }

                // Add final opcode
                if (opcode != null)
                {
                    data.Reverse();
                    opcode.data = data.ToArray();
                    script.Add(opcode);
                    data = new List<byte>();
                }

                return script;
            }

        }

        public bool LoadFromFile(string DeviceFileName)
        {
            this.Filename = DeviceFileName;
            DeviceFile DevFile = this;
            bool fileExists = File.Exists(DeviceFileName);
            if (fileExists)
            {
                //try
                {
                    //FileStream fsDevFile = File.Open(DeviceFileName, FileMode.Open);
                    FileStream fsDevFile = File.OpenRead(DeviceFileName);
                    using (BinaryReader binRead = new BinaryReader(fsDevFile))
                    {
                        //
                        DevFile.Info.VersionMajor = binRead.ReadInt32();
                        DevFile.Info.VersionMinor = binRead.ReadInt32();
                        DevFile.Info.VersionDot = binRead.ReadInt32();
                        DevFile.Info.VersionNotes = binRead.ReadString();
                        DevFile.Info.NumberFamilies = binRead.ReadInt32();
                        DevFile.Info.NumberParts = binRead.ReadInt32();
                        DevFile.Info.NumberScripts = binRead.ReadInt32();
                        DevFile.Info.Compatibility = binRead.ReadByte();
                        DevFile.Info.UNUSED1A = binRead.ReadByte();
                        DevFile.Info.UNUSED1B = binRead.ReadUInt16();
                        DevFile.Info.UNUSED2 = binRead.ReadUInt32();
                        // create a version string
                        var DeviceFileVersion = string.Format("{0:D1}.{1:D2}.{2:D2}", DevFile.Info.VersionMajor,
                                         DevFile.Info.VersionMinor, DevFile.Info.VersionDot);
                        //
                        // Declare arrays
                        //
                        DevFile.Families = new DeviceFile.DeviceFamilyParams[DevFile.Info.NumberFamilies];
                        DevFile.PartsList = new DeviceFile.DevicePartParams[DevFile.Info.NumberParts];
                        DevFile.Scripts = new DeviceFile.DeviceScripts[DevFile.Info.NumberScripts];
                        //
                        // now read all families if they are there
                        //
                        for (int l_x = 0; l_x < DevFile.Info.NumberFamilies; l_x++)
                        {
                            DevFile.Families[l_x].FamilyID = binRead.ReadUInt16();
                            DevFile.Families[l_x].FamilyType = binRead.ReadUInt16();
                            DevFile.Families[l_x].SearchPriority = binRead.ReadUInt16();
                            DevFile.Families[l_x].FamilyName = binRead.ReadString();
                            DevFile.Families[l_x].ProgEntryScript = binRead.ReadUInt16();
                            DevFile.Families[l_x].ProgExitScript = binRead.ReadUInt16();
                            DevFile.Families[l_x].ReadDevIDScript = binRead.ReadUInt16();
                            DevFile.Families[l_x].DeviceIDMask = binRead.ReadUInt32();
                            DevFile.Families[l_x].BlankValue = binRead.ReadUInt32();
                            DevFile.Families[l_x].BytesPerLocation = binRead.ReadByte();
                            DevFile.Families[l_x].AddressIncrement = binRead.ReadByte();
                            DevFile.Families[l_x].PartDetect = binRead.ReadBoolean();
                            DevFile.Families[l_x].ProgEntryVPPScript = binRead.ReadUInt16();
                            DevFile.Families[l_x].UNUSED1 = binRead.ReadUInt16();
                            DevFile.Families[l_x].EEMemBytesPerWord = binRead.ReadByte();
                            DevFile.Families[l_x].EEMemAddressIncrement = binRead.ReadByte();
                            DevFile.Families[l_x].UserIDHexBytes = binRead.ReadByte();
                            DevFile.Families[l_x].UserIDBytes = binRead.ReadByte();
                            DevFile.Families[l_x].ProgMemHexBytes = binRead.ReadByte();
                            DevFile.Families[l_x].EEMemHexBytes = binRead.ReadByte();
                            DevFile.Families[l_x].ProgMemShift = binRead.ReadByte();
                            DevFile.Families[l_x].TestMemoryStart = binRead.ReadUInt32();
                            DevFile.Families[l_x].TestMemoryLength = binRead.ReadUInt16();
                            DevFile.Families[l_x].Vpp = binRead.ReadSingle();
                        }
                        // Create family search table based on priority
                        var familySearchTable = new int[DevFile.Info.NumberFamilies];
                        for (int familyIdx = 0; familyIdx < DevFile.Info.NumberFamilies; familyIdx++)
                        {
                            familySearchTable[DevFile.Families[familyIdx].SearchPriority] = familyIdx;
                        }
                        //
                        // now read all parts if they are there
                        //
                        for (int l_x = 0; l_x < DevFile.Info.NumberParts; l_x++)
                        {
                            DevFile.PartsList[l_x].PartName = binRead.ReadString();
                            DevFile.PartsList[l_x].Family = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DeviceID = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].ProgramMem = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].EEMem = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EEAddr = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].ConfigWords = binRead.ReadByte();
                            DevFile.PartsList[l_x].ConfigAddr = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].UserIDWords = binRead.ReadByte();
                            DevFile.PartsList[l_x].UserIDAddr = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].BandGapMask = binRead.ReadUInt32();
                            // Init config arrays
                            DevFile.PartsList[l_x].ConfigMasks = new ushort[KONST.NumConfigMasks];
                            DevFile.PartsList[l_x].ConfigBlank = new ushort[KONST.NumConfigMasks];
                            for (int l_index = 0; l_index < KONST.MaxReadCfgMasks; l_index++)
                            {
                                DevFile.PartsList[l_x].ConfigMasks[l_index] = binRead.ReadUInt16();
                            }
                            for (int l_index = 0; l_index < KONST.MaxReadCfgMasks; l_index++)
                            {
                                DevFile.PartsList[l_x].ConfigBlank[l_index] = binRead.ReadUInt16();
                            }
                            DevFile.PartsList[l_x].CPMask = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].CPConfig = binRead.ReadByte();
                            DevFile.PartsList[l_x].OSSCALSave = binRead.ReadBoolean();
                            DevFile.PartsList[l_x].IgnoreAddress = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].VddMin = binRead.ReadSingle();
                            DevFile.PartsList[l_x].VddMax = binRead.ReadSingle();
                            DevFile.PartsList[l_x].VddErase = binRead.ReadSingle();
                            DevFile.PartsList[l_x].CalibrationWords = binRead.ReadByte();
                            DevFile.PartsList[l_x].ChipEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemAddrSetScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemAddrBytes = binRead.ReadByte();
                            DevFile.PartsList[l_x].ProgMemRdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemRdWords = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EERdPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EERdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EERdLocations = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].UserIDRdPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].UserIDRdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigRdPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigRdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemWrPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemWrScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemWrWords = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ProgMemPanelBufs = binRead.ReadByte();
                            DevFile.PartsList[l_x].ProgMemPanelOffset = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].EEWrPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EEWrScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EEWrLocations = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].UserIDWrPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].UserIDWrScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigWrPrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigWrScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].OSCCALRdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].OSCCALWrScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DPMask = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].WriteCfgOnErase = binRead.ReadBoolean();
                            DevFile.PartsList[l_x].BlankCheckSkipUsrIDs = binRead.ReadBoolean();
                            DevFile.PartsList[l_x].IgnoreBytes = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ChipErasePrepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].BootFlash = binRead.ReadUInt32();
                            //DevFile.PartsList[l_x].UNUSED4 = binRead.ReadUInt32();
                            DevFile.PartsList[l_x].Config9Mask = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigMasks[8] = DevFile.PartsList[l_x].Config9Mask;
                            DevFile.PartsList[l_x].Config9Blank = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigBlank[8] = DevFile.PartsList[l_x].Config9Blank;
                            DevFile.PartsList[l_x].ProgMemEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EEMemEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ConfigMemEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].reserved1EraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].reserved2EraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].TestMemoryRdScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].TestMemoryRdWords = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EERowEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].EERowEraseWords = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].ExportToMPLAB = binRead.ReadBoolean();
                            DevFile.PartsList[l_x].DebugHaltScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugRunScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugStatusScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReadExecVerScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugSingleStepScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugBulkWrDataScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugBulkRdDataScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugWriteVectorScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReadVectorScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugRowEraseScript = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugRowEraseSize = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReserved5Script = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReserved6Script = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReserved7Script = binRead.ReadUInt16();
                            DevFile.PartsList[l_x].DebugReserved8Script = binRead.ReadUInt16();
                            //DevFile.PartsList[l_x].DebugReserved9Script = binRead.ReadUInt16();                                                       
                            DevFile.PartsList[l_x].LVPScript = binRead.ReadUInt16();
                        }
                        //
                        // now read all scripts if they are there
                        //                    
                        for (int l_x = 0; l_x < DevFile.Info.NumberScripts; l_x++)
                        {
                            DevFile.Scripts[l_x].ScriptNumber = binRead.ReadUInt16();
                            DevFile.Scripts[l_x].ScriptName = binRead.ReadString();
                            DevFile.Scripts[l_x].ScriptVersion = binRead.ReadUInt16();
                            DevFile.Scripts[l_x].UNUSED1 = binRead.ReadUInt32();
                            DevFile.Scripts[l_x].ScriptLength = binRead.ReadUInt16();
                            // init script array
                            DevFile.Scripts[l_x].Script = new ushort[DevFile.Scripts[l_x].ScriptLength];
                            for (int l_index = 0; l_index < DevFile.Scripts[l_x].ScriptLength; l_index++)
                            {
                                DevFile.Scripts[l_x].Script[l_index] = binRead.ReadUInt16();
                            }
                            DevFile.Scripts[l_x].Comment = binRead.ReadString();
                        }

                        binRead.Close();
                    }
                    fsDevFile.Close();
                }
                /*catch
                {
                    return false;
                }*/
                return true;
            }
            else
            {
                return false;
            }
        }


        public void SaveToFile(string DeviceFileName)
        {
            DeviceFile DevFile = this;

            FileStream fsDevFile = File.Open(DeviceFileName, FileMode.Create);
            //FileStream fsDevFile = File.OpenRead(DeviceFileName);
            using (BinaryWriter binWrite = new BinaryWriter(fsDevFile))
            {
                //
                binWrite.Write(DevFile.Info.VersionMajor);
                binWrite.Write(DevFile.Info.VersionMinor);
                binWrite.Write(DevFile.Info.VersionDot);
                binWrite.Write(DevFile.Info.VersionNotes);
                binWrite.Write(DevFile.Info.NumberFamilies);
                binWrite.Write(DevFile.Info.NumberParts);
                binWrite.Write(DevFile.Info.NumberScripts);
                binWrite.Write(DevFile.Info.Compatibility);
                binWrite.Write(DevFile.Info.UNUSED1A);
                binWrite.Write(DevFile.Info.UNUSED1B);
                binWrite.Write(DevFile.Info.UNUSED2);

                // create a version string
                //var DeviceFileVersion = string.Format("{0:D1}.{1:D2}.{2:D2}", DevFile.Info.VersionMajor,
                //                    DevFile.Info.VersionMinor, DevFile.Info.VersionDot);
                //
                // Declare arrays
                //
                //DevFile.Families = new DeviceFile.DeviceFamilyParams[DevFile.Info.NumberFamilies];
                //DevFile.PartsList = new DeviceFile.DevicePartParams[DevFile.Info.NumberParts];
                //DevFile.Scripts = new DeviceFile.DeviceScripts[DevFile.Info.NumberScripts];
                //
                // now read all families if they are there
                //
                for (int l_x = 0; l_x < DevFile.Info.NumberFamilies; l_x++)
                {
                    binWrite.Write(DevFile.Families[l_x].FamilyID);
                    binWrite.Write(DevFile.Families[l_x].FamilyType);
                    binWrite.Write(DevFile.Families[l_x].SearchPriority);
                    binWrite.Write(DevFile.Families[l_x].FamilyName);
                    binWrite.Write(DevFile.Families[l_x].ProgEntryScript);
                    binWrite.Write(DevFile.Families[l_x].ProgExitScript);
                    binWrite.Write(DevFile.Families[l_x].ReadDevIDScript);
                    binWrite.Write(DevFile.Families[l_x].DeviceIDMask);
                    binWrite.Write(DevFile.Families[l_x].BlankValue);
                    binWrite.Write(DevFile.Families[l_x].BytesPerLocation);
                    binWrite.Write(DevFile.Families[l_x].AddressIncrement);
                    binWrite.Write(DevFile.Families[l_x].PartDetect);
                    binWrite.Write(DevFile.Families[l_x].ProgEntryVPPScript);
                    binWrite.Write(DevFile.Families[l_x].UNUSED1);
                    binWrite.Write(DevFile.Families[l_x].EEMemBytesPerWord);
                    binWrite.Write(DevFile.Families[l_x].EEMemAddressIncrement);
                    binWrite.Write(DevFile.Families[l_x].UserIDHexBytes);
                    binWrite.Write(DevFile.Families[l_x].UserIDBytes);
                    binWrite.Write(DevFile.Families[l_x].ProgMemHexBytes);
                    binWrite.Write(DevFile.Families[l_x].EEMemHexBytes);
                    binWrite.Write(DevFile.Families[l_x].ProgMemShift);
                    binWrite.Write(DevFile.Families[l_x].TestMemoryStart);
                    binWrite.Write(DevFile.Families[l_x].TestMemoryLength);
                    binWrite.Write((Single)DevFile.Families[l_x].Vpp);
                }
                // Create family search table based on priority
                //var familySearchTable = new int[DevFile.Info.NumberFamilies];
                //for (int familyIdx = 0; familyIdx < DevFile.Info.NumberFamilies; familyIdx++)
                //{
                //    familySearchTable[DevFile.Families[familyIdx].SearchPriority] = familyIdx;
                //}
                //
                // now read all parts if they are there
                //
                for (int l_x = 0; l_x < DevFile.Info.NumberParts; l_x++)
                {
                    binWrite.Write(DevFile.PartsList[l_x].PartName);
                    binWrite.Write(DevFile.PartsList[l_x].Family);
                    binWrite.Write(DevFile.PartsList[l_x].DeviceID);
                    binWrite.Write(DevFile.PartsList[l_x].ProgramMem);
                    binWrite.Write(DevFile.PartsList[l_x].EEMem);
                    binWrite.Write(DevFile.PartsList[l_x].EEAddr);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigWords);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigAddr);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDWords);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDAddr);
                    binWrite.Write(DevFile.PartsList[l_x].BandGapMask);

                    // Init config arrays
                    //DevFile.PartsList[l_x].ConfigMasks = new ushort[KONST.NumConfigMasks];
                    //DevFile.PartsList[l_x].ConfigBlank = new ushort[KONST.NumConfigMasks];
                    for (int l_index = 0; l_index < KONST.MaxReadCfgMasks; l_index++)
                    {
                        binWrite.Write(DevFile.PartsList[l_x].ConfigMasks[l_index]);
                        //DevFile.PartsList[l_x].ConfigMasks[l_index] = binRead.ReadUInt16();
                    }
                    for (int l_index = 0; l_index < KONST.MaxReadCfgMasks; l_index++)
                    {
                        binWrite.Write(DevFile.PartsList[l_x].ConfigBlank[l_index]);
                        //DevFile.PartsList[l_x].ConfigBlank[l_index] = binRead.ReadUInt16();
                    }

                    binWrite.Write(DevFile.PartsList[l_x].CPMask);
                    binWrite.Write(DevFile.PartsList[l_x].CPConfig);
                    binWrite.Write(DevFile.PartsList[l_x].OSSCALSave);
                    binWrite.Write(DevFile.PartsList[l_x].IgnoreAddress);
                    binWrite.Write(DevFile.PartsList[l_x].VddMin);
                    binWrite.Write(DevFile.PartsList[l_x].VddMax);
                    binWrite.Write(DevFile.PartsList[l_x].VddErase);
                    binWrite.Write(DevFile.PartsList[l_x].CalibrationWords);
                    binWrite.Write(DevFile.PartsList[l_x].ChipEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemAddrSetScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemAddrBytes);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemRdScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemRdWords);
                    binWrite.Write(DevFile.PartsList[l_x].EERdPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].EERdScript);
                    binWrite.Write(DevFile.PartsList[l_x].EERdLocations);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDRdPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDRdScript);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigRdPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigRdScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemWrPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemWrScript);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemWrWords);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemPanelBufs);
                    binWrite.Write(DevFile.PartsList[l_x].ProgMemPanelOffset);
                    binWrite.Write(DevFile.PartsList[l_x].EEWrPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].EEWrScript);
                    binWrite.Write(DevFile.PartsList[l_x].EEWrLocations);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDWrPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].UserIDWrScript);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigWrPrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigWrScript);
                    binWrite.Write(DevFile.PartsList[l_x].OSCCALRdScript);
                    binWrite.Write(DevFile.PartsList[l_x].OSCCALWrScript);
                    binWrite.Write(DevFile.PartsList[l_x].DPMask);
                    binWrite.Write(DevFile.PartsList[l_x].WriteCfgOnErase);
                    binWrite.Write(DevFile.PartsList[l_x].BlankCheckSkipUsrIDs);
                    binWrite.Write(DevFile.PartsList[l_x].IgnoreBytes);
                    binWrite.Write(DevFile.PartsList[l_x].ChipErasePrepScript);
                    binWrite.Write(DevFile.PartsList[l_x].BootFlash);

                    binWrite.Write(DevFile.PartsList[l_x].Config9Mask);
                    binWrite.Write(DevFile.PartsList[l_x].Config9Blank);

                    //DevFile.PartsList[l_x].Config9Mask = binRead.ReadUInt16();
                    //DevFile.PartsList[l_x].ConfigMasks[8] = DevFile.PartsList[l_x].Config9Mask;
                    //DevFile.PartsList[l_x].Config9Blank = binRead.ReadUInt16();
                    //DevFile.PartsList[l_x].ConfigBlank[8] = DevFile.PartsList[l_x].Config9Blank;

                    binWrite.Write(DevFile.PartsList[l_x].ProgMemEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].EEMemEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].ConfigMemEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].reserved1EraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].reserved2EraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].TestMemoryRdScript);
                    binWrite.Write(DevFile.PartsList[l_x].TestMemoryRdWords);
                    binWrite.Write(DevFile.PartsList[l_x].EERowEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].EERowEraseWords);
                    binWrite.Write(DevFile.PartsList[l_x].ExportToMPLAB);
                    binWrite.Write(DevFile.PartsList[l_x].DebugHaltScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugRunScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugStatusScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReadExecVerScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugSingleStepScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugBulkWrDataScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugBulkRdDataScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugWriteVectorScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReadVectorScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugRowEraseScript);
                    binWrite.Write(DevFile.PartsList[l_x].DebugRowEraseSize);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReserved5Script);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReserved6Script);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReserved7Script);
                    binWrite.Write(DevFile.PartsList[l_x].DebugReserved8Script);
                    binWrite.Write(DevFile.PartsList[l_x].LVPScript);
                }
                //
                // now read all scripts if they are there
                //                    
                for (int l_x = 0; l_x < DevFile.Info.NumberScripts; l_x++)
                {
                    binWrite.Write(DevFile.Scripts[l_x].ScriptNumber);
                    binWrite.Write(DevFile.Scripts[l_x].ScriptName);
                    binWrite.Write(DevFile.Scripts[l_x].ScriptVersion);
                    binWrite.Write(DevFile.Scripts[l_x].UNUSED1);
                    binWrite.Write(DevFile.Scripts[l_x].ScriptLength);

                    // init script array
                    //DevFile.Scripts[l_x].Script = new ushort[DevFile.Scripts[l_x].ScriptLength];
                    for (int l_index = 0; l_index < DevFile.Scripts[l_x].ScriptLength; l_index++)
                    {
                        binWrite.Write(DevFile.Scripts[l_x].Script[l_index]);
                    }
                    binWrite.Write(DevFile.Scripts[l_x].Comment);
                }

                binWrite.Close();
            }
            fsDevFile.Close();
        }

    }
}
