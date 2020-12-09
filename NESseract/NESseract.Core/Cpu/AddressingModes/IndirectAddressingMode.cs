namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         var address1 = operand1 | operand2 << 0x08;
         var address2 = address1 + 1;

         if(operand1 == 0xFF)
         {
            address2 -= 0x100;
         }

         return (ushort)(memory.Memory[address1] | memory.Memory[address2] << 0x08);
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1 | operand2 << 0x08:X02})";
      }
   }
}
