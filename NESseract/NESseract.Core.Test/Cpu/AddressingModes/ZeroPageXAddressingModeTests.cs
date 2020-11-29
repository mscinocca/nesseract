using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class ZeroPageXAddressingModeTests
   {
      private readonly IAddressingMode addressingMode;

      private readonly CPUMemory cpuMemory;
      private readonly CPURegisters cpuRegisters;

      public ZeroPageXAddressingModeTests()
      {
         addressingMode = new ZeroPageXAddressingMode();

         cpuMemory = new CPUMemory();
         cpuRegisters = new CPURegisters();

         cpuMemory.Memory[0x20] = 0x35;
         cpuRegisters.IndexRegisterX = 0x60;
      }

      [TestMethod]
      public void GetValueTest()
      {
         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0xC0, 0x40);

         Assert.AreEqual(0x35, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("($4032)", syntax);
      }
   }
}
