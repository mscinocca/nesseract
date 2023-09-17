using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;
using System;

namespace NESseract.Core.Cpu;

public partial class CPU
{
   private IOperation _adcOperation;
   private IOperation _andOperation;
   private IOperation _aslOperation;
   private IOperation _bccOperation;
   private IOperation _bcsOperation;
   private IOperation _beqOperation;
   private IOperation _bitOperation;
   private IOperation _bmiOperation;
   private IOperation _bneOperation;
   private IOperation _bplOperation;
   private IOperation _bvcOperation;
   private IOperation _bvsOperation;
   private IOperation _clcOperation;
   private IOperation _cldOperation;
   private IOperation _cliOperation;
   private IOperation _clvOperation;
   private IOperation _cmpOperation;
   private IOperation _cpxOperation;
   private IOperation _cpyOperation;
   private IOperation _decOperation;
   private IOperation _dexOperation;
   private IOperation _deyOperation;
   private IOperation _eorOperation;
   private IOperation _incOperation;
   private IOperation _inxOperation;
   private IOperation _inyOperation;
   private IOperation _jmpOperation;
   private IOperation _jsrOperation;
   private IOperation _laxOperation;
   private IOperation _ldaOperation;
   private IOperation _ldxOperation;
   private IOperation _ldyOperation;
   private IOperation _lsrOperation;
   private IOperation _nopOperation;
   private IOperation _oraOperation;
   private IOperation _phaOperation;
   private IOperation _phpOperation;
   private IOperation _plaOperation;
   private IOperation _plpOperation;
   private IOperation _rolOperation;
   private IOperation _rorOperation;
   private IOperation _rtiOperation;
   private IOperation _rtsOperation;
   private IOperation _sbcOperation;
   private IOperation _secOperation;
   private IOperation _sedOperation;
   private IOperation _seiOperation;
   private IOperation _staOperation;
   private IOperation _stxOperation;
   private IOperation _styOperation;
   private IOperation _taxOperation;
   private IOperation _tayOperation;
   private IOperation _tsxOperation;
   private IOperation _txaOperation;
   private IOperation _txsOperation;
   private IOperation _tyaOperation;

   private IAddressingMode _noneAddressingMode;
   private IAddressingMode _absoluteAddressingMode;
   private IAddressingMode _absoluteXAddressingMode;
   private IAddressingMode _absoluteYAddressingMode;
   private IAddressingMode _accumulatorAddressingMode;
   private IAddressingMode _immediateAddressingMode;
   private IAddressingMode _impliedAddressingMode;
   private IAddressingMode _indirectAddressingMode;
   private IAddressingMode _indirectXAddressingMode;
   private IAddressingMode _indirectYAddressingMode;
   private IAddressingMode _relativeAddressingMode;
   private IAddressingMode _zeroPageAddressingMode;
   private IAddressingMode _zeroPageXAddressingMode;
   private IAddressingMode _zeroPageYAddressingMode;

