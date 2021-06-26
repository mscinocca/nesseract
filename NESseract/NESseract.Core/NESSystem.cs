using NESseract.Core.Cpu;
using NESseract.Core.Ppu;

namespace NESseract.Core
{
   public class NESSystem
   {
      public readonly CPU CPU;
      public readonly PPU PPU;

      public NESSystem()
      {
         CPU = new CPU();
         PPU = new PPU(CPU.Memory);
      }

      public void PowerUp()
      {
         CPU.PowerUp();
      }

      public void Reset()
      {
         CPU.Reset();
      }

      public void LoadROM(byte[] rom)
      {
         CPU.LoadROM(rom);
      }
   }
}
