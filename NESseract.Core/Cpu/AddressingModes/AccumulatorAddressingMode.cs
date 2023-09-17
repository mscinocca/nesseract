namespace NESseract.Core.Cpu.AddressingModes;

public class AccumulatorAddressingMode : IAddressingMode
{
   public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
   {
      pageBoundaryCrossed = false;

      return 0;
   }

   public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
   {
      pageBoundaryCrossed = false;

      return registers.A;
   }

   public byte GetValue(CPUMemory memory, CPURegisters registers, ushort address)
   {
      return registers.A;
   }

   public void SetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, byte value, out bool pageBoundaryCrossed)
   {
      pageBoundaryCrossed = false;

      registers.A = value;
   }

   public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
   {
      registers.A = value;
   }

   public string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      return "A";
   }
}