namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      public unsafe void ADC_ZPO(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_ZPX(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var zeroPageAddress = (byte)(address + Registers.IndexRegisterX);

            ADC(Memory.Memory[zeroPageAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_ABS(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_ABX(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF + Registers.IndexRegisterX;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_ABY(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var address = address1 | address2 << 0xFF + Registers.IndexRegisterY;

            ADC(Memory.Memory[address], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_IDX(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var indexedAddress = (byte)(address + Registers.IndexRegisterX);

            var indirectAddress = Memory.Memory[indexedAddress] | Memory.Memory[indexedAddress + 1] << 0xFF;

            ADC(Memory.Memory[indirectAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_IDY(byte address)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            var indirectAddress = Memory.Memory[address] | Memory.Memory[address + 1] << 0xFF + Registers.IndexRegisterY;

            ADC(Memory.Memory[indirectAddress], Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC_IMM(byte value)
      {
         fixed (byte* dest = &Registers.Accumulator)
         {
            ADC(value, Registers.Accumulator, dest);
         }
      }

      public unsafe void ADC(byte value1, byte value2, byte* destination)
      {
         var result = value1 + value2 + Registers.CarryFlag;

         Registers.CarryFlag = result > 0xFF ? 1 : 0;

         *destination = (byte)result;
      }
   }
}
