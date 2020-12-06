namespace NESseract.Core.Cpu.AddressingModes
{
   public class AccumulatorAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return registers.A;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return "A";
      }
   }
}
