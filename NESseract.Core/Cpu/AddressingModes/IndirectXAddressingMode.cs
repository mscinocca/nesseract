namespace NESseract.Core.Cpu.AddressingModes;

public class IndirectXAddressingMode : IAddressingMode
{
   public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
   {
      var indexedAddress = (byte)(operand1 + registers.X);

      var address = memory[indexedAddress] | memory[(byte)(indexedAddress + 1)] << 0x08;

      pageBoundaryCrossed = false;

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
      var indexedAddress = (byte)(operand1 + registers.X);

      var address = memory[indexedAddress] | memory[(byte)(indexedAddress + 1)] << 0x08;

      return $"(${operand1:X02},X) @ {indexedAddress:X02} = {address:X04}";
   }
}