using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;
using System;

namespace NESseract.Core.Cpu
{
   public partial class CPU
   {
      private IOperation adcOperation;
      private IOperation andOperation;

      private IAddressingMode noneAddressingMode;
      private IAddressingMode absoluteAddressingMode;
      private IAddressingMode absoluteXAddressingMode;
      private IAddressingMode absoluteYAddressingMode;
      private IAddressingMode accumulatorAddressingMode;
      private IAddressingMode immediateAddressingMode;
      private IAddressingMode impliedAddressingMode;
      private IAddressingMode indirectAddressingMode;
      private IAddressingMode indirectXAddressingMode;
      private IAddressingMode indirectYAddressingMode;
      private IAddressingMode relativeAddressingMode;
      private IAddressingMode zeroPageAddressingMode;
      private IAddressingMode zeroPageXAddressingMode;
      private IAddressingMode zeroPageYAddressingMode;

      private void InitializeOpCodeHandlers()
      {
         adcOperation = new ADCOperation();
         andOperation = new ANDOperation();

         noneAddressingMode = new NoneAddressingMode();
         absoluteAddressingMode = new AbsoluteAddressingMode();
         absoluteXAddressingMode = new AbsoluteXAddressingMode();
         absoluteYAddressingMode = new AbsoluteYAddressingMode();
         accumulatorAddressingMode = new AccumulatorAddressingMode();
         immediateAddressingMode = new ImmediateAddressingMode();
         impliedAddressingMode = new ImpliedAddressingMode();
         indirectAddressingMode = new IndirectAddressingMode();
         indirectXAddressingMode = new IndirectXAddressingMode();
         indirectYAddressingMode = new IndirectYAddressingMode();
         relativeAddressingMode = new RelativeAddressingMode();
         zeroPageAddressingMode = new ZeroPageAddressingMode();
         zeroPageXAddressingMode = new ZeroPageXAddressingMode();
         zeroPageYAddressingMode = new ZeroPageYAddressingMode();

         OpCodeDefinitions.OpCodeList.ForEach(x =>
         {
            OpCodeHandlers.Add(x.OpCode, new OpCodeHandler
            {
               OpCodeDefinition = x,
               Operation = x.Nemonic switch
               {
                  OpCode.ADC => adcOperation,
                  OpCode.AND => andOperation,
                  //OpCode.ASL => throw new NotImplementedException(),
                  //OpCode.BCC => throw new NotImplementedException(),
                  //OpCode.BCS => throw new NotImplementedException(),
                  //OpCode.BEQ => throw new NotImplementedException(),
                  //OpCode.BIT => throw new NotImplementedException(),
                  //OpCode.BMI => throw new NotImplementedException(),
                  //OpCode.BNE => throw new NotImplementedException(),
                  //OpCode.BPL => throw new NotImplementedException(),
                  //OpCode.BRK => throw new NotImplementedException(),
                  //OpCode.BVC => throw new NotImplementedException(),
                  //OpCode.BVS => throw new NotImplementedException(),
                  //OpCode.CLC => throw new NotImplementedException(),
                  //OpCode.CLD => throw new NotImplementedException(),
                  //OpCode.CLI => throw new NotImplementedException(),
                  //OpCode.CLV => throw new NotImplementedException(),
                  //OpCode.CMP => throw new NotImplementedException(),
                  //OpCode.CPX => throw new NotImplementedException(),
                  //OpCode.CPY => throw new NotImplementedException(),
                  //OpCode.DEC => throw new NotImplementedException(),
                  //OpCode.DEX => throw new NotImplementedException(),
                  //OpCode.DEY => throw new NotImplementedException(),
                  //OpCode.EOR => throw new NotImplementedException(),
                  //OpCode.INC => throw new NotImplementedException(),
                  //OpCode.INX => throw new NotImplementedException(),
                  //OpCode.INY => throw new NotImplementedException(),
                  //OpCode.JMP => throw new NotImplementedException(),
                  //OpCode.JSR => throw new NotImplementedException(),
                  //OpCode.LDA => throw new NotImplementedException(),
                  //OpCode.LDX => throw new NotImplementedException(),
                  //OpCode.LDY => throw new NotImplementedException(),
                  //OpCode.LSR => throw new NotImplementedException(),
                  //OpCode.NOP => throw new NotImplementedException(),
                  //OpCode.ORA => throw new NotImplementedException(),
                  //OpCode.PHA => throw new NotImplementedException(),
                  //OpCode.PHP => throw new NotImplementedException(),
                  //OpCode.PLA => throw new NotImplementedException(),
                  //OpCode.PLP => throw new NotImplementedException(),
                  //OpCode.ROL => throw new NotImplementedException(),
                  //OpCode.ROR => throw new NotImplementedException(),
                  //OpCode.RTI => throw new NotImplementedException(),
                  //OpCode.RTS => throw new NotImplementedException(),
                  //OpCode.SBC => throw new NotImplementedException(),
                  //OpCode.SEC => throw new NotImplementedException(),
                  //OpCode.SED => throw new NotImplementedException(),
                  //OpCode.SEI => throw new NotImplementedException(),
                  //OpCode.STA => throw new NotImplementedException(),
                  //OpCode.STX => throw new NotImplementedException(),
                  //OpCode.STY => throw new NotImplementedException(),
                  //OpCode.TAX => throw new NotImplementedException(),
                  //OpCode.TAY => throw new NotImplementedException(),
                  //OpCode.TSX => throw new NotImplementedException(),
                  //OpCode.TXA => throw new NotImplementedException(),
                  //OpCode.TXS => throw new NotImplementedException(),
                  //OpCode.TYA => throw new NotImplementedException(),
                  //_ => throw new NotImplementedException(),
                  _ => adcOperation,
               },
               AddressingMode = x.AddressingMode switch
               {
                  AddressingMode.NON => noneAddressingMode,
                  AddressingMode.ZP0 => zeroPageAddressingMode,
                  AddressingMode.ZPX => zeroPageXAddressingMode,
                  AddressingMode.ZPY => zeroPageYAddressingMode,
                  AddressingMode.ABS => absoluteAddressingMode,
                  AddressingMode.ABX => absoluteXAddressingMode,
                  AddressingMode.ABY => absoluteYAddressingMode,
                  AddressingMode.IND => indirectAddressingMode,
                  AddressingMode.IDX => indirectXAddressingMode,
                  AddressingMode.IDY => indirectYAddressingMode,
                  AddressingMode.IMP => impliedAddressingMode,
                  AddressingMode.ACC => accumulatorAddressingMode,
                  AddressingMode.IMM => immediateAddressingMode,
                  AddressingMode.REL => relativeAddressingMode,
                  _ => throw new NotImplementedException(),
               }
            });
         });
      }
   }
}
