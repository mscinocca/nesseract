using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class LDXOperation : IOperation
   {
      public unsafe void Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
      {
         var operationValue = addressingMode.GetValue(memory, registers, operand1, operand2, out pageBoundaryCrossed);

         var result = operationValue;

         registers.N_NegativeFlag = (byte)(result & 0x80 >> 7);
         registers.Z_ZeroFlag = (byte)result == 0 ? 1 : 0;

         registers.X = (byte)result;
      }

      public string GetSyntax(byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}
