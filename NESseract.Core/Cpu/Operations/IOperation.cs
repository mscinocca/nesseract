using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public interface IOperation
   {
      byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2);

      string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2);
   }
}
