namespace NESseract.Core.Cpu.AddressingModes
{
   public class ZeroPageYAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return memory.Memory[(byte)(operand1 + registers.Y)];
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"${operand1:X02},Y";
      }
   }
}
