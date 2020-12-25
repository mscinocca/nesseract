namespace NESseract.Core.Cpu.Definitions
{
   public struct OpCodeDefinition
   {
      public byte OpCode;

      public OpCode Nemonic;

      public AddressingMode AddressingMode;

      public byte InstructionBytes;

      public byte ExecutionCycles;

      public bool AddExecutionCycleOnPageBoundaryCross;

      public string AffectedFlags;

      public bool IllegalOpCode;

      public OpCodeDefinition(
         byte opCode,
         OpCode nemonic,
         AddressingMode addressingMode,
         byte instructionBytes,
         byte executionCycles,
         bool addExecutionCycleOnPageBoundaryCross,
         string affectedFlags,
         bool illegalOpCode = false)
      {
         OpCode = opCode;
         Nemonic = nemonic;
         AddressingMode = addressingMode;
         InstructionBytes = instructionBytes;
         ExecutionCycles = executionCycles;
         AddExecutionCycleOnPageBoundaryCross = addExecutionCycleOnPageBoundaryCross;
         AffectedFlags = affectedFlags;
         IllegalOpCode = illegalOpCode;
      }
   }
}
