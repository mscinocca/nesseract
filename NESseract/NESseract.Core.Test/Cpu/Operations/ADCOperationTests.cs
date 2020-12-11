using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;
using System.Linq;

namespace NESseract.Core.Test.Cpu.Operations
{
   [TestClass]
   public class ADCOperationTests : BaseOperationTests<ADCOperation>
   {
      [TestMethod]
      public void ImmediateTest()
      {
         var opCodeDefinition = OpCodeDefinitions.OpCodeList.FirstOrDefault(x => x.Nemonic == OpCode.ADC && x.AddressingMode == AddressingMode.IMM);

         cpuRegisters.A = 0x30;

         operation.Execute(opCodeDefinition, immediateAddressingMode, cpuMemory, cpuRegisters, 0x32, 0x00);

         Assert.AreEqual(0x62, cpuRegisters.A);
      }

      [TestMethod]
      public void ZeroPageTest()
      {
         var opCodeDefinition = OpCodeDefinitions.OpCodeList.FirstOrDefault(x => x.Nemonic == OpCode.ADC && x.AddressingMode == AddressingMode.ZP0);

         cpuRegisters.A = 0x30;

         cpuMemory.Memory[0x45] = 0x32;

         operation.Execute(opCodeDefinition, zeroPageAddressingMode, cpuMemory, cpuRegisters, 0x45, 0x00);

         Assert.AreEqual(0x62, cpuRegisters.A);
      }
   }
}
