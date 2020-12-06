namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return (ushort)(memory.Memory[operand1 | operand2 << 0x08] | memory.Memory[(operand1 | operand2 << 0x08) + 1] << 0x08);
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1 | operand2 << 0x08:X})";
      }
   }
}
