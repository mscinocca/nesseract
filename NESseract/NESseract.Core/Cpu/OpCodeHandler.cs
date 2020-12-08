using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;

namespace NESseract.Core.Cpu
{
   public class OpCodeHandler
   {
      public OpCodeDefinition OpCodeDefinition { get; set; }

      public IOperation Operation { get; set; }

      public IAddressingMode AddressingMode { get; set; }

      public byte Execute(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
      {
         Operation.Execute(AddressingMode, memory, registers, operand1, operand2);

         return OpCodeDefinition.ExecutionCycles;
      }

      public string GetLog(CPUMemory memory, CPURegisters registers, ushort counter, byte operand1, byte operand2)
      {
         return $"{registers.PC:X04}  {OpCodeDefinition.OpCode:X02} {operand1:X02} {operand2:X02}  {OpCodeDefinition.Nemonic} {AddressingMode.GetSyntax(operand1, operand2),-27} A:{registers.A:X02} X:{registers.X:X02} Y:{registers.Y:X02} P:{registers.PS:X02} SP:{registers.SP:X02} PPU:{"0",3},{"0",3} CYC:{counter}";
      }
   }
}
