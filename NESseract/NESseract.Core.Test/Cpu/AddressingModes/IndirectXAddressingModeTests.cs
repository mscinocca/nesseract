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

         cpuMemory.Memory[0x24] = 0x74;
         cpuMemory.Memory[0x25] = 0x20;

         cpuMemory.Memory[0x2074] = 0x45;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x20, 0x00);

         Assert.AreEqual(0x45, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("($32,X)", syntax);
      }
   }
}
