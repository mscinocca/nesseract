namespace NESseract.Core.Cpu.AddressingModes
{
   public class ImpliedAddressingMode : IAddressingMode
   {
      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return 0;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
