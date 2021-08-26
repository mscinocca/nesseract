using NESseract.Core.Cpu;
using NESseract.Core.Ppu;
using NESseract.Core.Rom;

namespace NESseract.Core
{
   public class NESSystem
   {
      public readonly CPU CPU;
      public readonly PPU PPU;

      public ROM LoadedROM;

      public NESSystem()
      {
         CPU = new CPU();
         PPU = new PPU(CPU.Memory);
      }

      public void PowerUp()
      {
         CPU.PowerUp();
         PPU.PowerUp();
      }

      public void Reset()
      {
         CPU.Reset();
         PPU.Reset();
      }

      public void LoadROM(byte[] data)
      {
         LoadedROM = new ROM(data);

         CPU.LoadROM(LoadedROM);
         PPU.LoadROM(LoadedROM);
      }
   }
}
