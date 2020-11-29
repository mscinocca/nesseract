using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      public unsafe byte ZPO(byte address)
      {
         return Memory.Memory[address];

         fixed (byte* dest = &Registers.Accumulator)
         {
            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ZPX(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var zeroPageAddress = (byte)(address + Registers.IndexRegisterX);

            ADC(Memory.Memory[zeroPageAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void ABS(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ABX(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF + Registers.IndexRegisterX;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ABY(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF + Registers.IndexRegisterY;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void IDX(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var indexedAddress = (byte)(address + Registers.IndexRegisterX);

            var indirectAddress = Memory.Memory[indexedAddress] | Memory.Memory[indexedAddress + 1] << 0xFF;

            ADC(Memory.Memory[indirectAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void IDY(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var indirectAddress = Memory.Memory[address] | Memory.Memory[address + 1] << 0xFF + Registers.IndexRegisterY;

            ADC(Memory.Memory[indirectAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void IMM(byte value)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            ADC(value, Registers.Accumulator, dest);
         }
      }
   }
}
