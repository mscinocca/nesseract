using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Cpu.Operations
{
   public class ANDOperation : IOperation
   {
      public unsafe void Execute(IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2);

         var result = operationValue + registers.A + registers.C_CarryFlag;

         registers.N_NegativeFlag = (byte)(result & 0x80 >> 7);
         registers.Z_ZeroFlag = (byte)result == 0 ? 1 : 0;

         registers.A = (byte)result;
      }
   }
}
