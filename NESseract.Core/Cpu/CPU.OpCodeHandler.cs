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
      private IOperation aslOperation;
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
      private IOperation cpxOperation;
      private IOperation cpyOperation;
      private IOperation decOperation;
      private IOperation dexOperation;
      private IOperation deyOperation;
      private IOperation eorOperation;
      private IOperation incOperation;
      private IOperation inxOperation;
      private IOperation inyOperation;
      private IOperation jmpOperation;
      private IOperation jsrOperation;
      private IOperation laxOperation;
      private IOperation ldaOperation;
      private IOperation ldxOperation;
      private IOperation ldyOperation;
      private IOperation lsrOperation;
      private IOperation nopOperation;
      private IOperation oraOperation;
      private IOperation phaOperation;
      private IOperation phpOperation;
      private IOperation plaOperation;
      private IOperation plpOperation;
      private IOperation rolOperation;
      private IOperation rorOperation;
      private IOperation rtiOperation;
      private IOperation rtsOperation;
      private IOperation sbcOperation;
      private IOperation secOperation;
      private IOperation sedOperation;
      private IOperation seiOperation;
      private IOperation staOperation;
      private IOperation stxOperation;
      private IOperation styOperation;
      private IOperation taxOperation;
      private IOperation tayOperation;
      private IOperation tsxOperation;
      private IOperation txaOperation;
      private IOperation txsOperation;
      private IOperation tyaOperation;

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
         aslOperation = new ASLOperation();
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
         cpxOperation = new CPXOperation();
         cpyOperation = new CPYOperation();
         decOperation = new DECOperation();
         dexOperation = new DEXOperation();
         deyOperation = new DEYOperation();
         eorOperation = new EOROperation();
         incOperation = new INCOperation();
         inxOperation = new INXOperation();
         inyOperation = new INYOperation();
         jmpOperation = new JMPOperation();
         jsrOperation = new JSROperation();
         laxOperation = new LAXOperation();
         ldaOperation = new LDAOperation();
         ldxOperation = new LDXOperation();
         ldyOperation = new LDYOperation();
         lsrOperation = new LSROperation();
         nopOperation = new NOPOperation();
         oraOperation = new ORAOperation();
         phaOperation = new PHAOperation();
         phpOperation = new PHPOperation();
         plaOperation = new PLAOperation();
         plpOperation = new PLPOperation();
         rolOperation = new ROLOperation();
         rorOperation = new ROROperation();
         rtiOperation = new RTIOperation();
         rtsOperation = new RTSOperation();
         sbcOperation = new SBCOperation();
         secOperation = new SECOperation();
         sedOperation = new SEDOperation();
         seiOperation = new SEIOperation();
         staOperation = new STAOperation();
         stxOperation = new STXOperation();
         styOperation = new STYOperation();
         taxOperation = new TAXOperation();
         tayOperation = new TAYOperation();
         tsxOperation = new TSXOperation();
         txaOperation = new TXAOperation();
         txsOperation = new TXSOperation();
         tyaOperation = new TYAOperation();

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
                  OpCode.ASL => aslOperation,
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
                  OpCode.CPX => cpxOperation,
                  OpCode.CPY => cpyOperation,
                  OpCode.DEC => decOperation,
                  OpCode.DEX => dexOperation,
                  OpCode.DEY => deyOperation,
                  OpCode.EOR => eorOperation,
                  OpCode.INC => incOperation,
                  OpCode.INX => inxOperation,
                  OpCode.INY => inyOperation,
                  OpCode.JMP => jmpOperation,
                  OpCode.JSR => jsrOperation,
                  OpCode.LDA => ldaOperation,
                  OpCode.LDX => ldxOperation,
                  OpCode.LDY => ldyOperation,
                  OpCode.LSR => lsrOperation,
                  OpCode.NOP => nopOperation,
                  OpCode.ORA => oraOperation,
                  OpCode.PHA => phaOperation,
                  OpCode.PHP => phpOperation,
                  OpCode.PLA => plaOperation,
                  OpCode.PLP => plpOperation,
                  OpCode.ROL => rolOperation,
                  OpCode.ROR => rorOperation,
                  OpCode.RTI => rtiOperation,
                  OpCode.RTS => rtsOperation,
                  OpCode.SBC => sbcOperation,
                  OpCode.SEC => secOperation,
                  OpCode.SED => sedOperation,
                  OpCode.SEI => seiOperation,
                  OpCode.STA => staOperation,
                  OpCode.STX => stxOperation,
                  OpCode.STY => styOperation,
                  OpCode.TAX => taxOperation,
                  OpCode.TAY => tayOperation,
                  OpCode.TSX => tsxOperation,
                  OpCode.TXA => txaOperation,
                  OpCode.TXS => txsOperation,
                  OpCode.TYA => tyaOperation,
                  
                  OpCode.LAX => laxOperation,

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
