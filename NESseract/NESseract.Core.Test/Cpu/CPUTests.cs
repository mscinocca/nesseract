using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.Definitions;
using System;
using System.Text;

namespace NESseract.Core.Test.Cpu
{
   [TestClass]
   public class CPUTests
   {
      [TestMethod]
      public void CPUOpCodeHandlerCountTest()
      {
         var cpu = new Core.Cpu.CPU();

         Assert.AreEqual(151, OpCodeDefinitions.OpCodeList.Count);
      }

      [TestMethod]
      public unsafe void ROMTest()
      {
         var rom = Resource.nestest;
         var romMemory = new Span<byte>(Resource.nestest);

         var identifier = Encoding.ASCII.GetString(rom, 0, 3);
         var fileFormat = rom[3];
         var numberOfBanks = rom[4];
         var numberOfVBanks = rom[5];
         var controlByte1 = rom[6];
         var controlByte2 = rom[7];
         var numberOfRAMBanks = rom[8];
         var reserved = romMemory.Slice(9, 7);

         var cpu = new Core.Cpu.CPU();
         cpu.LoadROM(rom);
         cpu.SetProgramCounter(0xC000);
         cpu.Tick();

         Assert.AreEqual(@"NES", identifier);
         Assert.AreEqual(0x1A, fileFormat);
      }
   }
}
