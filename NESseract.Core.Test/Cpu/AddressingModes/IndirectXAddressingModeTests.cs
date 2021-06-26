using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class IndirectXAddressingModeTests : BaseAddressingModeTests<IndirectXAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuRegisters.X = 0x04;

         cpuMemory[0x24] = 0x74;
         cpuMemory[0x25] = 0x20;

         cpuMemory[0x2074] = 0x45;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x20, 0x00, out _);

         Assert.AreEqual(0x45, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         cpuRegisters.X = 0x04;

         cpuMemory[0x24] = 0x74;
         cpuMemory[0x25] = 0x20;

         cpuMemory[0x2074] = 0x45;

         var syntax = addressingMode.GetSyntax(cpuMemory, cpuRegisters, 0x20, 0x00);

         Assert.AreEqual($"($20,X) @ 24 = 2074", syntax);
      }
   }
}
