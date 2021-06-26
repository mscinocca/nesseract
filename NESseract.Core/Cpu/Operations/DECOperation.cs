using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class DECOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationAddress = addressingMode.GetAddress(memory, registers, operand1, operand2, out _);
         var operationValue = addressingMode.GetValue(memory, registers, operationAddress);

         var result = operationValue - 1;

         registers.N_NegativeFlag = (byte)((result & 0x80) >> 7);
         registers.Z_ZeroFlag = (byte)((byte)result == 0 ? 1 : 0);

         addressingMode.SetValue(memory, registers, operationAddress, (byte)result);

         return opCodeDefinition.ExecutionCycles;
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
