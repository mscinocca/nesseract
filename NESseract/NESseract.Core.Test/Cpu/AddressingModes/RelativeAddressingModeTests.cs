using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class RelativeAddressingModeTests : BaseAddressingModeTests<RelativeAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuRegisters.PC = 0x35;

         var @value = addressingMode.GetAddress(cpuMemory, cpuRegisters, 0x32, 0x40, out _);

         Assert.AreEqual(0x67, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         cpuRegisters.PC = 0x4000;

         var syntax = addressingMode.GetSyntax(cpuRegisters, 0x32, 0x40);

         Assert.AreEqual("$4032", syntax);
      }
   }
}
