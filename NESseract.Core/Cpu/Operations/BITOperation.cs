using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations;

public class BITOperation : IOperation
{
   public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out bool pageBoundaryCrossed);

      registers.Z_ZeroFlag = (byte)((byte)(operationValue & registers.A) == 0 ? 1 : 0);

      registers.N_NegativeFlag = (byte)(operationValue >> 7 & 0x01);
      registers.V_OverflowFlag = (byte)(operationValue >> 6 & 0x01);

      return (byte)(opCodeDefinition.ExecutionCycles + (opCodeDefinition.AddExecutionCycleOnPageBoundaryCross && pageBoundaryCrossed ? 1 : 0));
   }

   public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out _);

      return $"= {operationValue:X02}";
   }
}