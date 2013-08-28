using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicKit2_Script_Editor
{
    /// <summary>
    /// Parses _COREINST24 script codes, also attempts some disassembly.
    /// </summary>
    class CoreInst24
    {
        public byte opcode;
        public byte[] data;

        public static string ParseCoreInst24(byte opcode, byte[] data)
        {
            CoreInst24 inst = new CoreInst24() { opcode = opcode, data = data };
            return inst.Parse();
        }

        // file register (NVMCON, etc.)
        public string ParseF(uint f)
        {
            f = f & 0x0FFF;
            // Add known file registers here. Unknown ones will just show the hexadecimal code.
            switch (f)
            {
                case 0x3B0: return "NVMCON";
                case 0x019: return "TBLPAG";
                case 0x02A: return "TBLPAG-r2";
            }

            return string.Format("0x{0:X3}", f);
        }

        // literal
        public string ParseLit(uint lit)
        {
            return string.Format("0x{0:X4}", lit & 0xFFFF);
        }

        public string ParseWReg(uint reg, uint addr = 0x0)
        {
            addr = (byte)(addr & 0x7);
            string fmt = "W{0}";
            switch (addr)
            {
                //case 0x0: fmt = "W{0}"; break;      // Register direct
                case 0x1: fmt = "[W{0}]"; break;    // Indirect
                case 0x2: fmt = "[W{0}--]"; break;  // Indirect post-dec
                case 0x3: fmt = "[W{0}++]"; break;  // Indirect post-inc
                case 0x4: fmt = "[--W{0}]"; break;  // Indirect pre-dec
                case 0x5: fmt = "[++W{0}]"; break;  // Indirect pre-inc
            }
            return string.Format(fmt, reg);
        }

        // working register addressed mode ([Wd], [Wd++], Wd, etc.)
        /*public string ParseWRegAddr(byte ppp, string reg)
        {

        }*/

        // other data
        public string ParseData()
        {
            if (data.Length == 1) return string.Format("0x{0:X2}", data[0]);
            if (data.Length == 2) return string.Format("0x{0:X4}", data[0] << 8 | data[1]);

            string s = "";
            for (int i=0; i<data.Length; i++)
                s += " " + string.Format("{0:X2}", data[i]);
            return s;
        }

        public string ParseByteMode(uint operand)
        {
            return ((operand & 0x4000) == 0x4000) ? ".B" : "";
        }
        public string ParseDest(uint operand, string f = "f")
        {
            return ((operand & 0x2000) == 0x2000) ? f : "WREG";
        }




        public string ParseMOV(uint operand)
        {
            // NOTE: I've only added MOV instructions that have actually appeared
            //       in the scripts I am interested in inspecting.


            // Move f to dest:  1011 1111 1BDf ffff ffff ffff  : MOV.B TMR0, WREG
            if ((operand & 0xFF8000) == 0xBF8000) return string.Format("MOV{0} {1}, {2}", 
                ParseByteMode(operand),         // 'B'
                ParseF(operand & 0x1FFF),       // 'f'
                ParseDest(operand)          // 'D'
            );

            // Move WREG to f:  1011 0111 1B1f ffff ffff ffff  : 
            if ((operand & 0xFFA000) == 0xBF8000) return string.Format("MOV");

            // Move f to Wnd:   1000 0fff ffff ffff ffff dddd
            if ((operand & 0xFF8000) == 0xB7A000) return string.Format("MOV");

            // Move Wns to f:   1000 1fff ffff ffff ffff ssss  : MOV W4, XMDOSRT
            if ((operand & 0xF80000) == 0x880000) return string.Format("MOV {0}, {1}",
                ParseWReg((byte)(operand & 0xF)),
                ParseF((operand & 0x7FFF0) >> 4)
            );

            // Move 8-bit lit to Wnd:       1011 0011 1100 kkkk kkkk dddd
            if ((operand & 0xFFF000) == 0xB3C000) return string.Format("MOV");

            // Move 16-bit lit to Wnd:      0010 kkkk kkkk kkkk kkkk dddd
            if ((operand & 0xF00000) == 0x200000) return string.Format("MOV #0x{0:X4}, W{1}", 
                (operand & 0xFFFF0) >> 4, 
                (operand & 0xF)
            );

            // Move [Ws + offset] to Wnd:   1001 0kkk kBkk kddd dkkk ssss
            if ((operand & 0xF80000) == 0x900000) return string.Format("MOV");

            // Move Wns to [Wd + offset]:   1001 1kkk kBkk kddd dkkk ssss
            if ((operand & 0xF80000) == 0x980000) return string.Format("MOV");

            // Move Ws to Wd:               0111 1www wBhh hddd dggg ssss
            if ((operand & 0xF80000) == 0x780000) return string.Format("MOV");

            // Double word move from src to Wnd: 1011 1110 0000 0ddd 0ppp ssss
            if ((operand & 0xFFF880) == 0xBE0000) return string.Format("MOV");

            return null;
        }

        public string ParseBSET(uint operand)
        {
            return null;
        }

        public string ParseTBL(uint operand)
        {
            //TBLRDH : 1011 1010 1Bqq qddd dppp ssss
            if ((operand & 0xFF8000) == 0xBA8000) return string.Format("TBLRDH{0} {1}, {2}",
                ParseByteMode(operand),
                ParseWReg((operand & 0xF), (operand & 0x70) >> 4),
                ParseWReg((operand & 0x780) >> 7, (operand & 0x3800) >> 11)
            );

            //TBLRDL : 1011 1010 0Bqq qddd dppp ssss
            if ((operand & 0xFF8000) == 0xBA0000) return string.Format("TBLRDL{0} {1}, {2}",
                ParseByteMode(operand),
                ParseWReg((operand & 0xF), (operand & 0x70) >> 4),
                ParseWReg((operand & 0x780) >> 7, (operand & 0x3800) >> 11)
            );

            //TBLWTH : 1011 1011 1Bqq qddd dppp ssss
            if ((operand & 0xFF8000) == 0xBB8000) return string.Format("TBLWTH{0} {1}, {2}",
                ParseByteMode(operand),
                ParseWReg((operand & 0xF), (operand & 0x70) >> 4),
                ParseWReg((operand & 0x780) >> 7, (operand & 0x3800) >> 11)
            );

            //TBLWTL : 1011 1011 0Bqq qddd dppp ssss
            if ((operand & 0xFF8000) == 0xBB0000) return string.Format("TBLWTL{0} {1}, {2}",
                ParseByteMode(operand),
                ParseWReg((operand & 0xF), (operand & 0x70) >> 4),
                ParseWReg((operand & 0x780) >> 7, (operand & 0x3800) >> 11)
            );


            return null;
        }

        // From the "16-bit MCU and DSC Programmers Reference Card"
        // Page 359 Instruction Encoding
        public string Parse()
        {
            // Useful instructions:
            // NOP, GOTO, TBLWTL, TBLWTH, BSET, CLR

            uint operand = (uint)(((uint)opcode << 16) | ((uint)data[0] << 8) | data[1]);
            string s = null;
            //ushort operand = (ushort)(data[0] << 8 | data[1]);

            // MOV
            s = ParseMOV(operand);
            if (s != null) return s;

            // BSET
            s = ParseBSET(operand);
            if (s != null) return s;

            // TBLWT/TBLRD
            s = ParseTBL(operand);
            if (s != null) return s;

            // CLR : Clear f or WREG
            if ((operand & 0xFF8000) == 0xEF0000) return string.Format("CLR{0} {1}",
                ParseByteMode(operand),
                ParseDest(operand, ParseF(operand & 0x1FFF))
            );


            if (opcode == 0x00) return "NOP";
            if (opcode == 0x01) return "BRA " + ParseData(); // BRA/CALL/GOTO/RCALL
            if (opcode == 0x02) return "CALL " + ParseData();
            if (opcode == 0x04) return "GOTO " + ParseData();
            if (opcode == 0x05) return "RETLW " + ParseData();
            if (opcode == 0x06) return "RETFIE ";
            if (opcode == 0x07) return "RCALL " + ParseData();
            if (opcode == 0x08) return "DO " + ParseData();
            if (opcode == 0x09) return "REPEAT " + ParseData();
            //if ((opcode & 0x0C) != 0) return "BRA " + ParseData();

            return string.Format("?? 0x{0:X2} ", opcode) + ParseData();
        }
    }
}
