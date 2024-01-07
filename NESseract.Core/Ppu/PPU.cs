using NESseract.Core.Cpu;
using NESseract.Core.Rom;

namespace NESseract.Core.Ppu;

public class PPU(CPUMemory cpuMemory)
{
   public readonly CPUMemory CPUMemory = cpuMemory;

   private readonly PPURegisters _registers = new(cpuMemory);
   private readonly PPUMemory _memory = new();

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