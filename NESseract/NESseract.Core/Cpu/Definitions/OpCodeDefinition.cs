namespace NESseract.Core.Cpu.Definitions
{
   public class OpCodeDefinition
   {
      public byte OpCode;

      public OpCode Nemonic;

      public AddressingMode AddressingMode;

      public byte InstructionBytes;

      public byte ExecutionCycles;

      public bool AddExecutionCycleOnPageBoundaryCross;

      public string AffectedFlags;

      public OpCodeDefinition(
         byte opCode,
         OpCode nemonic,
         AddressingMode addressingMode,
         byte instructionBytes,
         byte executionCycles,
         bool addExecutionCycleOnPageBoundaryCross,
         string affectedFlags)
      {
         OpCode = opCode;
         Nemonic = nemonic;
         AddressingMode = addressingMode;
         InstructionBytes = instructionBytes;
         ExecutionCycles = executionCycles;
         AddExecutionCycleOnPageBoundaryCross = addExecutionCycleOnPageBoundaryCross;
         AffectedFlags = affectedFlags;
      }
   }
}
