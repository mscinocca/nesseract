namespace NESseract.Core.Cpu.AddressingModes
{
   public interface IAddressingMode
   {
      ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed);

      byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed);

      void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value);

      string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2);
   }
}
