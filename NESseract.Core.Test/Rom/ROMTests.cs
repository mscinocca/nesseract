using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Rom;

namespace NESseract.Core.Test.Rom;

[TestClass]
public class ROMTests
{
   [TestMethod]
   public void ROMTest()
   {
      var rom = new ROM(Resource.nestest);

      Assert.AreEqual(@"NES", rom.Identifier);
      Assert.AreEqual(0x1A, rom.FileFormat);
      Assert.AreEqual(0x01, rom.NumberOfPRGROMBanks);
      Assert.AreEqual(0x01, rom.NumberOfCHRROMBanks);
      Assert.AreEqual(0x00, rom.ControlByte1);
      Assert.AreEqual(0x00, rom.ControlByte2);
      Assert.AreEqual(0x00, rom.NumberOfRAMBanks);
      Assert.AreEqual(0x00, rom.Reserved.Span[0]);
      Assert.AreEqual(0x00, rom.Reserved.Span[1]);
      Assert.AreEqual(0x00, rom.Reserved.Span[2]);
      Assert.AreEqual(0x00, rom.Reserved.Span[3]);
      Assert.AreEqual(0x00, rom.Reserved.Span[4]);
      Assert.AreEqual(0x00, rom.Reserved.Span[5]);
      Assert.AreEqual(0x00, rom.Reserved.Span[6]);

      Assert.AreEqual(0x00, rom.MirroringType);
      Assert.AreEqual(0x00, rom.BatteryRAMPresent);
      Assert.AreEqual(0x00, rom.TrainerPresent);
      Assert.AreEqual(0x00, rom.FourScreenMirroring);
      Assert.AreEqual(0x00, rom.MapperTypeL);
      Assert.AreEqual(0x00, rom.MapperTypeU);

      Assert.AreEqual(Mirroring.HORIZONTAL, rom.Mirroring);
      Assert.AreEqual(0x00, rom.Mapper);
   }
}