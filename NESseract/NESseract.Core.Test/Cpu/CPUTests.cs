using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Bus;
using NESseract.Core.Cpu.Definitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace NESseract.Core.Test.Cpu
{
   [TestClass]
   public class CPUTests
   {
      [TestMethod]
      public void CPUOpCodeHandlerCountTest()
      {
         Assert.AreEqual(151, OpCodeDefinitions.OpCodeList.Count(x => !x.IllegalOpCode));
      }

      [TestMethod]
      public void ROMTest()
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
      public void CPUTest()
      {
         var rom = Resource.nestest;

         var romLog = new ROMLog();
         romLog.Parse(Resource.nestestlog);

         var cpu = new Core.Cpu.CPU
         {
            LoggingModeEnabled = true,
         };

         cpu.PowerUp();

         cpu.LoadROM(rom);

         var testLimit = 5259;

         var cpuTickStates = new List<Core.Cpu.CPUTickState>();

         for (var i = 0; i < testLimit; i++)
         {
            cpu.Tick();

            cpuTickStates.Add(cpu.CPUTickState);
         }

         for (var i = 0; i < testLimit; i++)
         {
            Debug.WriteLine(cpuTickStates[i].Log);

            Assert.AreEqual(romLog.ROMLogLines[i].PC, cpuTickStates[i].PC);
            Assert.AreEqual(romLog.ROMLogLines[i].OpCode, cpuTickStates[i].OpCode);
            Assert.AreEqual(romLog.ROMLogLines[i].Operand1, cpuTickStates[i].Operand1);
            Assert.AreEqual(romLog.ROMLogLines[i].Operand2, cpuTickStates[i].Operand2);
            Assert.AreEqual(romLog.ROMLogLines[i].NemonicSyntax, cpuTickStates[i].NemonicSyntax);
            Assert.AreEqual(romLog.ROMLogLines[i].A, cpuTickStates[i].A);
            Assert.AreEqual(romLog.ROMLogLines[i].X, cpuTickStates[i].X);
            Assert.AreEqual(romLog.ROMLogLines[i].Y, cpuTickStates[i].Y);
            Assert.AreEqual(romLog.ROMLogLines[i].P, cpuTickStates[i].P);
            Assert.AreEqual(romLog.ROMLogLines[i].CYC, cpuTickStates[i].CYC);
         }
      }
   }
}