   private void InitializeOpCodeHandlers()
   {
      _adcOperation = new ADCOperation();
      _andOperation = new ANDOperation();
      _aslOperation = new ASLOperation();
      _bccOperation = new BCCOperation();
      _bcsOperation = new BCSOperation();
      _beqOperation = new BEQOperation();
      _bitOperation = new BITOperation();
      _bmiOperation = new BMIOperation();
      _bneOperation = new BNEOperation();
      _bplOperation = new BPLOperation();
      _bvcOperation = new BVCOperation();
      _bvsOperation = new BVSOperation();
      _clcOperation = new CLCOperation();
      _cldOperation = new CLDOperation();
      _cliOperation = new CLIOperation();
      _clvOperation = new CLVOperation();
      _cmpOperation = new CMPOperation();
      _cpxOperation = new CPXOperation();
      _cpyOperation = new CPYOperation();
      _decOperation = new DECOperation();
      _dexOperation = new DEXOperation();
      _deyOperation = new DEYOperation();
      _eorOperation = new EOROperation();
      _incOperation = new INCOperation();
      _inxOperation = new INXOperation();
      _inyOperation = new INYOperation();
      _jmpOperation = new JMPOperation();
      _jsrOperation = new JSROperation();
      _laxOperation = new LAXOperation();
      _ldaOperation = new LDAOperation();
      _ldxOperation = new LDXOperation();
      _ldyOperation = new LDYOperation();
      _lsrOperation = new LSROperation();
      _nopOperation = new NOPOperation();
      _oraOperation = new ORAOperation();
      _phaOperation = new PHAOperation();
      _phpOperation = new PHPOperation();
      _plaOperation = new PLAOperation();
      _plpOperation = new PLPOperation();
      _rolOperation = new ROLOperation();
      _rorOperation = new ROROperation();
      _rtiOperation = new RTIOperation();
      _rtsOperation = new RTSOperation();
      _sbcOperation = new SBCOperation();
      _secOperation = new SECOperation();
      _sedOperation = new SEDOperation();
      _seiOperation = new SEIOperation();
      _staOperation = new STAOperation();
      _stxOperation = new STXOperation();
      _styOperation = new STYOperation();
      _taxOperation = new TAXOperation();
      _tayOperation = new TAYOperation();
      _tsxOperation = new TSXOperation();
      _txaOperation = new TXAOperation();
      _txsOperation = new TXSOperation();
      _tyaOperation = new TYAOperation();

      _noneAddressingMode = new NoneAddressingMode();
      _absoluteAddressingMode = new AbsoluteAddressingMode();
      _absoluteXAddressingMode = new AbsoluteXAddressingMode();
      _absoluteYAddressingMode = new AbsoluteYAddressingMode();
      _accumulatorAddressingMode = new AccumulatorAddressingMode();
      _immediateAddressingMode = new ImmediateAddressingMode();
      _impliedAddressingMode = new ImpliedAddressingMode();
      _indirectAddressingMode = new IndirectAddressingMode();
      _indirectXAddressingMode = new IndirectXAddressingMode();
      _indirectYAddressingMode = new IndirectYAddressingMode();
      _relativeAddressingMode = new RelativeAddressingMode();
      _zeroPageAddressingMode = new ZeroPageAddressingMode();
      _zeroPageXAddressingMode = new ZeroPageXAddressingMode();
      _zeroPageYAddressingMode = new ZeroPageYAddressingMode();

      OpCodeDefinitions.OpCodeList.ForEach(x =>
      {
         _opCodeHandlers.Add(x.OpCode, new OpCodeHandler
         {
            OpCodeDefinition = x,
            Operation = x.Mnemonic switch
            {
               OpCode.ADC => _adcOperation,
               OpCode.AND => _andOperation,
               OpCode.ASL => _aslOperation,
               OpCode.BCC => _bccOperation,
               OpCode.BCS => _bcsOperation,
               OpCode.BEQ => _beqOperation,
               OpCode.BIT => _bitOperation,
               OpCode.BMI => _bmiOperation,
               OpCode.BNE => _bneOperation,
               OpCode.BPL => _bplOperation,
               //OpCode.BRK => throw new NotImplementedException(),
               OpCode.BVC => _bvcOperation,
               OpCode.BVS => _bvsOperation,
               OpCode.CLC => _clcOperation,
               OpCode.CLD => _cldOperation,
               OpCode.CLI => _cliOperation,
               OpCode.CLV => _clvOperation,
               OpCode.CMP => _cmpOperation,
               OpCode.CPX => _cpxOperation,
               OpCode.CPY => _cpyOperation,
               OpCode.DEC => _decOperation,
               OpCode.DEX => _dexOperation,
               OpCode.DEY => _deyOperation,
               OpCode.EOR => _eorOperation,
               OpCode.INC => _incOperation,
               OpCode.INX => _inxOperation,
               OpCode.INY => _inyOperation,
               OpCode.JMP => _jmpOperation,
               OpCode.JSR => _jsrOperation,
               OpCode.LDA => _ldaOperation,
               OpCode.LDX => _ldxOperation,
               OpCode.LDY => _ldyOperation,
               OpCode.LSR => _lsrOperation,
               OpCode.NOP => _nopOperation,
               OpCode.ORA => _oraOperation,
               OpCode.PHA => _phaOperation,
               OpCode.PHP => _phpOperation,
               OpCode.PLA => _plaOperation,
               OpCode.PLP => _plpOperation,
               OpCode.ROL => _rolOperation,
               OpCode.ROR => _rorOperation,
               OpCode.RTI => _rtiOperation,
               OpCode.RTS => _rtsOperation,
               OpCode.SBC => _sbcOperation,
               OpCode.SEC => _secOperation,
               OpCode.SED => _sedOperation,
               OpCode.SEI => _seiOperation,
               OpCode.STA => _staOperation,
               OpCode.STX => _stxOperation,
               OpCode.STY => _styOperation,
               OpCode.TAX => _taxOperation,
               OpCode.TAY => _tayOperation,
               OpCode.TSX => _tsxOperation,
               OpCode.TXA => _txaOperation,
               OpCode.TXS => _txsOperation,
               OpCode.TYA => _tyaOperation,
                  
               OpCode.LAX => _laxOperation,

               _ => _nopOperation,
            },
            AddressingMode = x.AddressingMode switch
            {
               AddressingMode.NON => _noneAddressingMode,
               AddressingMode.ZP0 => _zeroPageAddressingMode,
               AddressingMode.ZPX => _zeroPageXAddressingMode,
               AddressingMode.ZPY => _zeroPageYAddressingMode,
               AddressingMode.ABS => _absoluteAddressingMode,
               AddressingMode.ABX => _absoluteXAddressingMode,
               AddressingMode.ABY => _absoluteYAddressingMode,
               AddressingMode.IND => _indirectAddressingMode,
               AddressingMode.IDX => _indirectXAddressingMode,
               AddressingMode.IDY => _indirectYAddressingMode,
               AddressingMode.IMP => _impliedAddressingMode,
               AddressingMode.ACC => _accumulatorAddressingMode,
               AddressingMode.IMM => _immediateAddressingMode,
               AddressingMode.REL => _relativeAddressingMode,
               _ => throw new NotImplementedException(),
            }
         });
      });
   }
}