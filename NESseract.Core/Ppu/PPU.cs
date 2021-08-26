using NESseract.Core.Cpu;
using NESseract.Core.Rom;

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

      public void PowerUp()
      {
         Registers.PPUCTRL.Value = 0x00;
         Registers.PPUMASK.Value = 0x00;

         Registers.PPUSTATUS.Value = 0b10100000;
         Registers.OAMADDR.Value = 0x00;
         Registers.PPUSCROLL.Value = 0x00;
         Registers.PPUADDR.Value = 0x00;
         Registers.PPUDATA.Value = 0x00;
      }

      public void Reset()
      {
         Registers.PPUCTRL.Value = 0x00;
         Registers.PPUMASK.Value = 0x00;

         Registers.PPUSCROLL.Value = 0x00;
         Registers.PPUDATA.Value = 0x00;
      }

      public void LoadROM(ROM rom)
      {
         Memory.SetBlock(rom.GetCHRROMBank(0), 0, 0x0000, 0x2000);
      }
   }
}
