using NESseract.Core.Bus;
using NESseract.Core.Cpu;
using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Operations;

namespace NESseract.Core.Test.Cpu.Operations
{
   public class BaseOperationTests<T> where T : IOperation, new()
   {
      protected readonly IOperation operation;

      protected readonly IAddressingMode absoluteAddressingMode;
      protected readonly IAddressingMode absoluteXAddressingMode;
      protected readonly IAddressingMode absoluteYAddressingMode;
      protected readonly IAddressingMode accumulatorAddressingMode;
      protected readonly IAddressingMode immediateAddressingMode;
      protected readonly IAddressingMode impliedAddressingMode;
      protected readonly IAddressingMode indirectAddressingMode;
      protected readonly IAddressingMode indirectXAddressingMode;
      protected readonly IAddressingMode indirectYAddressingMode;
      protected readonly IAddressingMode relativeAddressingMode;
      protected readonly IAddressingMode zeroPageAddressingMode;
      protected readonly IAddressingMode zeroPageXAddressingMode;
      protected readonly IAddressingMode zeroPageYAddressingMode;

      protected readonly CPUMemory cpuMemory;
      protected readonly CPURegisters cpuRegisters;

      public BaseOperationTests()
      {
         operation = new T();

         absoluteAddressingMode = new AbsoluteAddressingMode();
         absoluteXAddressingMode = new AbsoluteXAddressingMode();
         absoluteYAddressingMode = new AbsoluteYAddressingMode();
         accumulatorAddressingMode = new AccumulatorAddressingMode();
         immediateAddressingMode = new ImmediateAddressingMode();
         impliedAddressingMode = new ImpliedAddressingMode();
         indirectAddressingMode = new IndirectAddressingMode();
         indirectXAddressingMode = new IndirectXAddressingMode();
         indirectYAddressingMode = new IndirectYAddressingMode();
         relativeAddressingMode = new RelativeAddressingMode();
         zeroPageAddressingMode = new ZeroPageAddressingMode();
         zeroPageXAddressingMode = new ZeroPageXAddressingMode();
         zeroPageYAddressingMode = new ZeroPageYAddressingMode();

         cpuMemory = new CPUMemory();
         cpuRegisters = new CPURegisters();
      }
   }
}
