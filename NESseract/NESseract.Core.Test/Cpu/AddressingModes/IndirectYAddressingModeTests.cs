using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class IndirectYAddressingModeTests : BaseAddressingModeTests<IndirectYAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuRegisters.Y = 0x10;

         cpuMemory.Memory[0x86] = 0x28;
         cpuMemory.Memory[0x87] = 0x40;

         cpuMemory.Memory[0x4038] = 0x45;

         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x86, 0x00, out _);

         Assert.AreEqual(0x45, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("($32),Y", syntax);
      }
   }
}
