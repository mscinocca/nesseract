namespace NESseract.Core.Cpu.AddressingModes
{
   public class ImpliedAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return 0;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
