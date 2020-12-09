using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class ADCOperation : IOperation
   {
      public void Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         var result = operationValue + registers.A + registers.C_CarryFlag;

         registers.N_NegativeFlag = (byte)(result & 0x80 >> 7);
         registers.Z_ZeroFlag = (byte)result == 0 ? 1 : 0;
         registers.C_CarryFlag = result > 0xFF ? 1 : 0;
         registers.V_OverflowFlag = 
            (result < 0x80 && operand1 >= 0x80 && operand2 >= 0x80) ||
            (result >= 0x80 && operand1 < 0x80 && operand2 < 0x80) ? 1 : 0;

         registers.A = (byte)result;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
