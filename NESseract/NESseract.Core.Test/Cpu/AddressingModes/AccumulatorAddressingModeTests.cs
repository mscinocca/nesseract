using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class AccumulatorAddressingModeTests : BaseAddressingModeTests<AccumulatorAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuRegisters.A = 0x35;
         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x32, 0x40, out _);

         Assert.AreEqual(0x35, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(cpuMemory, cpuRegisters, 0x32, 0x40);

         Assert.AreEqual("A", syntax);
      }
   }
}
