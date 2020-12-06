using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class AbsoluteXAddressingModeTests : BaseAddressingModeTests<AbsoluteXAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuRegisters.X = 0x10;

         cpuMemory.Memory[0x4042] = 0x45;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x32, 0x40);

         Assert.AreEqual(0x45, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("$4032,X", syntax);
      }
   }
}
