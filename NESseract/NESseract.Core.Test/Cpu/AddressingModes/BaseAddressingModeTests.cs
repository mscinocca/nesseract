using NESseract.Core.Cpu;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   public class BaseAddressingModeTests<T> where T : IAddressingMode, new()
   {
      protected readonly IAddressingMode addressingMode;

      protected readonly CPUMemory cpuMemory;
      protected readonly CPURegisters cpuRegisters;

      public BaseAddressingModeTests()
      {
         addressingMode = new T();

         cpuMemory = new CPUMemory();
         cpuRegisters = new CPURegisters();
      }
   }
}
