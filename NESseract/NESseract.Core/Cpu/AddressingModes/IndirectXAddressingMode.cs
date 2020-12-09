namespace NESseract.Core.Cpu.AddressingModes
{
   public class IndirectXAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var indexedAddress = (byte)(operand1 + registers.X);

         var address = memory.Memory[indexedAddress] | memory.Memory[indexedAddress + 1] << 0x08;

         pageBoundaryCrossed = false;

         return memory.Memory[address];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"(${operand1:X02},X)";
      }
   }
}
