namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageXAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return memory.Memory[(byte)(operand1 + registers.X)];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X},X";
      }
   }
}
