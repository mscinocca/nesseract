namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return operand1;
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         return memory.Memory[address];
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, ushort address)
      {
         return memory.Memory[address];
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
         return $"${operand1:X02}";
      }
   }
}
