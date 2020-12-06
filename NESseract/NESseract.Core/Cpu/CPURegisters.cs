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

      public bool N_NegativeFlag
      {
         get { return (PS >> 7 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 7); }
      }

      public bool Z_ZeroFlag
      {
         get { return (PS >> 1 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 1); }
      }

      public byte C_CarryFlag
      {
         get { return (byte)(PS >> 0 & 1); }
         set { PS |= (byte)(value << 0); }
      }

      public bool I_InterruptDisable
      {
         get { return (PS >> 2 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 2); }
      }

      public bool D_DecimalMode
      {
         get { return (PS >> 3 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 3); }
      }

      public bool V_OverflowFlag
      {
         get { return (PS >> 6 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 6); }
      }

      public bool B_BreakCommand
      {
         get { return (PS >> 4 & 1) == 1; }
         set { PS |= (byte)((value ? 1 : 0) << 4); }
      }

      public CPURegisters()
      {
         PC = 0;
         SP = 0xFF;

         A = 0;
         X = 0;
         Y = 0;

         PS = 0;
      }
   }
}
