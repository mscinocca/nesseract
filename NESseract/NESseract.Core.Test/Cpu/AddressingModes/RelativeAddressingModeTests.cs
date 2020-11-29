using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class RelativeAddressingModeTests
   {
      [TestMethod]
      public void GetSyntaxTest()
      {
         var addressingMode = new RelativeAddressingMode();

         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("$32", syntax);
      }
   }
}
