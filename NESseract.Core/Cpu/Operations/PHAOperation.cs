using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class PHAOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         memory.Stack.Span[registers.SP--] = registers.A;

         return opCodeDefinition.ExecutionCycles;
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
