﻿using System;

namespace NESseract.Core.Cpu.AddressingModes
{
   public class ImmediateAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         throw new NotImplementedException("GetAddress not valid for this addressing mode");
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return operand1;
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         throw new NotImplementedException("SetValue not valid for this addressing mode");
      }

      public string GetSyntax(CPURegisters registers, byte operand1, byte operand2)
      {
         return $"#${operand1:X02}";
      }
   }
}
