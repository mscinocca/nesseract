namespace NESseract.Core.Cpu.AddressingModes
{
   public class RelativeAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return (ushort)(registers.PC + (sbyte)operand1);
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X02}";
      }
   }
}
