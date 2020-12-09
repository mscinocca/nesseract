namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectYAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = (memory.Memory[operand1] | memory.Memory[operand1 + 1] << 0x08) + registers.Y;

         pageBoundaryCrossed = (address & 0xFF00) != operand2 << 0x08;

         return memory.Memory[address];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1:X02}),Y";
      }
   }
}
