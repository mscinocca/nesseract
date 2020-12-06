using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class IndirectAddressingModeTests : BaseAddressingModeTests<IndirectAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuMemory.Memory[0x1000] = 0x52;
         cpuMemory.Memory[0x1001] = 0x3A;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x00, 0x10);

         Assert.AreEqual(0x3A52, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("($4032)", syntax);
      }
   }
}
