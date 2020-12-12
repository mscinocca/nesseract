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

         PowerUp();
      }

      public void PowerUp()
      {
         Registers.PS = 0x20;
         Registers.I_InterruptDisable = 1;

         Registers.A = 0x00;
         Registers.X = 0x00;
         Registers.Y = 0x00;

         Registers.SP = 0xFD;

         Memory.Memory[0x4017] = 0x00;
         Memory.Memory[0x4015] = 0x00;

         for (var i = 0x4000; i <= 0x400F; i++)
         {
            Memory.Memory[i] = 0x00;
         }

         for (var i = 0x4010; i <= 0x4013; i++)
         {
            Memory.Memory[i] = 0x00;
         }

         Counter = 7;
      }

      public void Reset()
      {
         Registers.SP -= 0x03;

         Registers.I_InterruptDisable = 1;

         Memory.Memory[0x4015] = 0x00;
      }
      
      public void LoadROM(byte[] rom)
      {
         Rom = rom;

         Array.Copy(Rom, 16, Memory.Memory, 0x8000, 0x4000);
         Array.Copy(Rom, 16, Memory.Memory, 0xC000, 0x4000);

         Registers.PC = 0xC000;
      }

      public CPUTickState Tick()
      {
         var registerPC = Registers.PC;

         CurrentOpCode = Memory.Memory[Registers.PC++];

         var opCodeHandler = OpCodeHandlers[CurrentOpCode];

         byte operand1 = 0;
         byte operand2 = 0;

         if (opCodeHandler.OpCodeDefinition.InstructionBytes >= 2)
         {
            operand1 = Memory.Memory[Registers.PC++];
         }

         if (opCodeHandler.OpCodeDefinition.InstructionBytes == 3)
         {
            operand2 = Memory.Memory[Registers.PC++];
         }

         var cpuTickState = new CPUTickState
         {
            PC = registerPC,
            OpCode = CurrentOpCode,
            Operand1 = operand1,
            Operand2 = operand2,
            NemonicSyntax = $"{opCodeHandler.OpCodeDefinition.Nemonic} {(opCodeHandler.AddressingMode.GetSyntax(Memory, Registers, operand1, operand2) + " " + opCodeHandler.Operation.GetSyntax(opCodeHandler.OpCodeDefinition, opCodeHandler.AddressingMode, Memory, Registers, operand1, operand2))}".Trim(),
            A = Registers.A,
            X = Registers.X,
            Y = Registers.Y,
            P = Registers.PS,
            SP = Registers.SP,
            CYC = Counter,
         };

         var log = opCodeHandler.GetLog(cpuTickState);

         Debug.WriteLine(log);

         var cycles = opCodeHandler.Execute(Memory, Registers, operand1, operand2);

         Counter += cycles;

         return cpuTickState;
      }
   }
}
