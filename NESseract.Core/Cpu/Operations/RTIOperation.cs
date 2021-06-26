using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu.Operations
{
   public class RTIOperation : IOperation
   {
      public byte Execute(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         var ps = memory.Stack.Span[++registers.SP];

         var pcLow = memory.Stack.Span[++registers.SP];
         var pcHigh = memory.Stack.Span[++registers.SP];

         registers.PS = (byte)((registers.PS & 0x30) | (ps & 0xCF));
         registers.PC = (ushort)(pcLow | pcHigh << 0x08);

         return opCodeDefinition.ExecutionCycles;
      }

      public string GetSyntax(OpCodeDefinition opCodeDefinition, IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         return string.Empty;
      }
   }
}