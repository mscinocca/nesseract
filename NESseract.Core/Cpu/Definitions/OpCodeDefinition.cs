namespace NESseract.Core.Cpu.Definitions;

public struct OpCodeDefinition
{
   public readonly byte OpCode;

   public readonly OpCode Mnemonic;

   public readonly AddressingMode AddressingMode;

   public readonly byte InstructionBytes;

   public readonly byte ExecutionCycles;

   public readonly bool AddExecutionCycleOnPageBoundaryCross;

   public string AffectedFlags;

   public readonly bool IllegalOpCode;

   public OpCodeDefinition(
      byte opCode,
      OpCode mnemonic,
      AddressingMode addressingMode,
      byte instructionBytes,
      byte executionCycles,
      bool addExecutionCycleOnPageBoundaryCross,
      string affectedFlags,
      bool illegalOpCode = false)
   {
      OpCode = opCode;
      Mnemonic = mnemonic;
      AddressingMode = addressingMode;
      InstructionBytes = instructionBytes;
      ExecutionCycles = executionCycles;
      AddExecutionCycleOnPageBoundaryCross = addExecutionCycleOnPageBoundaryCross;
      AffectedFlags = affectedFlags;
      IllegalOpCode = illegalOpCode;
   }
}