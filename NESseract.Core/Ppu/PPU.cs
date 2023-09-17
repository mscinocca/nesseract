using NESseract.Core.Cpu;
using NESseract.Core.Rom;

namespace NESseract.Core.Ppu;

public class PPU
{
   public readonly CPUMemory CPUMemory;

   private readonly PPURegisters _registers;
   private readonly PPUMemory _memory;

   public PPU(CPUMemory cpuMemory)
   {
      CPUMemory = cpuMemory;

      _registers = new PPURegisters(cpuMemory);
      _memory = new PPUMemory();
   }

   public void PowerUp()
   {
      _registers.PPUCTRL.Value = 0x00;
      _registers.PPUMASK.Value = 0x00;

      _registers.PPUSTATUS.Value = 0b10100000;
      _registers.OAMADDR.Value = 0x00;
      _registers.PPUSCROLL.Value = 0x00;
      _registers.PPUADDR.Value = 0x00;
      _registers.PPUDATA.Value = 0x00;
   }

   public void Reset()
   {
      _registers.PPUCTRL.Value = 0x00;
      _registers.PPUMASK.Value = 0x00;

      _registers.PPUSCROLL.Value = 0x00;
      _registers.PPUDATA.Value = 0x00;
   }

   public void LoadROM(ROM rom)
   {
      _memory.SetBlock(rom.GetCHRROMBank(0), 0, 0x0000, 0x2000);
   }
}