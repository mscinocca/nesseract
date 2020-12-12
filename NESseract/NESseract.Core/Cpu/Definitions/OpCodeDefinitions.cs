using System.Collections.Generic;

namespace NESseract.Core.Cpu.Definitions
{
   public static class OpCodeDefinitions
   {
      public static readonly List<OpCodeDefinition> OpCodeList;

      static OpCodeDefinitions()
      {
         OpCodeList = new List<OpCodeDefinition>
         {
            // ADC
            new OpCodeDefinition(0x69, OpCode.ADC, AddressingMode.IMM, 2, 2, false, "NVZC"),
            new OpCodeDefinition(0x65, OpCode.ADC, AddressingMode.ZP0, 2, 3, false, "NVZC"),
            new OpCodeDefinition(0x75, OpCode.ADC, AddressingMode.ZPX, 2, 4, false, "NVZC"),
            new OpCodeDefinition(0x6D, OpCode.ADC, AddressingMode.ABS, 3, 4, false, "NVZC"),
            new OpCodeDefinition(0x7D, OpCode.ADC, AddressingMode.ABX, 3, 4, true,  "NVZC"),
            new OpCodeDefinition(0x79, OpCode.ADC, AddressingMode.ABY, 3, 4, true,  "NVZC"),
            new OpCodeDefinition(0x61, OpCode.ADC, AddressingMode.IDX, 2, 6, false, "NVZC"),
            new OpCodeDefinition(0x71, OpCode.ADC, AddressingMode.IDY, 2, 5, true,  "NVZC"),

            // AND
            new OpCodeDefinition(0x29, OpCode.AND, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0x25, OpCode.AND, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0x35, OpCode.AND, AddressingMode.ZPX, 2, 4, false, "NZ"),
            new OpCodeDefinition(0x2D, OpCode.AND, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0x3D, OpCode.AND, AddressingMode.ABX, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x39, OpCode.AND, AddressingMode.ABY, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x21, OpCode.AND, AddressingMode.IDX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0x31, OpCode.AND, AddressingMode.IDY, 2, 5, true,  "NZ"),

            // ASL
            new OpCodeDefinition(0x0A, OpCode.ASL, AddressingMode.ACC, 1, 2, false, "NZC"),
            new OpCodeDefinition(0x06, OpCode.ASL, AddressingMode.ZP0, 2, 5, false, "NZC"),
            new OpCodeDefinition(0x16, OpCode.ASL, AddressingMode.ZPX, 2, 6, false, "NZC"),
            new OpCodeDefinition(0x0E, OpCode.ASL, AddressingMode.ABS, 3, 6, false, "NZC"),
            new OpCodeDefinition(0x1E, OpCode.ASL, AddressingMode.ABX, 3, 7, false, "NZC"),

            // BIT
            new OpCodeDefinition(0x24, OpCode.BIT, AddressingMode.ZP0, 2, 3, false, "NVZ"),
            new OpCodeDefinition(0x2C, OpCode.BIT, AddressingMode.ABS, 3, 4, false, "NVZ"),

            // Branch Instructions
            new OpCodeDefinition(0x10, OpCode.BPL, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0x30, OpCode.BMI, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0x50, OpCode.BVC, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0x70, OpCode.BVS, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0x90, OpCode.BCC, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0xB0, OpCode.BCS, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0xD0, OpCode.BNE, AddressingMode.REL, 2, 2, true,  ""),
            new OpCodeDefinition(0xF0, OpCode.BEQ, AddressingMode.REL, 2, 2, true,  ""),

            // BRK
            new OpCodeDefinition(0x00, OpCode.BRK, AddressingMode.IMP, 1, 7, false, "B"),

            // CMP
            new OpCodeDefinition(0xC9, OpCode.CMP, AddressingMode.IMM, 2, 2, false, "NZC"),
            new OpCodeDefinition(0xC5, OpCode.CMP, AddressingMode.ZP0, 2, 3, false, "NZC"),
            new OpCodeDefinition(0xD5, OpCode.CMP, AddressingMode.ZPX, 2, 4, false, "NZC"),
            new OpCodeDefinition(0xCD, OpCode.CMP, AddressingMode.ABS, 3, 4, false, "NZC"),
            new OpCodeDefinition(0xDD, OpCode.CMP, AddressingMode.ABX, 3, 4, true,  "NZC"),
            new OpCodeDefinition(0xD9, OpCode.CMP, AddressingMode.ABY, 3, 4, true,  "NZC"),
            new OpCodeDefinition(0xC1, OpCode.CMP, AddressingMode.IDX, 2, 6, false, "NZC"),
            new OpCodeDefinition(0xD1, OpCode.CMP, AddressingMode.IDY, 2, 5, true,  "NZC"),

            // CPX
            new OpCodeDefinition(0xE0, OpCode.CPX, AddressingMode.IMM, 2, 2, false, "NZC"),
            new OpCodeDefinition(0xE4, OpCode.CPX, AddressingMode.ZP0, 2, 3, false, "NZC"),
            new OpCodeDefinition(0xEC, OpCode.CPX, AddressingMode.ABS, 3, 4, false, "NZC"),

            // CPY
            new OpCodeDefinition(0xC0, OpCode.CPY, AddressingMode.IMM, 2, 2, false, "NZC"),
            new OpCodeDefinition(0xC4, OpCode.CPY, AddressingMode.ZP0, 2, 3, false, "NZC"),
            new OpCodeDefinition(0xCC, OpCode.CPY, AddressingMode.ABS, 3, 4, false, "NZC"),

            // DEC
            new OpCodeDefinition(0xC6, OpCode.DEC, AddressingMode.ZP0, 2, 5, false, "NZ"),
            new OpCodeDefinition(0xD6, OpCode.DEC, AddressingMode.ZPX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0xCE, OpCode.DEC, AddressingMode.ABS, 3, 6, false, "NZ"),
            new OpCodeDefinition(0xDE, OpCode.DEC, AddressingMode.ABX, 3, 7, false, "NZ"),

            // EOR
            new OpCodeDefinition(0x49, OpCode.EOR, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0x45, OpCode.EOR, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0x55, OpCode.EOR, AddressingMode.ZPX, 2, 4, false, "NZ"),
            new OpCodeDefinition(0x4D, OpCode.EOR, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0x5D, OpCode.EOR, AddressingMode.ABX, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x59, OpCode.EOR, AddressingMode.ABY, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x41, OpCode.EOR, AddressingMode.IDX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0x51, OpCode.EOR, AddressingMode.IDY, 2, 5, true,  "NZ"),

            // Flag Instructions (Processor Status)
            new OpCodeDefinition(0x18, OpCode.CLC, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0x38, OpCode.SEC, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0x58, OpCode.CLI, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0x78, OpCode.SEI, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0xB8, OpCode.CLV, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0xD8, OpCode.CLD, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0xF8, OpCode.SED, AddressingMode.NON, 1, 2, false, ""),

            // INC
            new OpCodeDefinition(0xE6, OpCode.INC, AddressingMode.ZP0, 2, 5, false, "NZ"),
            new OpCodeDefinition(0xF6, OpCode.INC, AddressingMode.ZPX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0xEE, OpCode.INC, AddressingMode.ABS, 3, 6, false, "NZ"),
            new OpCodeDefinition(0xFE, OpCode.INC, AddressingMode.ABX, 3, 7, false, "NZ"),

            // JMP
            new OpCodeDefinition(0x4C, OpCode.JMP, AddressingMode.ABS, 3, 3, false, ""),
            new OpCodeDefinition(0x6C, OpCode.JMP, AddressingMode.IND, 3, 5, false, ""),

            // JSR
            new OpCodeDefinition(0x20, OpCode.JSR, AddressingMode.ABS, 3, 6, false, ""),

            // LDA
            new OpCodeDefinition(0xA9, OpCode.LDA, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0xA5, OpCode.LDA, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0xB5, OpCode.LDA, AddressingMode.ZPX, 2, 4, false, "NZ"),
            new OpCodeDefinition(0xAD, OpCode.LDA, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0xBD, OpCode.LDA, AddressingMode.ABX, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0xB9, OpCode.LDA, AddressingMode.ABY, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0xA1, OpCode.LDA, AddressingMode.IDX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0xB1, OpCode.LDA, AddressingMode.IDY, 2, 5, true,  "NZ"),

            // LDX
            new OpCodeDefinition(0xA2, OpCode.LDX, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0xA6, OpCode.LDX, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0xB6, OpCode.LDX, AddressingMode.ZPY, 2, 4, false, "NZ"),
            new OpCodeDefinition(0xAE, OpCode.LDX, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0xBE, OpCode.LDX, AddressingMode.ABY, 3, 4, true,  "NZ"),

            // LDY
            new OpCodeDefinition(0xA0, OpCode.LDY, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0xA4, OpCode.LDY, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0xB4, OpCode.LDY, AddressingMode.ZPX, 2, 4, false, "NZ"),
            new OpCodeDefinition(0xAC, OpCode.LDY, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0xBC, OpCode.LDY, AddressingMode.ABX, 3, 4, true,  "NZ"),

            // LSR
            new OpCodeDefinition(0x4A, OpCode.LSR, AddressingMode.ACC, 1, 2, false, "NZ"),
            new OpCodeDefinition(0x46, OpCode.LSR, AddressingMode.ZP0, 2, 5, false, "NZ"),
            new OpCodeDefinition(0x56, OpCode.LSR, AddressingMode.ZPX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0x4E, OpCode.LSR, AddressingMode.ABS, 3, 6, false, "NZ"),
            new OpCodeDefinition(0x5E, OpCode.LSR, AddressingMode.ABX, 3, 7, false, "NZ"),

            // NOP
            new OpCodeDefinition(0xEA, OpCode.NOP, AddressingMode.IMP, 1, 2, false, ""),

            // ORA
            new OpCodeDefinition(0x09, OpCode.ORA, AddressingMode.IMM, 2, 2, false, "NZ"),
            new OpCodeDefinition(0x05, OpCode.ORA, AddressingMode.ZP0, 2, 3, false, "NZ"),
            new OpCodeDefinition(0x15, OpCode.ORA, AddressingMode.ZPX, 2, 4, false, "NZ"),
            new OpCodeDefinition(0x0D, OpCode.ORA, AddressingMode.ABS, 3, 4, false, "NZ"),
            new OpCodeDefinition(0x1D, OpCode.ORA, AddressingMode.ABX, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x19, OpCode.ORA, AddressingMode.ABY, 3, 4, true,  "NZ"),
            new OpCodeDefinition(0x01, OpCode.ORA, AddressingMode.IDX, 2, 6, false, "NZ"),
            new OpCodeDefinition(0x11, OpCode.ORA, AddressingMode.IDY, 2, 5, true,  "NZ"),

            // Register Instructions
            new OpCodeDefinition(0xAA, OpCode.TAX, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0x8A, OpCode.TXA, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0xCA, OpCode.DEX, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0xE8, OpCode.INX, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0xA8, OpCode.TAY, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0x98, OpCode.TYA, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0x88, OpCode.DEY, AddressingMode.NON, 1, 2, false, "NZ"),
            new OpCodeDefinition(0xC8, OpCode.INY, AddressingMode.NON, 1, 2, false, "NZ"),

            // ROL
            new OpCodeDefinition(0x2A, OpCode.ROL, AddressingMode.ACC, 1, 2, false, "NZC"),
            new OpCodeDefinition(0x26, OpCode.ROL, AddressingMode.ZP0, 2, 5, false, "NZC"),
            new OpCodeDefinition(0x36, OpCode.ROL, AddressingMode.ZPX, 2, 6, false, "NZC"),
            new OpCodeDefinition(0x2E, OpCode.ROL, AddressingMode.ABS, 3, 6, false, "NZC"),
            new OpCodeDefinition(0x3E, OpCode.ROL, AddressingMode.ABX, 3, 7, false, "NZC"),

            // ROR
            new OpCodeDefinition(0x6A, OpCode.ROR, AddressingMode.ACC, 1, 2, false, "NZC"),
            new OpCodeDefinition(0x66, OpCode.ROR, AddressingMode.ZP0, 2, 5, false, "NZC"),
            new OpCodeDefinition(0x76, OpCode.ROR, AddressingMode.ZPX, 2, 6, false, "NZC"),
            new OpCodeDefinition(0x6E, OpCode.ROR, AddressingMode.ABS, 3, 6, false, "NZC"),
            new OpCodeDefinition(0x7E, OpCode.ROR, AddressingMode.ABX, 3, 7, false, "NZC"),

            // RTI
            new OpCodeDefinition(0x40, OpCode.RTI, AddressingMode.IMP, 1, 6, false, "NVBDIZC"),

            // RTS
            new OpCodeDefinition(0x60, OpCode.RTS, AddressingMode.IMP, 1, 6, false, ""),

            // SBC
            new OpCodeDefinition(0xE9, OpCode.SBC, AddressingMode.IMM, 2, 2, false, "NVZC"),
            new OpCodeDefinition(0xE5, OpCode.SBC, AddressingMode.ZP0, 2, 3, false, "NVZC"),
            new OpCodeDefinition(0xF5, OpCode.SBC, AddressingMode.ZPX, 2, 4, false, "NVZC"),
            new OpCodeDefinition(0xED, OpCode.SBC, AddressingMode.ABS, 3, 4, false, "NVZC"),
            new OpCodeDefinition(0xFD, OpCode.SBC, AddressingMode.ABX, 3, 4, true,  "NVZC"),
            new OpCodeDefinition(0xF9, OpCode.SBC, AddressingMode.ABY, 3, 4, true,  "NVZC"),
            new OpCodeDefinition(0xE1, OpCode.SBC, AddressingMode.IDX, 2, 6, false, "NVZC"),
            new OpCodeDefinition(0xF1, OpCode.SBC, AddressingMode.IDY, 2, 5, true,  "NVZC"),

            // STA
            new OpCodeDefinition(0x85, OpCode.STA, AddressingMode.ZP0, 2, 3, false, ""),
            new OpCodeDefinition(0x95, OpCode.STA, AddressingMode.ZPX, 2, 4, false, ""),
            new OpCodeDefinition(0x8D, OpCode.STA, AddressingMode.ABS, 3, 4, false, ""),
            new OpCodeDefinition(0x9D, OpCode.STA, AddressingMode.ABX, 3, 5, false, ""),
            new OpCodeDefinition(0x99, OpCode.STA, AddressingMode.ABY, 3, 5, false, ""),
            new OpCodeDefinition(0x81, OpCode.STA, AddressingMode.IDX, 2, 6, false, ""),
            new OpCodeDefinition(0x91, OpCode.STA, AddressingMode.IDY, 2, 6, false, ""),

            // Stack Instructions
            new OpCodeDefinition(0x9A, OpCode.TXS, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0xBA, OpCode.TSX, AddressingMode.NON, 1, 2, false, ""),
            new OpCodeDefinition(0x48, OpCode.PHA, AddressingMode.NON, 1, 3, false, ""),
            new OpCodeDefinition(0x68, OpCode.PLA, AddressingMode.NON, 1, 4, false, ""),
            new OpCodeDefinition(0x08, OpCode.PHP, AddressingMode.NON, 1, 3, false, ""),
            new OpCodeDefinition(0x28, OpCode.PLP, AddressingMode.NON, 1, 4, false, ""),

            // STX
            new OpCodeDefinition(0x86, OpCode.STX, AddressingMode.ZP0, 2, 3, false, ""),
            new OpCodeDefinition(0x96, OpCode.STX, AddressingMode.ZPY, 2, 4, false, ""),
            new OpCodeDefinition(0x8E, OpCode.STX, AddressingMode.ABS, 3, 4, false, ""),

            // STY
            new OpCodeDefinition(0x84, OpCode.STY, AddressingMode.ZP0, 2, 3, false, ""),
            new OpCodeDefinition(0x94, OpCode.STY, AddressingMode.ZPX, 2, 4, false, ""),
            new OpCodeDefinition(0x8C, OpCode.STY, AddressingMode.ABS, 3, 4, false, ""),
         };
      }
   }
}
