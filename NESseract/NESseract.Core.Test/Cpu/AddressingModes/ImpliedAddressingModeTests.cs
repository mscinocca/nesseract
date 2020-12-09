﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESseract.Core.Cpu.AddressingModes;

namespace NESseract.Core.Test.Cpu.AddressingModes
{
   [TestClass]
   public class ImpliedAddressingModeTests : BaseAddressingModeTests<ImpliedAddressingMode>
   {
      [TestMethod]
      public void GetValueTest()
      {
         cpuMemory.Memory[0x32] = 0x35;
         var @value = addressingMode.GetValue(cpuMemory, cpuRegisters, 0x32, 0x40, out _);

         Assert.AreEqual(0x00, value);
      }

      [TestMethod]
      public void GetSyntaxTest()
      {
         var syntax = addressingMode.GetSyntax(0x32, 0x40);

         Assert.AreEqual(string.Empty, syntax);
      }
   }
}
