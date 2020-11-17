using System;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      private readonly CPURegisters Registers;
      private readonly CPUMemory Memory;

      private byte CurrentOpCode;

      private ushort Counter;

      public CPU()
      {
         Registers = new CPURegisters();
         Memory = new CPUMemory();

         InitializeOpCodeDefinitions();
      }

      public void Tick()
      {
         CurrentOpCode = Memory.Memory.ToArray()[Registers.ProgramCounter++];
      }

      public void ProcessOpCode(byte opCode, byte operand1, byte operand2)
      {
         var opCodeDefinition = opCodeTable[opCode];
         
         switch(opCodeDefinition.Nemonic)
         {
            case OpCodes.ADC:
               break;

            case OpCodes.AND:
               break;
         }
      }
   }
}
