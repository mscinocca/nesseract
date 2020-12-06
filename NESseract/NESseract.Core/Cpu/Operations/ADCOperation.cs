using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Cpu.Operations
{
   public class ADCOperation : IOperation
   {
      public unsafe void Execute(IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2);

         var result = operationValue + registers.A + registers.C_CarryFlag;

         registers.C_CarryFlag = result > 0xFF ? 1 : 0;

         registers.A = (byte)result;
      }
   }
}
