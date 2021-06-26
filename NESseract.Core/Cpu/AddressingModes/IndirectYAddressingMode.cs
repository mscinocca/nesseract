namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectYAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = (memory[operand1] | memory[(byte)(operand1 + 1)] << 0x08) + registers.Y;

         pageBoundaryCrossed = (address & 0xFF00) != memory[(operand1 + 1)] << 0x08;

         return (ushort)address;
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         return memory[address];
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, ushort address)
      {
         return memory[address];
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, byte value, out bool pageBoundaryCrossed)
      {
         var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         memory[address] = value;
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {
         memory[address] = value;
      }

      public string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var address = (memory[operand1] | memory[(byte)(operand1 + 1)] << 0x08);

         var indexedAddress = (ushort)(address + registers.Y);

         return $"(${operand1:X02}),Y = {address:X04} @ {indexedAddress:X04}";
      }
   }
}
