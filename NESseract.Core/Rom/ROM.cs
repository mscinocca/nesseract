using System;
using System.Text;

namespace NESseract.Core.Rom;

public class ROM
{
   private readonly Memory<byte> _memorySpan;

   public string Identifier { get; private set; }
   public byte FileFormat { get; private set; }
   public byte NumberOfPRGROMBanks { get; }
   public byte NumberOfCHRROMBanks { get; private set; }
   public byte ControlByte1 { get; }
   public byte ControlByte2 { get; }
   public byte NumberOfRAMBanks { get; private set; }
   public Memory<byte> Reserved { get; private set; }

   public byte MirroringType { get; }
   public byte BatteryRAMPresent { get; private set; }
   public byte TrainerPresent { get; }
   public byte FourScreenMirroring { get; }
   public byte MapperTypeL { get; }
   public byte MapperTypeU { get; }


   public Mirroring Mirroring { get; private set; }
   public byte Mapper { get; private set; }

   public ROM(byte[] data)
   {
      _memorySpan = new Memory<byte>(data);

      Identifier = Encoding.ASCII.GetString(data, 0, 3);
      FileFormat = data[3];
      NumberOfPRGROMBanks = data[4];
      NumberOfCHRROMBanks = data[5];
      ControlByte1 = data[6];
      ControlByte2 = data[7];
      NumberOfRAMBanks = data[8];
      Reserved = _memorySpan.Slice(9, 7);

      MirroringType = (byte)(ControlByte1 & 0b0000_0001);
      BatteryRAMPresent = (byte)(ControlByte1 & 0b0000_0010 >> 1);
      TrainerPresent = (byte)(ControlByte1 & 0b0000_0100 >> 2);
      FourScreenMirroring = (byte)(ControlByte1 & 0b0000_1000 >> 3);

      MapperTypeL = (byte)(ControlByte1 & 0b1111_0000 >> 4);
      MapperTypeU = (byte)(ControlByte2 & 0b1111_0000);

      Mirroring = FourScreenMirroring == 1 ? Mirroring.FOUR_SCREEN : MirroringType == 0 ? Mirroring.HORIZONTAL : Mirroring.VERTICAL;
      Mapper = (byte)(MapperTypeU | MapperTypeL);
   }

   private Memory<byte> PRGROM
   {
      get => _memorySpan.Slice(16 + (TrainerPresent == 1 ? 512 : 0), 0x4000 * NumberOfPRGROMBanks);
   }

   private Memory<byte> CHRROM
   {
      get => _memorySpan[(16 + (TrainerPresent == 1 ? 512 : 0) + 0x4000 * NumberOfPRGROMBanks)..];
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