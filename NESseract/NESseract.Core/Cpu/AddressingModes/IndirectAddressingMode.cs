using System;

namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         var address1 = operand1 | operand2 << 0x08;
         var address2 = address1 + 1;

         if(operand1 == 0xFF)
         {
            address2 -= 0x100;
         }

         return (ushort)(memory.Memory[address1] | memory.Memory[address2] << 0x08);
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         throw new NotImplementedException("GetValue not valid for this addressing mode");
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, ushort address)
      {
         throw new NotImplementedException("GetValue not valid for this addressing mode");
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, byte value, out bool pageBoundaryCrossed)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         memory.Memory[address] = value;
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         memory.Memory[address] = value;
      }

      public string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out _);

         return $"(${operand1 | operand2 << 0x08:X04}) = {address:X04}";
      }
   }
}
