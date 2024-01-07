using NESseract.Core.Components;
using System;

namespace NESseract.Core.Ppu;

public class PPUMemory() : MemoryChip(0x10000)
{
   protected override ushort DecodeAddress(ushort address)
   {
      return address;
   }

   public Memory<byte> CHRROM => MemorySpan.Slice(0x0000, 0x0100);

   public Memory<byte> VRAM => MemorySpan.Slice(0x2000, 0x1F00);

   public Memory<byte> Palettes => MemorySpan.Slice(0x3F00, 0x0100);

   public Memory<byte> Mirrors => MemorySpan.Slice(0x4000, 0xC0FF);
}