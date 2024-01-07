using NESseract.Core.Components;
using System;

namespace NESseract.Core.Cpu;

public class CPUMemory() : MemoryChip(0x10000)
{
   protected override ushort DecodeAddress(ushort address)
   {
      if(address is >= 0x0800 and <= 0x1FFF)
      {
         address = (ushort)(address & 0b0001_1111);
      }

      if (address is >= 0x2008 and <= 0x3FFF)
      {
         address = (ushort)(address & 0b0010_0000_0000_0111);
      }

      return address;
   }

   public Memory<byte> ZeroPage => MemorySpan.Slice(0x0000, 0x0100);

   public Memory<byte> Stack => MemorySpan.Slice(0x0100, 0x0100);

   public Memory<byte> RAM => MemorySpan.Slice(0x0200, 0x0600);

   public Memory<byte> Mirrors => MemorySpan.Slice(0x0800, 0x1800);

   public Memory<byte> IORegisters1 => MemorySpan.Slice(0x2000, 0x0008);

   public Memory<byte> IOMirrors => MemorySpan.Slice(0x2008, 0x1FF8);

   public Memory<byte> IORegisters2 => MemorySpan.Slice(0x4000, 0x0020);

   public Memory<byte> ExpansionROM => MemorySpan.Slice(0x4020, 0x1FE0);

   public Memory<byte> SRAM => MemorySpan.Slice(0x6000, 0x2000);

   public Memory<byte> ROMLowerBank => MemorySpan.Slice(0x8000, 0x4000);

   public Memory<byte> ROMUpperBank => MemorySpan.Slice(0xC000, 0x4000);
}