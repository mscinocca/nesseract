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

         Assert.AreEqual(@"NES", identifier);
         Assert.AreEqual(0x1A, fileFormat);
         Assert.AreEqual(0x01, numberOfBanks);
         Assert.AreEqual(0x01, numberOfVBanks);
         Assert.AreEqual(0x00, controlByte1);
         Assert.AreEqual(0x00, controlByte2);
         Assert.AreEqual(0x00, numberOfRAMBanks);
         Assert.AreEqual(0x00, reserved[0]);
         Assert.AreEqual(0x00, reserved[1]);
         Assert.AreEqual(0x00, reserved[2]);
         Assert.AreEqual(0x00, reserved[3]);
         Assert.AreEqual(0x00, reserved[4]);
         Assert.AreEqual(0x00, reserved[5]);
         Assert.AreEqual(0x00, reserved[6]);
      }

      [TestMethod]
      public unsafe void CPUTest()
      {
         var rom = Resource.nestest;

         var romLog = new ROMLog();
         romLog.Parse(Resource.nestestlog);

         var cpu = new Core.Cpu.CPU();
         cpu.LoadROM(rom);

         for (var i = 0; i < 6; i++)
         {
            var cpuTickState = cpu.Tick();

            Assert.AreEqual(romLog.ROMLogLines[i].PC, cpuTickState.PC);
            Assert.AreEqual(romLog.ROMLogLines[i].OpCode, cpuTickState.OpCode);
            Assert.AreEqual(romLog.ROMLogLines[i].Operand1, cpuTickState.Operand1);
            Assert.AreEqual(romLog.ROMLogLines[i].Operand2, cpuTickState.Operand2);
            Assert.AreEqual(romLog.ROMLogLines[i].NemonicSyntax, cpuTickState.NemonicSyntax);
            Assert.AreEqual(romLog.ROMLogLines[i].A, cpuTickState.A);
            Assert.AreEqual(romLog.ROMLogLines[i].X, cpuTickState.X);
            Assert.AreEqual(romLog.ROMLogLines[i].Y, cpuTickState.Y);
            Assert.AreEqual(romLog.ROMLogLines[i].P, cpuTickState.P);
            Assert.AreEqual(romLog.ROMLogLines[i].CYC, cpuTickState.CYC);
         }
      }
   }
}
