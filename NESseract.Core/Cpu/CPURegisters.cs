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
         set { PS = (byte)(value == 1 ? PS | (1 << 7) : PS & (0xFF ^ (1 << 7))); }
      }

      public byte Z_ZeroFlag
      {
         get { return (byte)(PS >> 1 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 1) : PS & (0xFF ^ (1 << 1))); }
      }

      public byte C_CarryFlag
      {
         get { return (byte)(PS >> 0 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 0) : PS & (0xFF ^ (1 << 0))); }
      }

      public byte I_InterruptDisable
      {
         get { return (byte)(PS >> 2 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 2) : PS & (0xFF ^ (1 << 2))); }
      }

      public byte D_DecimalMode
      {
         get { return (byte)(PS >> 3 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 3) : PS & (0xFF ^ (1 << 3))); }
      }

      public byte V_OverflowFlag
      {
         get { return (byte)(PS >> 6 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 6) : PS & (0xFF ^ (1 << 6))); }
      }

      public byte B_BreakCommand
      {
         get { return (byte)(PS >> 4 & 1); }
         set { PS = (byte)(value == 1 ? PS | (1 << 4) : PS & (0xFF ^ (1 << 4))); }
      }

      public CPURegisters()
      {
         PC = 0x00;
         SP = 0x00;

         A = 0x00;
         X = 0x00;
         Y = 0x00;

         PS = 0x00;
      }
   }
}
