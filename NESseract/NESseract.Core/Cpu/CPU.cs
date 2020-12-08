using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      public byte Accumulator;

      public readonly CPURegisters Registers;
      public readonly CPUMemory Memory;

      public readonly Dictionary<byte, OpCodeHandler> OpCodeHandlers;

      private byte[] Rom;

      private byte CurrentOpCode;

      private ushort Counter;

      public CPU()
      {
         Registers = new CPURegisters();
         Memory = new CPUMemory();

         OpCodeHandlers = new Dictionary<byte, OpCodeHandler>();

         InitializeOpCodeHandlers();
      }

      public void LoadROM(byte[] rom)
      {
         Rom = rom;

         Array.Copy(Rom, 16, Memory.Memory, 0x8000, 0x4000);
         Array.Copy(Rom, 16, Memory.Memory, 0xC000, 0x4000);
      }

      public void SetProgramCounter(ushort programCounter)
      {
         Registers.PC = programCounter;
      }

      public void Tick()
      {
         CurrentOpCode = Memory.Memory[Registers.PC];

         var operand1 = Memory.Memory[Registers.PC + 1];

         var operand2 = Memory.Memory[Registers.PC + 2];

         ProcessOpCode(CurrentOpCode, operand1, operand2);
      }

      public void ProcessOpCode(byte opCode, byte operand1, byte operand2)
      {
         var opCodeHandler = OpCodeHandlers[opCode];

         var log = opCodeHandler.GetLog(Memory, Registers, Counter, operand1, operand2);

         Debug.WriteLine(log);
      }
   }
}
