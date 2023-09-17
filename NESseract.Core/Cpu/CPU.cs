using NESseract.Core.Rom;
using System.Collections.Generic;

namespace NESseract.Core.Cpu;

public partial class CPU
{
   public byte Accumulator;

   public readonly CPUMemory Memory;
   private readonly CPURegisters _registers;

   private readonly Dictionary<byte, OpCodeHandler> _opCodeHandlers;

   private ushort _counter;

   public bool LoggingModeEnabled { get; init; }

   public CPUTickState CPUTickState { get; private set; }

   public CPU()
   {
      Memory = new CPUMemory();
      _registers = new CPURegisters();

      _opCodeHandlers = new Dictionary<byte, OpCodeHandler>();

      InitializeOpCodeHandlers();
   }

   public void PowerUp()
   {
      _registers.PS = 0x20;
      _registers.I_InterruptDisable = 1;

      _registers.A = 0x00;
      _registers.X = 0x00;
      _registers.Y = 0x00;

      _registers.SP = 0xFD;

      Memory[0x4017] = 0x00;
      Memory[0x4015] = 0x00;

      for (ushort i = 0x4000; i <= 0x400F; i++)
      {
         Memory[i] = 0x00;
      }

      for (ushort i = 0x4010; i <= 0x4013; i++)
      {
         Memory[i] = 0x00;
      }

      _counter = 7;
   }

   public void Reset()
   {
      _registers.SP -= 0x03;

      _registers.I_InterruptDisable = 1;

      Memory[0x4015] = 0x00;
   }
      
   public void LoadROM(ROM rom)
   {
      Memory.SetBlock(rom.GetPRGROMBank(0), 0, 0x8000, 0x4000);

      Memory.SetBlock(
         rom.NumberOfPRGROMBanks > 1 ? 
            rom.GetPRGROMBank(1) : 
            rom.GetPRGROMBank(0), 
         0, 0xC000, 0x4000);

      _registers.PC = 0xC000;
   }

   public void Tick()
   {
      var registerPC = _registers.PC;

      var opCode = Memory[_registers.PC++];

      var opCodeHandler = _opCodeHandlers[opCode];

      byte operand1 = 0;
      byte operand2 = 0;

      if (opCodeHandler.OpCodeDefinition.InstructionBytes >= 2)
      {
         operand1 = Memory[_registers.PC++];
      }

      if (opCodeHandler.OpCodeDefinition.InstructionBytes == 3)
      {
         operand2 = Memory[_registers.PC++];
      }

      if (LoggingModeEnabled)
      {
         CPUTickState = new CPUTickState
         {
            PC = registerPC,
            OpCode = opCode,
            Operand1 = operand1,
            Operand2 = operand2,
            InstructionBytes = opCodeHandler.OpCodeDefinition.InstructionBytes,
            Mnemonic = opCodeHandler.OpCodeDefinition.Mnemonic,
            AddressSyntax = opCodeHandler.AddressingMode.GetSyntax(Memory, _registers, operand1, operand2),
            OperationSyntax = opCodeHandler.Operation.GetSyntax(opCodeHandler.OpCodeDefinition, opCodeHandler.AddressingMode, Memory, _registers, operand1, operand2),
            IllegalOpCode = opCodeHandler.OpCodeDefinition.IllegalOpCode,
            A = _registers.A,
            X = _registers.X,
            Y = _registers.Y,
            P = _registers.PS,
            SP = _registers.SP,
            CYC = _counter,
         };
      }

      var cycles = opCodeHandler.Execute(Memory, _registers, operand1, operand2);

      _counter += cycles;
   }
}