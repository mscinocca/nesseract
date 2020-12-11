using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class ADCOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out bool pageBoundaryCrossed);

         var result = operationValue + registers.A + registers.C_CarryFlag;

         registers.N_NegativeFlag = (byte)((result & 0x80) >> 7);
         registers.Z_ZeroFlag = (byte)result == 0 ? 1 : 0;
         registers.C_CarryFlag = result > 0xFF ? 1 : 0;
         registers.V_OverflowFlag = 
            (result < 0x80 && operationValue >= 0x80 && registers.A >= 0x80) ||
            (result >= 0x80 && operationValue < 0x80 && registers.A < 0x80) ? 1 : 0;

         registers.A = (byte)result;

         return (byte)(opCodeDefinition.ExecutionCycles + (opCodeDefinition.AddExecutionCycleOnPageBoundaryCross && pageBoundaryCrossed ? 1 : 0));
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
