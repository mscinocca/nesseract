using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.Operations;

namespace NESseract.Core.Test.Cpu.Operations
{
   [TestClass]
   public class ADCOperationTests : BaseOperationTests<ADCOperation>
   {
      [TestMethod]
      public void ImmediateTest()
      {
         cpuRegisters.A = 0x30;

         operation.Execute(immediateAddressingMode, cpuMemory, cpuRegisters, 0x32, 0x00);

         Assert.AreEqual(0x62, cpuRegisters.A);
      }

      [TestMethod]
      public void ZeroPageTest()
      {
         cpuRegisters.A = 0x30;

         cpuMemory.Memory[0x45] = 0x32;

         operation.Execute(zeroPageAddressingMode, cpuMemory, cpuRegisters, 0x45, 0x00);

         Assert.AreEqual(0x62, cpuRegisters.A);
      }
   }
}
