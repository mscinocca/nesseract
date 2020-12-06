namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return memory.Memory[operand1];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X}";
      }
   }
}
