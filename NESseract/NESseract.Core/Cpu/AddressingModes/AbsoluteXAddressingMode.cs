namespace NESseract.Core.Cpu.AddressingModes
{
   public class AbsoluteXAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var address = (operand1 | operand2 << 0x08) + registers.X;

         pageBoundaryCrossed = (address & 0xFF00) != operand2 << 0x08;

         return (ushort)address;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1 | operand2 << 0x08:X02},X";
      }
   }
}
