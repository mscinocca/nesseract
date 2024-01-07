using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;

namespace NESseract.Core.Cpu;

public class OpCodeHandler(
   OpCodeDefinition opCodeDefinition,
   IOperation operation,
   IAddressingMode addressingMode)
{
   public OpCodeDefinition OpCodeDefinition { get; } = opCodeDefinition;

   public IOperation Operation { get; } = operation;

   public IAddressingMode AddressingMode { get; } = addressingMode;

   public byte Execute(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      var executionCycles = Operation.Execute(OpCodeDefinition, AddressingMode, memory, registers, operand1, operand2);

      return executionCycles;
   }

   //public string GetLog(CPUTickState cpuTickState)
   //{
   //   return $"{cpuTickState.PC:X04}  {cpuTickState.OpCode:X02} {(OpCodeDefinition.InstructionBytes >= 2 ? cpuTickState.Operand1 : @"  "):X02} {(OpCodeDefinition.InstructionBytes == 3 ? cpuTickState.Operand2 : @"  "):X02}  {cpuTickState.MnemonicSyntax,-27} A:{cpuTickState.A:X02} X:{cpuTickState.X:X02} Y:{cpuTickState.Y:X02} P:{cpuTickState.P:X02} SP:{cpuTickState.SP:X02} PPU:{"0",3},{"0",3} CYC:{cpuTickState.CYC}";
   //}
}