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

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x32, 0x40);

         Assert.AreEqual(0x67, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("$32", syntax);
      }
   }
}
