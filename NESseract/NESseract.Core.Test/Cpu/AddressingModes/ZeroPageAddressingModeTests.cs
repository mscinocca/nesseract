using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class ZeroPageAddressingModeTests : BaseAddressingModeTests<ZeroPageAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuMemory.Memory[0x32] = 0x35;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x32, 0x40, out _);

         Assert.AreEqual(0x35, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(cpuRegisters, 0x32, 0x40);

         Assert.AreEqual("$32", syntax);
      }
   }
}
