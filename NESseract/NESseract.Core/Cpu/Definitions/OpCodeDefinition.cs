namespace NESseract.Core.Cpu.Definitions
{
   public class OpCodeDefinition
   {
      public byte OpCode;

      public OpCodes Nemonic;

      public AddressingModes AddressingMode;

      public byte InstructionBytes;

      public byte ExecutionCycles;

      public string AffectedFlags;

      public OpCodeDefinition(
         byte opCode,
         OpCodes nemonic,
         AddressingModes addressingMode,
         byte instructionBytes,
         byte executionCycles,
         string affectedFlags)
      {
         OpCode = opCode;
         Nemonic = nemonic;
         AddressingMode = addressingMode;
         InstructionBytes = instructionBytes;
         ExecutionCycles = executionCycles;
         AffectedFlags = affectedFlags;
      }
   }
}
