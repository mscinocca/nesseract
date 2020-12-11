namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageYAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return (byte)(operand1 + registers.Y);
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

      public string GetSyntax(CPURegisters registers, byte operand1, byte operand2)
      {
         return $"${operand1:X02},Y";
      }
   }
}
