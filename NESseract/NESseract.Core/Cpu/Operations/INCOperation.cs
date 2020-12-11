using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class INCOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationAddress = addressingMode.GetValue(memory, registers, operand1, operand2, out _);
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out _);

         var result = operationValue + 1;

         registers.N_NegativeFlag = (byte)((result & 0x80) >> 7);
         registers.Z_ZeroFlag = (byte)result == 0 ? 1 : 0;

         addressingMode.SetValue(memory, registers, operationAddress, (byte)result);

         return opCodeDefinition.ExecutionCycles;
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
