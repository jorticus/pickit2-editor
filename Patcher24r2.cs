using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PICkit2V2;

namespace PicKit2_Script_Editor
{
    //TODO: Program data is repeated at 0x1000 and 0x2000 !!! (But only when using the programming executive)
    // Unsure if this is a problem with programming or reading.

    /// <summary>
    /// Provides functions to patch the device file to add new chips
    /// </summary>
    class Patcher24r2
    {
        public const string description = "This will additionally add extra scripts required for newer PIC24F devices. Select \"PIC24r2\" in the PicKit2 GUI.";

        public const string basePart = "PIC24FJ128GA106";

        // Supported families
        public static readonly FamilyTemplate PICFJ64 = new FamilyTemplate { programSize = 0x00ABFE, configAddr = 0x00ABF8 };
        public static readonly FamilyTemplate PICFJ128 = new FamilyTemplate { programSize = 0x0157FE, configAddr = 0x0157F8 };
        public static readonly FamilyTemplate PICFJ256 = new FamilyTemplate { programSize = 0x02ABFE, configAddr = 0x02ABF8 };

        // Supported devices
        public static readonly DeviceTemplate[] devices = { 
            new DeviceTemplate() { partName = "PIC24FJ128DA106", family = PICFJ128, deviceId = 0x4109 },
            new DeviceTemplate() { partName = "PIC24FJ256DA106", family = PICFJ256, deviceId = 0x410D },

            new DeviceTemplate() { partName = "PIC24FJ128DA110", family = PICFJ128, deviceId = 0x410B },
            new DeviceTemplate() { partName = "PIC24FJ256DA110", family = PICFJ256, deviceId = 0x410F },

            new DeviceTemplate() { partName = "PIC24FJ128DA206", family = PICFJ128, deviceId = 0x4108 },
            new DeviceTemplate() { partName = "PIC24FJ256DA206", family = PICFJ256, deviceId = 0x410C },

            new DeviceTemplate() { partName = "PIC24FJ128DA210", family = PICFJ128, deviceId = 0x410A },
            new DeviceTemplate() { partName = "PIC24FJ256DA210", family = PICFJ256, deviceId = 0x410E },

            new DeviceTemplate() { partName = "PIC24FJ64GA306", family = PICFJ64, deviceId = 0x46C0 },
            new DeviceTemplate() { partName = "PIC24FJ64GA308", family = PICFJ64, deviceId = 0x46C4 },
            new DeviceTemplate() { partName = "PIC24FJ64GA310", family = PICFJ64, deviceId = 0x46C8 },

            new DeviceTemplate() { partName = "PIC24FJ128GA306", family = PICFJ128, deviceId = 0x46C2 },
            new DeviceTemplate() { partName = "PIC24FJ128GA308", family = PICFJ128, deviceId = 0x46C6 },
            new DeviceTemplate() { partName = "PIC24FJ128GA310", family = PICFJ128, deviceId = 0x46CA },

            new DeviceTemplate() { partName = "PIC24FJ128GB206", family = PICFJ128, deviceId = 0x4100 },
            new DeviceTemplate() { partName = "PIC24FJ256GB206", family = PICFJ256, deviceId = 0x4104 },

            new DeviceTemplate() { partName = "PIC24FJ128GB210", family = PICFJ128, deviceId = 0x4102 },
            new DeviceTemplate() { partName = "PIC24FJ256GB210", family = PICFJ256, deviceId = 0x4106 },

            new DeviceTemplate() { partName = "PIC24FJ64GC006", family = PICFJ64, deviceId = 0x4888 },
            new DeviceTemplate() { partName = "PIC24FJ64GC008", family = PICFJ64, deviceId = 0x488A },
            new DeviceTemplate() { partName = "PIC24FJ64GC010", family = PICFJ64, deviceId = 0x4884 },

            new DeviceTemplate() { partName = "PIC24FJ128GC006", family = PICFJ128, deviceId = 0x4889 },
            new DeviceTemplate() { partName = "PIC24FJ128GC008", family = PICFJ128, deviceId = 0x488B },
            new DeviceTemplate() { partName = "PIC24FJ128GC010", family = PICFJ128, deviceId = 0x4885 },
        };

        public struct FamilyTemplate
        {
            public uint programSize;
            public uint configAddr;
        }
        public struct DeviceTemplate
        {
            public FamilyTemplate family;
            public string partName;
            public uint deviceId;
        }

