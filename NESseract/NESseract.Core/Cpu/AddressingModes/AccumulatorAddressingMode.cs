namespace NESseract.Core.Cpu.AddressingModes
{
   public class AccumulatorAddressingMode : IAddressingMode
   {
      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return registers.Accumulator;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return "A";
      }
   }
}
