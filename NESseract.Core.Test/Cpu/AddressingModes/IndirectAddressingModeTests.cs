using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes;

[TestClass]
public class IndirectAddressingModeTests : BaseAddressingModeTests<IndirectAddressingMode>
{
   [TestMethod]
   public unsafe void GetValueTest()
   {
      cpuMemory[0x1000] = 0x52;
      cpuMemory[0x1001] = 0x3A;

      var @value = addressingMode.GetAddress(cpuMemory, cpuRegisters, 0x00, 0x10, out _);

      Assert.AreEqual(0x3A52, value);
   }

   [TestMethod]
   public void GetValueWrapAroundTest()
   {
      cpuMemory[0x4000] = 0x40;
      cpuMemory[0x40FF] = 0x80;
      cpuMemory[0x4100] = 0x50;

      var @value = addressingMode.GetAddress(cpuMemory, cpuRegisters, 0xFF, 0x40, out _);

      Assert.AreEqual(0x4080, value);
   }

   [TestMethod]
   public void GetSyntaxTest()
   {
      cpuMemory[0x1000] = 0x52;
      cpuMemory[0x1001] = 0x3A;

      var syntax = addressingMode.GetSyntax(cpuMemory, cpuRegisters, 0x00, 0x10);

      Assert.AreEqual("($1000) = 3A52", syntax);
   }
}