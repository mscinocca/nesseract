using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class LAXOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out bool pageBoundaryCrossed);

         registers.N_NegativeFlag = (byte)((operationValue & 0x80) >> 7);
         registers.Z_ZeroFlag = (byte)(operationValue == 0 ? 1 : 0);

         registers.A = operationValue;
         registers.X = operationValue;

         return (byte)(opCodeDefinition.ExecutionCycles + (opCodeDefinition.AddExecutionCycleOnPageBoundaryCross && pageBoundaryCrossed ? 1 : 0));
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         if (opCodeDefinition.AddressingMode == AddressingMode.IMM)
         {
            return string.Empty;
         }
         else
         {
            var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out _);

            return $"= {operationValue:X02}";
         }
      }
   }
}
