using NESseract.Core.Components;

namespace NESseract.Core.Ppu;

public class PPURegisters
{
   public MemoryMappedRegister PPUCTRL { get; private set; }
   public MemoryMappedRegister PPUMASK { get; private set; }
   public MemoryMappedRegister PPUSTATUS { get; private set; }
   public MemoryMappedRegister OAMADDR { get; private set; }
   public MemoryMappedRegister OAMDATA { get; private set; }
   public MemoryMappedRegister PPUSCROLL { get; private set; }
   public MemoryMappedRegister PPUADDR { get; private set; }
   public MemoryMappedRegister PPUDATA { get; private set; }
   public MemoryMappedRegister OAMDMA { get; private set; }

   public PPURegisters(MemoryChip cpuMemory)
   {
      PPUCTRL = new MemoryMappedRegister(cpuMemory, 0x2000);
      PPUMASK = new MemoryMappedRegister(cpuMemory, 0x2001);
      PPUSTATUS = new MemoryMappedRegister(cpuMemory, 0x2002);
      OAMADDR = new MemoryMappedRegister(cpuMemory, 0x2003);
      OAMDATA = new MemoryMappedRegister(cpuMemory, 0x2004);
      PPUSCROLL = new MemoryMappedRegister(cpuMemory, 0x2005);
      PPUADDR = new MemoryMappedRegister(cpuMemory, 0x2006);
      PPUDATA = new MemoryMappedRegister(cpuMemory, 0x2007);

      OAMDMA = new MemoryMappedRegister(cpuMemory, 0x4014);
   }
}