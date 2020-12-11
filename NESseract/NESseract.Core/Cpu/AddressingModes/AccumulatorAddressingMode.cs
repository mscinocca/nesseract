using System;

namespace NESseract.Core.Cpu.AddressingModes
{
   public class AccumulatorAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         throw new NotImplementedException("GetAddress not valid for this addressing mode");
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return registers.A;
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         registers.A = value;
      }

      public string GetSyntax(CPURegisters registers, byte operand1, byte operand2)
      {
         return "A";
      }
   }
}
