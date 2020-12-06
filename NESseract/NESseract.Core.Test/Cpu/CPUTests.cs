using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace NESseract.Core.Test.Cpu
{
   [TestClass]
   public class CPUTests
   {
      [TestMethod]
      public void CPUOpCodeHandlerCountTest()
      {
         var cpu = new Core.Cpu.CPU();

         Assert.AreEqual(151, cpu.OpCodeDefinitions.Count);
      }

      [TestMethod]
      public unsafe void ROMTest()
      {
         var rom = Resource.nestest;
         var romMemory = new Span<byte>(Resource.nestest);

         var identifier = Encoding.ASCII.GetString(rom, 0, 3);
         var fileFormat = rom[3];
         var numberOfBanks = rom[4];
         var numberOfVBanks = rom[5];
         var controlByte1 = rom[6];
         var controlByte2 = rom[7];
         var numberOfRAMBanks = rom[8];
         var reserved = romMemory.Slice(9, 7);

         var cpu = new Core.Cpu.CPU();
         cpu.LoadROM(rom);
         cpu.SetProgramCounter(0xC000);
         cpu.Tick();

         Assert.AreEqual(@"NES", identifier);
         Assert.AreEqual(0x1A, fileFormat);

         //cpu.ADC_IMM(10);
      }

      [TestMethod]
      public void BinaryMathTest1()
      {
         sbyte operand1 = 1;
         byte uoperand1 = (byte)operand1;

         sbyte operand2 = 1;
         byte uoperand2 = (byte)operand2;

         var result = operand1 + operand2;
         var uresult = uoperand1 + uoperand2;

         var curesult = uresult > 0xFF;

         var vresult = result > 127 || result < -128;

         Assert.IsFalse(curesult);

         Assert.IsFalse(vresult);
      }

      [TestMethod]
      public void BinaryMathTest2()
      {
         var size = sizeof(byte);
         var size1 = sizeof(sbyte);

         sbyte operand1 = 1;
         byte uoperand1 = (byte)operand1;

         sbyte operand2 = -1;
         byte uoperand2 = (byte)operand2;

         byte what = 129;
         sbyte swhat = (sbyte)what;

         byte what1 = 0x80;
         sbyte what12 = (sbyte)what1;

         byte what2 = 0xFF;
         sbyte what22 = (sbyte)what2;

         var result = operand1 + operand2;
         var result2 = (sbyte)uoperand1 + (sbyte)uoperand2;
         var result3 = (sbyte)(uoperand1 + uoperand2);
         var uresult = uoperand1 + uoperand2;


         var curesult = uresult > 0xFF;

         var vresult = result > 127 || result < -128;

         Assert.IsTrue(curesult);

         Assert.IsFalse(vresult);
      }

      [TestMethod]
      public void BinaryMathTest3()
      {
         sbyte operand1 = 127;
         byte uoperand1 = (byte)operand1;

         sbyte operand2 = 1;
         byte uoperand2 = (byte)operand2;

         var result = operand1 + operand2;
         var uresult = uoperand1 + uoperand2;

         var curesult = uresult > 0xFF;

         var vresult = result > 127 || result < -128;

         Assert.IsFalse(curesult);

         Assert.IsTrue(vresult);
      }

      [TestMethod]
      public void BinaryMathTest4()
      {
         sbyte operand1 = -128;
         byte uoperand1 = (byte)operand1;

         sbyte operand2 = -1;
         byte uoperand2 = (byte)operand2;

         var result = operand1 + operand2;
         var result2 = (sbyte)uoperand1 + (sbyte)uoperand2;
         var result3 = (sbyte)(uoperand1 + uoperand2);
         var uresult = uoperand1 + uoperand2;

         var curesult = uresult > 0xFF;

         var vresult = result > 127 || result < -128;

         Assert.IsTrue(curesult);

         Assert.IsTrue(vresult);
      }
   }
}
