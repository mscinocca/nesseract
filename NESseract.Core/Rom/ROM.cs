using System;
using System.Text;

namespace NESseract.Core.Rom
{
   public class ROM
   {
      public readonly byte[] Memory;

      protected readonly Memory<byte> memorySpan;

      public string Identifier { get; private set; }
      public byte FileFormat { get; private set; }
      public byte NumberOfPRGROMBanks { get; private set; }
      public byte NumberOfCHRROMBanks { get; private set; }
      public byte ControlByte1 { get; private set; }
      public byte ControlByte2 { get; private set; }
      public byte NumberOfRAMBanks { get; private set; }
      public Memory<byte> Reserved { get; private set; }

      public byte MirroringType { get; private set; }
      public byte BatteryRAMPresent { get; private set; }
      public byte TrainerPresent { get; private set; }
      public byte FourScreenMirroring { get; private set; }
      public byte MapperTypeL { get; private set; }
      public byte MapperTypeU { get; private set; }


      public Mirroring Mirroring { get; private set; }
      public byte Mapper { get; private set; }

      public ROM(byte[] data)
      {
         Memory = data;

         memorySpan = new Memory<byte>(Memory);

         Identifier = Encoding.ASCII.GetString(Memory, 0, 3);
         FileFormat = Memory[3];
         NumberOfPRGROMBanks = Memory[4];
         NumberOfCHRROMBanks = Memory[5];
         ControlByte1 = Memory[6];
         ControlByte2 = Memory[7];
         NumberOfRAMBanks = Memory[8];
         Reserved = memorySpan.Slice(9, 7);

         MirroringType = (byte)(ControlByte1 & 0b0000_0001);
         BatteryRAMPresent = (byte)(ControlByte1 & 0b0000_0010 >> 1);
         TrainerPresent = (byte)(ControlByte1 & 0b0000_0100 >> 2);
         FourScreenMirroring = (byte)(ControlByte1 & 0b0000_1000 >> 3);

         MapperTypeL = (byte)(ControlByte1 & 0b1111_0000 >> 4);
         MapperTypeU = (byte)(ControlByte2 & 0b1111_0000);

         Mirroring = FourScreenMirroring == 1 ? Mirroring.FourScreen : MirroringType == 0 ? Mirroring.Horizontal : Mirroring.Vertical;
         Mapper = (byte)(MapperTypeU | MapperTypeL);
      }

      public Memory<byte> PRGROM
      {
         get { return memorySpan.Slice(16 + (TrainerPresent == 1 ? 512 : 0), 0x4000 * NumberOfPRGROMBanks); }
      }

      public Memory<byte> CHRROM
      {
         get { return memorySpan[(16 + (TrainerPresent == 1 ? 512 : 0) + 0x4000 * NumberOfPRGROMBanks)..]; }
      }

      public Memory<byte> GetPRGROMBank(int index)
      {
         return PRGROM.Slice(index * 0x4000, 0x4000);
      }

      public Memory<byte> GetCHRROMBank(int index)
      {
         return CHRROM.Slice(index * 0x2000, 0x2000);
      }
   }
}
