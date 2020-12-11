using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class ImpliedAddressingModeTests : BaseAddressingModeTests<ImpliedAddressingMode>
   {
      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(cpuRegisters, 0x32, 0x40);

         Assert.AreEqual(string.Empty, syntax);
      }
   }
}
