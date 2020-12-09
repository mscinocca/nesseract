namespace NESseract.Core.Cpu.AddressingModes
{
   public class AbsoluteAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return (ushort)(operand1 | operand2 << 0x08);
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1 | operand2 << 0x08:X02}";
      }
   }
}