        /// <summary>
        /// Patches the device file to add new PIC24r2 scripts and support
        /// for various devices. Note that "PIC24r2" is not an official name,
        /// I made it to distinguish it from the regular PIC24 chips since they
        /// seem to have changed stuff.
        /// </summary>
        /// <param name="DevFile">The device file to patch</param>
        public static void PatchDeviceFile(DeviceFile DevFile)
        {
            //// 1. Duplicate 24F scripts and patch ////

            // Skip the script patching if they've already been patched
            if (DevFile.Scripts.Where(s => s.ScriptName.StartsWith("24r2_")).Count() == 0)
            {
                // Get the PIC24 scripts
                var PIC24Scripts = DevFile.Scripts.Where(s => s.ScriptName.StartsWith("24_"));
                var newScripts = new List<DeviceFile.DeviceScripts>();
                ushort sidx = (ushort)DevFile.Scripts.Length;

                foreach (var script in PIC24Scripts)
                {
                    DeviceFile.DeviceScripts newScript = script;

                    // Rename and re-index
                    sidx++;
                    newScript.ScriptName = "24r2_" + newScript.ScriptName.Substring(3);
                    newScript.ScriptNumber = sidx;
                    newScript.Script = (ushort[])newScript.Script.Clone();

                    // Patch the opcodes:
                    // TBLPAG address has changed from 0x32 to 0x54
                    // eg. MOV W0, TBLPAG instruction has changed from 0x880190 to 0x8802A0
                    List<DeviceFile.Opcode> opcodes = newScript.ParseScript();

                    foreach (DeviceFile.Opcode opcode in opcodes)
                    {
                        if ((OPCODES)opcode.opcode == OPCODES._COREINST24)
                        {
                            uint operand = (uint)(((uint)opcode.data[0] << 16) | ((uint)opcode.data[1] << 8) | opcode.data[2]);

                            // MOV W0, TBLPAG
                            // 88 01 90 -> 99 02 A0
                            if (operand == 0x880190)
                            {
                                int idx = opcode.index;

                                newScript.Script[idx + 2] = (ushort)((newScript.Script[idx + 2] & 0xFF00) | 0x02);
                                newScript.Script[idx + 1] = (ushort)((newScript.Script[idx + 1] & 0xFF00) | 0xA0);
                            }
                        }
                    }

                    newScripts.Add(newScript);
                }

                // Update DeviceFile
                DevFile.Scripts = DevFile.Scripts.Concat(newScripts).ToArray();
                DevFile.Info.NumberScripts += newScripts.Count;
            }

            //// 2. Add new PIC24 family ////
            if (DevFile.Families.Where(f => f.FamilyName == "PIC24r2").Count() == 0)
            {
                var PIC24Family = DevFile.Families.First(f => f.FamilyName == "PIC24");

                DeviceFile.DeviceFamilyParams newFamily = PIC24Family;
                newFamily.FamilyName = "PIC24r2";
                newFamily.FamilyID = (ushort)DevFile.Families.Length;
                newFamily.FamilyType = newFamily.FamilyID;

                // Assign new scripts
                newFamily.ProgEntryScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_ProgEntry.1").ScriptNumber;
                newFamily.ReadDevIDScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_RdDevID.1").ScriptNumber;

                // Update DeviceFile
                DevFile.Families = DevFile.Families.Concat(new DeviceFile.DeviceFamilyParams[1] { newFamily }).ToArray();
                DevFile.Info.NumberFamilies++;
            }

            //// 3. Add new PIC24 chips ////
            var newParts = new List<DeviceFile.DevicePartParams>();

            foreach (var dev in devices)
            {
                // Make sure the chip doesn't already exist
                if (DevFile.PartsList.Where(p => p.PartName == dev.partName).Count() == 0)
                {
                    // Add a chip by template
                    newParts.Add(NewPart24r2(DevFile, basePart, dev.partName, dev));
                }
            }

            DevFile.PartsList = DevFile.PartsList.Concat(newParts).ToArray();
            DevFile.Info.NumberParts += newParts.Count;

        }

        public static DeviceFile.DevicePartParams NewPart24r2(DeviceFile DevFile, string basePartName, string partName, DeviceTemplate template)
        {
            DeviceFile.DevicePartParams newPart = DevFile.PartsList.First(p => p.PartName == basePartName);

            // These can be easily found from the family programmer's manual
            newPart.PartName = partName;
            newPart.DeviceID = template.deviceId;
            newPart.ProgramMem = template.family.programSize / 2 + 1;   // Size of program FLASH. Not sure what units this is
            newPart.ConfigAddr = template.family.configAddr * 2;        // Address of the highest config register (ie. CONFIG4)
            newPart.ConfigWords = 4;                                    // Number of config registers

            // Mask out unused bits. 
            // This can be found in the PIC datasheet. Reserved bits should be masked out.
            // Configuration registers are in reverse order, ie. { CONFIG4, CONFIG3, CONFIG2, CONFIG1 }, with the CONFIG4 at the LOWEST address.
            newPart.ConfigMasks = new ushort[8] { 0x0000, 0xFFFF, 0xFFF3, 0x7BFF, 0, 0, 0, 0 };
            newPart.ConfigBlank = new ushort[8] { 0xFFFF, 0xFFFF, 0xFFF3, 0x7BFF, 0, 0, 0, 0 }; // Default configuration (Check the datasheet to see what the reserved bits should be set to)
            //NOTE: Above only tested with PIC24FJ256DA206.

            // Code-protect detection (only used in PicKit2 GUI?)
            newPart.CPConfig = 4;       // Which config contains the code-protect bits. This corresponds to CONFIG1
            newPart.CPMask = 0x3000;    // There are two CP-config bits, if either are 0 then CP is active.

            // PIC Family
            newPart.Family = DevFile.Families.First(f => f.FamilyName == "PIC24r2").FamilyID;

            // Update scripts to PIC24r2
            newPart.ChipEraseScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_ChpErase450ms.1").ScriptNumber;
            newPart.ProgMemAddrSetScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_SetAddr.1").ScriptNumber;
            newPart.ProgMemRdScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_ProgMemRd32.1").ScriptNumber;
            newPart.ProgMemWrPrepScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_ProgMemWrPrep.1").ScriptNumber;
            newPart.ProgMemWrScript = DevFile.Scripts.First(s => s.ScriptName == "24r2_ProgMemWr64.1").ScriptNumber;

            return newPart;
        }

    }
}
