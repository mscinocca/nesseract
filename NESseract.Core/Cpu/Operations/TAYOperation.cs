using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations;

public class TAYOperation : IOperation
{
   public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      registers.N_NegativeFlag = (byte)((registers.A & 0x80) >> 7);
      registers.Z_ZeroFlag = (byte)(registers.A == 0 ? 1 : 0);

      registers.Y = registers.A;

      return opCodeDefinition.ExecutionCycles;
   }

   public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      return string.Empty;
   }
}