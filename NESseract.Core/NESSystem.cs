using NESseract.Core.Cpu;
using NESseract.Core.Ppu;
using NESseract.Core.Rom;

namespace NESseract.Core;

public class NESSystem
{
   private readonly CPU _cpu;
   private readonly PPU _ppu;

   private ROM? _loadedROM;

   public NESSystem()
   {
      _cpu = new CPU();
      _ppu = new PPU(_cpu.Memory);
   }

   public void PowerUp()
   {
      _cpu.PowerUp();
      _ppu.PowerUp();
   }

   public void Reset()
   {
      _cpu.Reset();
      _ppu.Reset();
   }

   public void LoadROM(byte[] data)
   {
      _loadedROM = new ROM(data);

      _cpu.LoadROM(_loadedROM);
      _ppu.LoadROM(_loadedROM);
   }
}