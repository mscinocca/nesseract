using NESseract.Core.Components;
using System;

namespace NESseract.Core.Ppu
{
   public class PPUMemory : MemoryChip
   {
      public PPUMemory() : base(0x10000) { }

      public override ushort DecodeAddress(ushort address)
      {
         return address;
      }

      public Memory<byte> CHRROM
      {
         get { return memorySpan.Slice(0x0000, 0x0100); }
      }

      public Memory<byte> VRAM
      {
         get { return memorySpan.Slice(0x2000, 0x1F00); }
      }

      public Memory<byte> Palettes
      {
         get { return memorySpan.Slice(0x3F00, 0x0100); }
      }

      public Memory<byte> Mirrors
      {
         get { return memorySpan.Slice(0x4000, 0xC0FF); }
      }
   }
}
