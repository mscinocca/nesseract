using System;

namespace NESseract.Core.Cpu
{
   public class CPUMemory
   {
      public byte[] Memory;

      public Memory<byte> MemorySpan;

      public CPUMemory()
      {
         Memory = new byte[0x10000];

         MemorySpan = new Memory<byte>(Memory);
      }

      public Memory<byte> ZeroPage
      {
         get { return MemorySpan.Slice(0x0000, 0x0100); }
      }

      public Memory<byte> Stack
      {
         get { return MemorySpan.Slice(0x0100, 0x0100); }
      }

      public Memory<byte> RAM
      {
         get { return MemorySpan.Slice(0x0200, 0x0600); }
      }

      public Memory<byte> Mirrors
      {
         get { return MemorySpan.Slice(0x0800, 0x1800); }
      }

      public Memory<byte> IORegisters1
      {
         get { return MemorySpan.Slice(0x2000, 0x0008); }
      }

      public Memory<byte> IOMirrors
      {
         get { return MemorySpan.Slice(0x2008, 0x1FF8); }
      }

      public Memory<byte> IORegisters2
      {
         get { return MemorySpan.Slice(0x4000, 0x0020); }
      }

      public Memory<byte> ExpansionROM
      {
         get { return MemorySpan.Slice(0x4020, 0x1FE0); }
      }

      public Memory<byte> SRAM
      {
         get { return MemorySpan.Slice(0x6000, 0x2000); }
      }

      public Memory<byte> ROMLowerBank
      {
         get { return MemorySpan.Slice(0x8000, 0x4000); }
      }

      public Memory<byte> ROMUpperBank
      {
         get { return MemorySpan.Slice(0xC000, 0x4000); }
      }
   }
}
