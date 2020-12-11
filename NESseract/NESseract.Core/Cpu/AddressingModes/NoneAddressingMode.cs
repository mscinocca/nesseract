namespace NESseract.Core.Cpu.AddressingModes
{
   public class NoneAddressingMode : IAddressingMode
   {
      public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return 0;
      }

      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return 0;
      }

      public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
      {

      }

      public string GetSyntax(CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
