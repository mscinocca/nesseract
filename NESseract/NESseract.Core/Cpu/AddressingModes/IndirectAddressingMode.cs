namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectAddressingMode : IAddressingMode
   {
      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return memory.Memory[operand1 | operand2 << 0x08];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1 | operand2 << 0x08:X})";
      }
   }
}
