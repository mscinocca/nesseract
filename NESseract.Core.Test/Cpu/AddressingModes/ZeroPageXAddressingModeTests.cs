using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes;

[TestClass]
public class ZeroPageXAddressingModeTests : BaseAddressingModeTests<ZeroPageXAddressingMode>
{
   [TestMethod]
   public void GetValueTest()
   {
      cpuMemory[0x20] = 0x35;
      cpuRegisters.X = 0x60;

      var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0xC0, 0x40, out _);

      Assert.AreEqual(0x35, value);
   }

   [TestMethod]
   public void GetSyntaxTest()
   {
      cpuRegisters.X = 0x60;

      var syntax = addressingMode.GetSyntax(cpuMemory, cpuRegisters, 0x32, 0x40);

      Assert.AreEqual("$32,X @ 92", syntax);
   }
}