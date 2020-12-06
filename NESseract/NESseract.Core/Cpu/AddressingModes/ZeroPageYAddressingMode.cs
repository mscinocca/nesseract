namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageYAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return memory.Memory[(byte)(operand1 + registers.Y)];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X},Y";
      }
   }
}
