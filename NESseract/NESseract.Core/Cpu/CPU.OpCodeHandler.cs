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
      private IOperation bccOperation;
      private IOperation bcsOperation;
      private IOperation beqOperation;
      private IOperation bitOperation;
      private IOperation bmiOperation;
      private IOperation bneOperation;
      private IOperation bplOperation;
      private IOperation bvcOperation;
      private IOperation bvsOperation;
      private IOperation clcOperation;
      private IOperation cldOperation;
      private IOperation cliOperation;
      private IOperation clvOperation;
      private IOperation cmpOperation;
      private IOperation jmpOperation;
      private IOperation jsrOperation;
      private IOperation ldaOperation;
      private IOperation ldxOperation;
      private IOperation ldyOperation;
      private IOperation nopOperation;
      private IOperation oraOperation;
      private IOperation phaOperation;
      private IOperation phpOperation;
      private IOperation plaOperation;
      private IOperation plpOperation;
      private IOperation rtsOperation;
      private IOperation secOperation;
      private IOperation sedOperation;
      private IOperation seiOperation;
      private IOperation staOperation;
      private IOperation stxOperation;
      private IOperation styOperation;

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
         bccOperation = new BCCOperation();
         bcsOperation = new BCSOperation();
         beqOperation = new BEQOperation();
         bitOperation = new BITOperation();
         bmiOperation = new BMIOperation();
         bneOperation = new BNEOperation();
         bplOperation = new BPLOperation();
         bvcOperation = new BVCOperation();
         bvsOperation = new BVSOperation();
         clcOperation = new CLCOperation();
         cldOperation = new CLDOperation();
         cliOperation = new CLIOperation();
         clvOperation = new CLVOperation();
         cmpOperation = new CMPOperation();
         jmpOperation = new JMPOperation();
         jsrOperation = new JSROperation();
         ldaOperation = new LDAOperation();
         ldxOperation = new LDXOperation();
         ldyOperation = new LDYOperation();
         nopOperation = new NOPOperation();
         oraOperation = new ORAOperation();
         phaOperation = new PHAOperation();
         phpOperation = new PHPOperation();
         plaOperation = new PLAOperation();
         plpOperation = new PLPOperation();
         rtsOperation = new RTSOperation();
         secOperation = new SECOperation();
         sedOperation = new SEDOperation();
         seiOperation = new SEIOperation();
         staOperation = new STAOperation();
         stxOperation = new STXOperation();
         styOperation = new STYOperation();

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
                  OpCode.BCC => bccOperation,
                  OpCode.BCS => bcsOperation,
                  OpCode.BEQ => beqOperation,
                  OpCode.BIT => bitOperation,
                  OpCode.BMI => bmiOperation,
                  OpCode.BNE => bneOperation,
                  OpCode.BPL => bplOperation,
                  //OpCode.BRK => throw new NotImplementedException(),
                  OpCode.BVC => bvcOperation,
                  OpCode.BVS => bvsOperation,
                  OpCode.CLC => clcOperation,
                  OpCode.CLD => cldOperation,
                  OpCode.CLI => cliOperation,
                  OpCode.CLV => clvOperation,
                  OpCode.CMP => cmpOperation,
                  //OpCode.CPX => throw new NotImplementedException(),
                  //OpCode.CPY => throw new NotImplementedException(),
                  //OpCode.DEC => throw new NotImplementedException(),
                  //OpCode.DEX => throw new NotImplementedException(),
                  //OpCode.DEY => throw new NotImplementedException(),
                  //OpCode.EOR => throw new NotImplementedException(),
                  //OpCode.INC => throw new NotImplementedException(),
                  //OpCode.INX => throw new NotImplementedException(),
                  //OpCode.INY => throw new NotImplementedException(),
                  OpCode.JMP => jmpOperation,
                  OpCode.JSR => jsrOperation,
                  OpCode.LDA => ldaOperation,
                  OpCode.LDX => ldxOperation,
                  OpCode.LDY => ldyOperation,
                  //OpCode.LSR => throw new NotImplementedException(),
                  OpCode.NOP => nopOperation,
                  OpCode.ORA => oraOperation,
                  OpCode.PHA => phaOperation,
                  OpCode.PHP => phpOperation,
                  OpCode.PLA => plaOperation,
                  OpCode.PLP => plpOperation,
                  //OpCode.ROL => throw new NotImplementedException(),
                  //OpCode.ROR => throw new NotImplementedException(),
                  //OpCode.RTI => throw new NotImplementedException(),
                  OpCode.RTS => rtsOperation,
                  //OpCode.SBC => throw new NotImplementedException(),
                  OpCode.SEC => secOperation,
                  OpCode.SED => sedOperation,
                  OpCode.SEI => seiOperation,
                  OpCode.STA => staOperation,
                  OpCode.STX => stxOperation,
                  OpCode.STY => styOperation,
                  //OpCode.TAX => throw new NotImplementedException(),
                  //OpCode.TAY => throw new NotImplementedException(),
                  //OpCode.TSX => throw new NotImplementedException(),
                  //OpCode.TXA => throw new NotImplementedException(),
                  //OpCode.TXS => throw new NotImplementedException(),
                  //OpCode.TYA => throw new NotImplementedException(),
                  //_ => throw new NotImplementedException(),
                  _ => nopOperation,
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
