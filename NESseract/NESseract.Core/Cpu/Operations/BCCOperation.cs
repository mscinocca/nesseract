using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class BCCOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationAddress = addressingMode.GetAddress(memory, registers, operand1, operand2, out bool pageBoundaryCrossed);

         var branchTaken = false;

         if (registers.C_CarryFlag == 0)
         {
            registers.PC = operationAddress;

            branchTaken = true;
         }

         return (byte)(opCodeDefinition.ExecutionCycles + (opCodeDefinition.AddExecutionCycleOnPageBoundaryCross && pageBoundaryCrossed && branchTaken ? 1 : 0) + (branchTaken ? 1 : 0));
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
