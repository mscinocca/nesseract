using NESseract.Core.Cpu;

namespace NESseract.Core.Ppu
{
   public class PPU
   {
      public readonly CPUMemory CPUMemory;

      public readonly PPURegisters Registers;
      public readonly PPUMemory Memory;

      public PPU(CPUMemory cpuMemory)
      {
         CPUMemory = cpuMemory;

         Registers = new PPURegisters(cpuMemory);
         Memory = new PPUMemory();
      }
   }
}
