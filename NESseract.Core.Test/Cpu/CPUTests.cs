using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.Definitions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NESseract.Core.Rom;

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
      public void CPUTest()
      {
         var rom = new ROM(Resource.nestest);

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
