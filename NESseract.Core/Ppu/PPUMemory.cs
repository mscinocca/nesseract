using System;

namespace NESseract.Core.Ppu
{
   public class PPUMemory
   {
      public byte[] Memory;

      public Memory<byte> MemorySpan;

      public PPUMemory()
      {
         Memory = new byte[0x10000];

         MemorySpan = new Memory<byte>(Memory);
      }
   }
}
