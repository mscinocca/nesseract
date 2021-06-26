using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class ROLOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationAddress = addressingMode.GetAddress(memory, registers, operand1, operand2, out bool pageBoundaryCrossed);
         var operationValue = addressingMode.GetValue(memory, registers, operationAddress);

         var result = operationValue << 1 | registers.C_CarryFlag;

         registers.N_NegativeFlag = (byte)((result & 0x80) >> 7);
         registers.C_CarryFlag = (byte)((operationValue & 0x80) >> 7);
         registers.Z_ZeroFlag = (byte)((byte)result == 0x00 ? 1 : 0);

         addressingMode.SetValue(memory, registers, operationAddress, (byte)result);

         return (byte)(opCodeDefinition.ExecutionCycles + (opCodeDefinition.AddExecutionCycleOnPageBoundaryCross && pageBoundaryCrossed ? 1 : 0));
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         if (opCodeDefinition.AddressingMode == AddressingMode.IMM || opCodeDefinition.AddressingMode == AddressingMode.ACC)
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
