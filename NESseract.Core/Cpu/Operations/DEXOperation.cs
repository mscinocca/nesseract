﻿using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations;

public class DEXOperation : IOperation
{
   public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      var result = registers.X - 1;

      registers.N_NegativeFlag = (byte)((result & 0x80) >> 7);
      registers.Z_ZeroFlag = (byte)((byte)result == 0 ? 1 : 0);

      registers.X = (byte)result;

      return opCodeDefinition.ExecutionCycles;
   }

   public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      return string.Empty;
   }
}