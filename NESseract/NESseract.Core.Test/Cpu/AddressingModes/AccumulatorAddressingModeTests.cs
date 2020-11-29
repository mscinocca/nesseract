using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class AccumulatorAddressingModeTests
   {
      [TestMethod]
      public void GetSyntaxTest()
      {
         var addressingMode = new AccumulatorAddressingMode();

         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual("A", syntax);
      }
   }
}
