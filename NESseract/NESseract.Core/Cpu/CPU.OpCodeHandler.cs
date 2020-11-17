using NESseract.Core.Cpu.Definitions;
using System.Collections.Generic;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      private List<OpCodeDefinition> opCodeDefinitions;

      private Dictionary<byte, OpCodeDefinition> opCodeTable;

      private void InitializeOpCodeDefinitions()
      {
         opCodeDefinitions = new List<OpCodeDefinition>
         {
            // ADC
            new OpCodeDefinition(0x69, OpCodes.ADC, AddressingModes.IMM, 2, 2, "NVZC"),
            new OpCodeDefinition(0x65, OpCodes.ADC, AddressingModes.ZP0, 2, 3, "NVZC"),
            new OpCodeDefinition(0x75, OpCodes.ADC, AddressingModes.ZPX, 2, 4, "NVZC"),
            new OpCodeDefinition(0x6D, OpCodes.ADC, AddressingModes.ABS, 3, 4, "NVZC"),
            new OpCodeDefinition(0x7D, OpCodes.ADC, AddressingModes.ABX, 3, 4, "NVZC"),
            new OpCodeDefinition(0x79, OpCodes.ADC, AddressingModes.ABY, 3, 4, "NVZC"),
            new OpCodeDefinition(0x61, OpCodes.ADC, AddressingModes.IDX, 2, 6, "NVZC"),
            new OpCodeDefinition(0x71, OpCodes.ADC, AddressingModes.IDY, 2, 5, "NVZC"),

            // AND
            new OpCodeDefinition(0x29, OpCodes.AND, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0x25, OpCodes.AND, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0x35, OpCodes.AND, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0x2D, OpCodes.AND, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0x3D, OpCodes.AND, AddressingModes.ABX, 3, 4, "NZ"),
            new OpCodeDefinition(0x39, OpCodes.AND, AddressingModes.ABY, 3, 4, "NZ"),
            new OpCodeDefinition(0x21, OpCodes.AND, AddressingModes.IDX, 2, 6, "NZ"),
            new OpCodeDefinition(0x31, OpCodes.AND, AddressingModes.IDY, 2, 5, "NZ"),

            // ASL
            new OpCodeDefinition(0x0A, OpCodes.ASL, AddressingModes.ACC, 1, 2, "NZC"),
            new OpCodeDefinition(0x06, OpCodes.ASL, AddressingModes.ZP0, 2, 5, "NZC"),
            new OpCodeDefinition(0x16, OpCodes.ASL, AddressingModes.ZPX, 2, 6, "NZC"),
            new OpCodeDefinition(0x0E, OpCodes.ASL, AddressingModes.ABS, 3, 6, "NZC"),
            new OpCodeDefinition(0x1E, OpCodes.ASL, AddressingModes.ABX, 3, 7, "NZC"),

            // BIT
            new OpCodeDefinition(0x24, OpCodes.BIT, AddressingModes.ZP0, 2, 3, "NVZ"),
            new OpCodeDefinition(0x2C, OpCodes.BIT, AddressingModes.ABS, 3, 4, "NVZ"),

            // Branch Instructions
            new OpCodeDefinition(0x10, OpCodes.BPL, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0x30, OpCodes.BMI, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0x50, OpCodes.BVC, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0x70, OpCodes.BVS, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0x90, OpCodes.BCC, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0xB0, OpCodes.BCS, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0xD0, OpCodes.BNE, AddressingModes.NON, 2, 2, ""),
            new OpCodeDefinition(0xF0, OpCodes.BEQ, AddressingModes.NON, 2, 2, ""),

            // BRK
            new OpCodeDefinition(0x00, OpCodes.BRK, AddressingModes.IMP, 1, 7, "B"),

            // CMP
            new OpCodeDefinition(0xC9, OpCodes.CMP, AddressingModes.IMM, 2, 2, "NZC"),
            new OpCodeDefinition(0xC5, OpCodes.CMP, AddressingModes.ZP0, 2, 3, "NZC"),
            new OpCodeDefinition(0xD5, OpCodes.CMP, AddressingModes.ZPX, 2, 4, "NZC"),
            new OpCodeDefinition(0xCD, OpCodes.CMP, AddressingModes.ABS, 3, 4, "NZC"),
            new OpCodeDefinition(0xDD, OpCodes.CMP, AddressingModes.ABX, 3, 4, "NZC"),
            new OpCodeDefinition(0xD9, OpCodes.CMP, AddressingModes.ABY, 3, 4, "NZC"),
            new OpCodeDefinition(0xC1, OpCodes.CMP, AddressingModes.IDX, 2, 6, "NZC"),
            new OpCodeDefinition(0xD1, OpCodes.CMP, AddressingModes.IDY, 2, 5, "NZC"),

            // CPX
            new OpCodeDefinition(0xE0, OpCodes.CPX, AddressingModes.IMM, 2, 2, "NZC"),
            new OpCodeDefinition(0xE4, OpCodes.CPX, AddressingModes.ZP0, 2, 3, "NZC"),
            new OpCodeDefinition(0xEC, OpCodes.CPX, AddressingModes.ABS, 3, 4, "NZC"),

            // CPY
            new OpCodeDefinition(0xC0, OpCodes.CPY, AddressingModes.IMM, 2, 2, "NZC"),
            new OpCodeDefinition(0xC4, OpCodes.CPY, AddressingModes.ZP0, 2, 3, "NZC"),
            new OpCodeDefinition(0xCC, OpCodes.CPY, AddressingModes.ABS, 3, 4, "NZC"),

            // DEC
            new OpCodeDefinition(0xC6, OpCodes.DEC, AddressingModes.ZP0, 2, 5, "NZ"),
            new OpCodeDefinition(0xD6, OpCodes.DEC, AddressingModes.ZPX, 2, 6, "NZ"),
            new OpCodeDefinition(0xCE, OpCodes.DEC, AddressingModes.ABS, 3, 6, "NZ"),
            new OpCodeDefinition(0xDE, OpCodes.DEC, AddressingModes.ABX, 3, 7, "NZ"),

            // EOR
            new OpCodeDefinition(0x49, OpCodes.EOR, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0x45, OpCodes.EOR, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0x55, OpCodes.EOR, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0x4D, OpCodes.EOR, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0x5D, OpCodes.EOR, AddressingModes.ABX, 3, 4, "NZ"),
            new OpCodeDefinition(0x59, OpCodes.EOR, AddressingModes.ABY, 3, 4, "NZ"),
            new OpCodeDefinition(0x41, OpCodes.EOR, AddressingModes.IDX, 2, 6, "NZ"),
            new OpCodeDefinition(0x51, OpCodes.EOR, AddressingModes.IDY, 2, 5, "NZ"),

            // Flag Instructions (Processor Status)
            new OpCodeDefinition(0x18, OpCodes.CLC, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0x38, OpCodes.SEC, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0x58, OpCodes.CLI, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0x78, OpCodes.SEI, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0xB8, OpCodes.CLV, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0xD8, OpCodes.CLD, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0xF8, OpCodes.SED, AddressingModes.NON, 1, 2, ""),

            // INC
            new OpCodeDefinition(0xE6, OpCodes.INC, AddressingModes.ZP0, 2, 5, "NZ"),
            new OpCodeDefinition(0xF6, OpCodes.INC, AddressingModes.ZPX, 2, 6, "NZ"),
            new OpCodeDefinition(0xEE, OpCodes.INC, AddressingModes.ABS, 3, 6, "NZ"),
            new OpCodeDefinition(0xFE, OpCodes.INC, AddressingModes.ABX, 3, 7, "NZ"),

            // JMP
            new OpCodeDefinition(0x4C, OpCodes.JMP, AddressingModes.ABS, 3, 3, ""),
            new OpCodeDefinition(0x6C, OpCodes.JMP, AddressingModes.IND, 3, 5, ""),

            // JSR
            new OpCodeDefinition(0x20, OpCodes.JSR, AddressingModes.ABS, 3, 6, ""),

            // LDA
            new OpCodeDefinition(0xA9, OpCodes.LDA, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0xA5, OpCodes.LDA, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0xB5, OpCodes.LDA, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0xAD, OpCodes.LDA, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0xBD, OpCodes.LDA, AddressingModes.ABX, 3, 4, "NZ"),
            new OpCodeDefinition(0xB9, OpCodes.LDA, AddressingModes.ABY, 3, 4, "NZ"),
            new OpCodeDefinition(0xA1, OpCodes.LDA, AddressingModes.IDX, 2, 6, "NZ"),
            new OpCodeDefinition(0xB1, OpCodes.LDA, AddressingModes.IDY, 2, 5, "NZ"),

            // LDX
            new OpCodeDefinition(0xA2, OpCodes.LDX, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0xA6, OpCodes.LDX, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0xB6, OpCodes.LDX, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0xAE, OpCodes.LDX, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0xBE, OpCodes.LDX, AddressingModes.ABX, 3, 4, "NZ"),

            // LDY
            new OpCodeDefinition(0xA0, OpCodes.LDY, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0xA4, OpCodes.LDY, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0xB4, OpCodes.LDY, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0xAC, OpCodes.LDY, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0xBC, OpCodes.LDY, AddressingModes.ABX, 3, 4, "NZ"),

            // LSR
            new OpCodeDefinition(0x4A, OpCodes.LSR, AddressingModes.ACC, 1, 2, "NZ"),
            new OpCodeDefinition(0x46, OpCodes.LSR, AddressingModes.ZP0, 2, 5, "NZ"),
            new OpCodeDefinition(0x56, OpCodes.LSR, AddressingModes.ZPX, 2, 6, "NZ"),
            new OpCodeDefinition(0x4E, OpCodes.LSR, AddressingModes.ABS, 3, 6, "NZ"),
            new OpCodeDefinition(0x5E, OpCodes.LSR, AddressingModes.ABX, 3, 7, "NZ"),

            // NOP
            new OpCodeDefinition(0xEA, OpCodes.NOP, AddressingModes.IMP, 1, 2, ""),

            // ORA
            new OpCodeDefinition(0x09, OpCodes.ORA, AddressingModes.IMM, 2, 2, "NZ"),
            new OpCodeDefinition(0x05, OpCodes.ORA, AddressingModes.ZP0, 2, 3, "NZ"),
            new OpCodeDefinition(0x15, OpCodes.ORA, AddressingModes.ZPX, 2, 4, "NZ"),
            new OpCodeDefinition(0x0D, OpCodes.ORA, AddressingModes.ABS, 3, 4, "NZ"),
            new OpCodeDefinition(0x1D, OpCodes.ORA, AddressingModes.ABX, 3, 4, "NZ"),
            new OpCodeDefinition(0x19, OpCodes.ORA, AddressingModes.ABY, 3, 4, "NZ"),
            new OpCodeDefinition(0x01, OpCodes.ORA, AddressingModes.IDX, 2, 6, "NZ"),
            new OpCodeDefinition(0x11, OpCodes.ORA, AddressingModes.IDY, 2, 5, "NZ"),

            // Register Instructions
            new OpCodeDefinition(0xAA, OpCodes.TAX, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0x8A, OpCodes.TXA, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0xCA, OpCodes.DEX, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0xE8, OpCodes.INX, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0xA8, OpCodes.TAY, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0x98, OpCodes.TYA, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0x88, OpCodes.DEY, AddressingModes.NON, 1, 2, "NZ"),
            new OpCodeDefinition(0xC8, OpCodes.INY, AddressingModes.NON, 1, 2, "NZ"),

            // ROL
            new OpCodeDefinition(0x2A, OpCodes.ROL, AddressingModes.ACC, 1, 2, "NZC"),
            new OpCodeDefinition(0x26, OpCodes.ROL, AddressingModes.ZP0, 2, 5, "NZC"),
            new OpCodeDefinition(0x36, OpCodes.ROL, AddressingModes.ZPX, 2, 6, "NZC"),
            new OpCodeDefinition(0x2E, OpCodes.ROL, AddressingModes.ABS, 3, 6, "NZC"),
            new OpCodeDefinition(0x3E, OpCodes.ROL, AddressingModes.ABX, 3, 7, "NZC"),

            // ROR
            new OpCodeDefinition(0x6A, OpCodes.ROR, AddressingModes.ACC, 1, 2, "NZC"),
            new OpCodeDefinition(0x66, OpCodes.ROR, AddressingModes.ZP0, 2, 5, "NZC"),
            new OpCodeDefinition(0x76, OpCodes.ROR, AddressingModes.ZPX, 2, 6, "NZC"),
            new OpCodeDefinition(0x6E, OpCodes.ROR, AddressingModes.ABS, 3, 6, "NZC"),
            new OpCodeDefinition(0x7E, OpCodes.ROR, AddressingModes.ABX, 3, 7, "NZC"),

            // RTI
            new OpCodeDefinition(0x40, OpCodes.RTI, AddressingModes.IMP, 1, 6, "NVBDIZC"),

            // RTS
            new OpCodeDefinition(0x60, OpCodes.RTS, AddressingModes.IMP, 1, 6, ""),

            // SBC
            new OpCodeDefinition(0xE9, OpCodes.SBC, AddressingModes.IMM, 2, 2, "NVZC"),
            new OpCodeDefinition(0xE5, OpCodes.SBC, AddressingModes.ZP0, 2, 3, "NVZC"),
            new OpCodeDefinition(0xF5, OpCodes.SBC, AddressingModes.ZPX, 2, 4, "NVZC"),
            new OpCodeDefinition(0xED, OpCodes.SBC, AddressingModes.ABS, 3, 4, "NVZC"),
            new OpCodeDefinition(0xFD, OpCodes.SBC, AddressingModes.ABX, 3, 4, "NVZC"),
            new OpCodeDefinition(0xF9, OpCodes.SBC, AddressingModes.ABY, 3, 4, "NVZC"),
            new OpCodeDefinition(0xE1, OpCodes.SBC, AddressingModes.IDX, 2, 6, "NVZC"),
            new OpCodeDefinition(0xF1, OpCodes.SBC, AddressingModes.IDY, 2, 5, "NVZC"),

            // STA
            new OpCodeDefinition(0x85, OpCodes.STA, AddressingModes.ZP0, 2, 3, ""),
            new OpCodeDefinition(0x95, OpCodes.STA, AddressingModes.ZPX, 2, 4, ""),
            new OpCodeDefinition(0x8D, OpCodes.STA, AddressingModes.ABS, 3, 4, ""),
            new OpCodeDefinition(0x9D, OpCodes.STA, AddressingModes.ABX, 3, 5, ""),
            new OpCodeDefinition(0x99, OpCodes.STA, AddressingModes.ABY, 3, 5, ""),
            new OpCodeDefinition(0x81, OpCodes.STA, AddressingModes.IDX, 2, 6, ""),
            new OpCodeDefinition(0x91, OpCodes.STA, AddressingModes.IDY, 2, 6, ""),

            // Stack Instructions
            new OpCodeDefinition(0x9A, OpCodes.TXS, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0xBA, OpCodes.TSX, AddressingModes.NON, 1, 2, ""),
            new OpCodeDefinition(0x48, OpCodes.PHA, AddressingModes.NON, 1, 3, ""),
            new OpCodeDefinition(0x68, OpCodes.PLA, AddressingModes.NON, 1, 4, ""),
            new OpCodeDefinition(0x08, OpCodes.PHP, AddressingModes.NON, 1, 3, ""),
            new OpCodeDefinition(0x28, OpCodes.PLP, AddressingModes.NON, 1, 4, ""),

            // STX
            new OpCodeDefinition(0x86, OpCodes.STX, AddressingModes.ZP0, 2, 3, ""),
            new OpCodeDefinition(0x96, OpCodes.STX, AddressingModes.ZPX, 2, 4, ""),
            new OpCodeDefinition(0x8E, OpCodes.STX, AddressingModes.ABS, 3, 4, ""),

            // STY
            new OpCodeDefinition(0x84, OpCodes.STY, AddressingModes.ZP0, 2, 3, ""),
            new OpCodeDefinition(0x94, OpCodes.STY, AddressingModes.ZPX, 2, 4, ""),
            new OpCodeDefinition(0x8C, OpCodes.STY, AddressingModes.ABS, 3, 4, ""),
         };

         opCodeTable = new Dictionary<byte, OpCodeDefinition>();

         opCodeDefinitions.ForEach(x =>
         {
            opCodeTable.Add(x.OpCode, x);
         });
      }
   }
}
