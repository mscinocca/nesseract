namespace NESseract.Core.Cpu.AddressingModes
{
   public class ImmediateAddressingMode : IAddressingMode
   {
      public ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         pageBoundaryCrossed = false;

         return operand1;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"#${operand1:X02}";
      }
   }
}
