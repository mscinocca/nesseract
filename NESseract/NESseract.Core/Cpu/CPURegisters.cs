namespace NESseract.Core.Cpu
{
   public class CPURegisters
   {
      public byte ProcessorStatus;

      public byte Accumulator;
      public byte IndexRegisterX;
      public byte IndexRegisterY;

      public byte StackPointer;

      public ushort ProgramCounter;

      public bool CarryFlag
      {
         get { return (ProcessorStatus >> 0 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 0); }
      }

      public bool ZeroFlag
      {
         get { return (ProcessorStatus >> 1 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 1); }
      }

      public bool InterruptDisable
      {
         get { return (ProcessorStatus >> 2 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 2); }
      }

      public bool DecimalMode
      {
         get { return (ProcessorStatus >> 3 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 3); }
      }

      public bool BreakCommand
      {
         get { return (ProcessorStatus >> 4 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 4); }
      }

      public bool OverflowFlag
      {
         get { return (ProcessorStatus >> 6 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 6); }
      }

      public bool NegativeFlag
      {
         get { return (ProcessorStatus >> 7 & 1) == 1; }
         set { ProcessorStatus |= (byte)((value ? 1 : 0) << 7); }
      }

      public CPURegisters()
      {
         ProgramCounter = 0;
         StackPointer = 0xFF;

         Accumulator = 0;
         IndexRegisterX = 0;
         IndexRegisterY = 0;

         ProcessorStatus = 0;
      }
   }
}
