using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Cpu.Operations
{
   public interface IOperation
   {
      void Execute(IAddressingMode addressingMode, CPUMemory memory, CPURegisters registers, byte operand1, byte operand2);
   }
}
