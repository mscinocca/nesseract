namespace NESseract.Core.Cpu.AddressingModes
{
   public interface IAddressingMode
   {
      ushort GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2);

      string GetSyntax(byte operand1, byte operand2);
   }
}
