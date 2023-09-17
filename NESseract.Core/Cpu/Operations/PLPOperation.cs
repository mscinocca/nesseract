using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations;

public class PLPOperation : IOperation
{
   public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      var operationValue = memory.Stack.Span[++registers.SP];

      registers.PS = (byte)((registers.PS & 0x30) | (operationValue & 0xCF));

      return opCodeDefinition.ExecutionCycles;
   }

   public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      return string.Empty;
   }
}