namespace NESseract.Core.Cpu
{
   public class CPURegisters
   {
      public byte PS;

      public byte A;
      public byte X;
      public byte Y;

      public byte SP;

      public ushort PC;

      public byte N_NegativeFlag
      {
         get { return (byte)(PS >> 7 & 1); }
         set { PS |= (byte)(value << 7); }
      }

      public byte Z_ZeroFlag
      {
         get { return (byte)(PS >> 1 & 1); }
         set { PS |= (byte)(value << 1); }
      }

      public byte C_CarryFlag
      {
         get { return (byte)(PS >> 0 & 1); }
         set { PS |= (byte)(value << 0); }
      }

      public byte I_InterruptDisable
      {
         get { return (byte)(PS >> 2 & 1); }
         set { PS |= (byte)(value << 2); }
      }

      public byte D_DecimalMode
      {
         get { return (byte)(PS >> 3 & 1); }
         set { PS |= (byte)(value << 3); }
      }

      public byte V_OverflowFlag
      {
         get { return (byte)(PS >> 6 & 1); }
         set { PS |= (byte)(value << 6); }
      }

      public byte B_BreakCommand
      {
         get { return (byte)(PS >> 4 & 1); }
         set { PS |= (byte)(value << 4); }
      }

      public CPURegisters()
      {
         PC = 0;
         SP = 0xFD;

         A = 0;
         X = 0;
         Y = 0;

         PS = 0x20;
         I_InterruptDisable = 1;
      }
   }
}
