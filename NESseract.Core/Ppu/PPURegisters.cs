using NESseract.Core.Components;

namespace NESseract.Core.Ppu;

public class PPURegisters(MemoryChip cpuMemory)
{
   public MemoryMappedRegister PPUCTRL { get; private set; } = new(cpuMemory, 0x2000);
   public MemoryMappedRegister PPUMASK { get; private set; } = new(cpuMemory, 0x2001);
   public MemoryMappedRegister PPUSTATUS { get; private set; } = new(cpuMemory, 0x2002);
   public MemoryMappedRegister OAMADDR { get; private set; } = new(cpuMemory, 0x2003);
   public MemoryMappedRegister OAMDATA { get; private set; } = new(cpuMemory, 0x2004);
   public MemoryMappedRegister PPUSCROLL { get; private set; } = new(cpuMemory, 0x2005);
   public MemoryMappedRegister PPUADDR { get; private set; } = new(cpuMemory, 0x2006);
   public MemoryMappedRegister PPUDATA { get; private set; } = new(cpuMemory, 0x2007);
   public MemoryMappedRegister OAMDMA { get; private set; } = new(cpuMemory, 0x4014);
}