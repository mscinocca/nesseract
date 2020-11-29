namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageYAddressingMode : IAddressingMode
   {
      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return memory.Memory[(byte)(operand1 + registers.IndexRegisterY)];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X},Y";
      }
   }
}
