namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectYAddressingMode : IAddressingMode
   {
      public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var address = memory.Memory[operand1] | memory.Memory[operand1 + 1] << 0x08 + registers.IndexRegisterY;

         return memory.Memory[address];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1:X}),Y";
      }
   }
}
