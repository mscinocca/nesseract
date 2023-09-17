using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes;

[TestClass]
public class AbsoluteYAddressingModeTests : BaseAddressingModeTests<AbsoluteYAddressingMode>
{
   [TestMethod]
   public void GetValueTest()
   {
      cpuRegisters.Y = 0x10;

      var @value = addressingMode.GetAddress(cpuMemory, cpuRegisters, 0x32, 0x40, out _);

      Assert.AreEqual(0x4042, value);

   }
   [TestMethod]
   public void GetSyntaxTest()
   {
      cpuRegisters.Y = 0x10;

      var syntax = addressingMode.GetSyntax(cpuMemory, cpuRegisters, 0x32, 0x40);

      Assert.AreEqual("$4032,Y @ 4042", syntax);
   }
}