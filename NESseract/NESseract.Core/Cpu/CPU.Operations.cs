namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      public unsafe void ADC_ZPO(byte address)
      {
         fixed (byte* dest = &Registers.A)
         {
            ADC(Memory.Memory[address], Registers.A, dest);
         }
      }

      public unsafe void ADC_ZPX(byte address)
      {
         fixed (byte* dest = &Registers.A)
         {
            var zeroPageAddress = (byte)(address + Registers.X);

            ADC(Memory.Memory[zeroPageAddress], Registers.A, dest);
         }
      }

      public unsafe void ADC_ABS(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.A)
         {
            var address = address1 | address2 << 0xFF;

            ADC(Memory.Memory[address], Registers.A, dest);
         }
      }

      public unsafe void ADC_ABX(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.A)
         {
            var address = address1 | address2 << 0xFF + Registers.X;

            ADC(Memory.Memory[address], Registers.A, dest);
         }
      }

      public unsafe void ADC_ABY(byte address1, byte address2)
      {
         fixed (byte* dest = &Registers.A)
         {
            var address = address1 | address2 << 0xFF + Registers.Y;

            ADC(Memory.Memory[address], Registers.A, dest);
         }
      }

      public unsafe void ADC_IDX(byte address)
      {
         fixed (byte* dest = &Registers.A)
         {
            var indexedAddress = (byte)(address + Registers.X);

            var indirectAddress = Memory.Memory[indexedAddress] | Memory.Memory[indexedAddress + 1] << 0xFF;

            ADC(Memory.Memory[indirectAddress], Registers.A, dest);
         }
      }

      public unsafe void ADC_IDY(byte address)
      {
         fixed (byte* dest = &Registers.A)
         {
            var indirectAddress = Memory.Memory[address] | Memory.Memory[address + 1] << 0xFF + Registers.Y;

            ADC(Memory.Memory[indirectAddress], Registers.A, dest);
         }
      }

      public unsafe void ADC_IMM(byte value)
      {
         fixed (byte* dest = &Registers.A)
         {
            ADC(value, Registers.A, dest);
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
