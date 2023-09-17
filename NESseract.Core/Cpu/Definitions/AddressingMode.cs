namespace NESseract.Core.Cpu.Definitions;

public enum AddressingMode
{
   NON = 0,    // None
   ZP0 = 1,    // Zero Page
   ZPX = 2,    // Zero Page X
   ZPY = 3,    // Zero Page Y
   ABS = 4,    // Absolute
   ABX = 5,    // Absolute X
   ABY = 6,    // Absolute Y
   IND = 7,    // Indirect
   IDX = 8,    // Indexed Indirect
   IDY = 9,    // Indirect Indexed
   IMP = 10,   // Implied
   ACC = 11,   // Accumulator
   IMM = 12,   // Immediate
   REL = 13,   // Relative
}