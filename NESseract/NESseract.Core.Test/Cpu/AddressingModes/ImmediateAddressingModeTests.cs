using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class ImmediateAddressingModeTests
   {
      [TestMethod]
      public void GetSyntaxTest()
      {
         var addressingMode = new ImmediateAddressingMode();

         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("#$32", syntax);
      }
   }
}
