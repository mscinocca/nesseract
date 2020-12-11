using System;

namespace NESseract.Core.Cpu.AddressingModes
{
   public class RelativeAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = registers.PC + (sbyte)operand1;

         pageBoundaryCrossed = (address & 0xFF00) != (registers.PC & 0xFF00);

         return (ushort)address;
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         throw new NotImplementedException("GetValue not valid for this addressing mode");
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         throw new NotImplementedException("SetValue not valid for this addressing mode");
      }

      public string GetSyntax(CPURegisters registers, byte operand1, byte operand2)
      {
         return $"${registers.PC + (sbyte)operand1:X02}";
      }
   }
}
