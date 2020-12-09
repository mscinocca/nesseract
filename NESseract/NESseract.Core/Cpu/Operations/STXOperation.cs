using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class STXOperation : IOperation
   {
      public unsafe void Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         memory.Memory[operationValue] = registers.X;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return $"= {operand2:X02}";
      }
   }
}
