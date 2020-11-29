using System;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      public byte Accumulator;

      public readonly CPURegisters Registers;
      public readonly CPUMemory Memory;

      private byte[] Rom;

      private byte CurrentOpCode;

      private ushort Counter;

      public CPU()
      {
         Registers = new CPURegisters();
         Memory = new CPUMemory();

         InitializeOpCodeDefinitions();
      }

      public void LoadROM(byte[] rom)
      {
         Rom = rom;

         Array.Copy(Rom, 16, Memory.Memory, 0x8000, 0x4000);
         Array.Copy(Rom, 16, Memory.Memory, 0xC000, 0x4000);
      }

      public void SetProgramCounter(ushort programCounter)
      {
         Registers.ProgramCounter = programCounter;
      }

      public void Tick()
      {
         CurrentOpCode = Memory.Memory[Registers.ProgramCounter];

         var operand1 = Memory.Memory[Registers.ProgramCounter + 1];

         var operand2 = Memory.Memory[Registers.ProgramCounter + 2];

         ProcessOpCode(CurrentOpCode, operand1, operand2);
      }

      public void ProcessOpCode(byte opCode, byte operand1, byte operand2)
      {
         var opCodeHandler = opCodeTable[opCode];

         Console.WriteLine($"{Registers.ProgramCounter} {opCode:X} {operand1:X} {operand2:X} {opCodeHandler.Nemonic}");
      }
   }
}
