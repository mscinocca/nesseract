namespace NESseract.Core.Cpu.AddressingModes
{
   public class AbsoluteYAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = (operand1 | operand2 << 0x08) + registers.Y;

         pageBoundaryCrossed = (address & 0xFF00) != operand2 << 0x08;

         return (ushort)address;
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         return memory.Memory[address];
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         memory.Memory[address] = value;
      }

      public string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out _);

         return $"${operand1 | operand2 << 0x08:X04},Y @ {address:X04}";
      }
   }
}
