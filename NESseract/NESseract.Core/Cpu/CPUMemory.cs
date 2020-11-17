using System;

namespace NESseract.Core.Cpu
{
   public class CPUMemory
   {
      public Memory<byte> Memory;

      public CPUMemory()
      {
         Memory = new byte[0x10000];
      }
   }
}
