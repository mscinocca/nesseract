using NESseract.Core.Components;
using System;

namespace NESseract.Core.Ppu;

public class PPUMemory : MemoryChip
{
   public PPUMemory() : base(0x10000) { }

   protected override ushort DecodeAddress(ushort address)
   {
      return address;
   }

   public Memory<byte> CHRROM
   {
      get => MemorySpan.Slice(0x0000, 0x0100);
   }

   public Memory<byte> VRAM
   {
      get => MemorySpan.Slice(0x2000, 0x1F00);
   }

   public Memory<byte> Palettes
   {
      get => MemorySpan.Slice(0x3F00, 0x0100);
   }

   public Memory<byte> Mirrors
   {
      get => MemorySpan.Slice(0x4000, 0xC0FF);
   }
}