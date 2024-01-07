using NESseract.Core.Cpu.AddressingModes;
using NESseract.Core.Cpu.Definitions;
using NESseract.Core.Cpu.Operations;
using System;

namespace NESseract.Core.Cpu;

public partial class CPU
{
   private readonly ADCOperation _adcOperation = new();
   private readonly ANDOperation _andOperation = new();
   private readonly ASLOperation _aslOperation = new();
   private readonly BCCOperation _bccOperation = new();
   private readonly BCSOperation _bcsOperation = new();
   private readonly BEQOperation _beqOperation = new();
   private readonly BITOperation _bitOperation = new();
   private readonly BMIOperation _bmiOperation = new();
   private readonly BNEOperation _bneOperation = new();
   private readonly BPLOperation _bplOperation = new();
   private readonly BVCOperation _bvcOperation = new();
   private readonly BVSOperation _bvsOperation = new();
   private readonly CLCOperation _clcOperation = new();
   private readonly CLDOperation _cldOperation = new();
   private readonly CLIOperation _cliOperation = new();
   private readonly CLVOperation _clvOperation = new();
   private readonly CMPOperation _cmpOperation = new();
   private readonly CPXOperation _cpxOperation = new();
   private readonly CPYOperation _cpyOperation = new();
   private readonly DECOperation _decOperation = new();
   private readonly DEXOperation _dexOperation = new();
   private readonly DEYOperation _deyOperation = new();
   private readonly EOROperation _eorOperation = new();
   private readonly INCOperation _incOperation = new();
   private readonly INXOperation _inxOperation = new();
   private readonly INYOperation _inyOperation = new();
   private readonly JMPOperation _jmpOperation = new();
   private readonly JSROperation _jsrOperation = new();
   private readonly LAXOperation _laxOperation = new();
   private readonly LDAOperation _ldaOperation = new();
   private readonly LDXOperation _ldxOperation = new();
   private readonly LDYOperation _ldyOperation = new();
   private readonly LSROperation _lsrOperation = new();
   private readonly NOPOperation _nopOperation = new();
   private readonly ORAOperation _oraOperation = new();
   private readonly PHAOperation _phaOperation = new();
   private readonly PHPOperation _phpOperation = new();
   private readonly PLAOperation _plaOperation = new();
   private readonly PLPOperation _plpOperation = new();
   private readonly ROLOperation _rolOperation = new();
   private readonly ROROperation _rorOperation = new();
   private readonly RTIOperation _rtiOperation = new();
   private readonly TXSOperation _txsOperation = new();
   private readonly RTSOperation _rtsOperation = new();
   private readonly SBCOperation _sbcOperation = new();
   private readonly SECOperation _secOperation = new();
   private readonly SEDOperation _sedOperation = new();
   private readonly SEIOperation _seiOperation = new();
   private readonly STAOperation _staOperation = new();
   private readonly STXOperation _stxOperation = new();
   private readonly STYOperation _styOperation = new();
   private readonly TAXOperation _taxOperation = new();
   private readonly TAYOperation _tayOperation = new();
   private readonly TSXOperation _tsxOperation = new();
   private readonly TXAOperation _txaOperation = new();
   private readonly TYAOperation _tyaOperation = new();

   private readonly NoneAddressingMode _noneAddressingMode = new();
   private readonly AbsoluteAddressingMode _absoluteAddressingMode = new();
   private readonly AbsoluteXAddressingMode _absoluteXAddressingMode = new();
   private readonly AbsoluteYAddressingMode _absoluteYAddressingMode = new();
   private readonly AccumulatorAddressingMode _accumulatorAddressingMode = new();
   private readonly ImmediateAddressingMode _immediateAddressingMode = new();
   private readonly ImpliedAddressingMode _impliedAddressingMode = new();
   private readonly IndirectAddressingMode _indirectAddressingMode = new();
   private readonly IndirectXAddressingMode _indirectXAddressingMode = new();
   private readonly IndirectYAddressingMode _indirectYAddressingMode = new();
   private readonly RelativeAddressingMode _relativeAddressingMode = new();
   private readonly ZeroPageAddressingMode _zeroPageAddressingMode = new();
   private readonly ZeroPageXAddressingMode _zeroPageXAddressingMode = new();
   private readonly ZeroPageYAddressingMode _zeroPageYAddressingMode = new();

   private void InitializeOpCodeHandlers()
   {
      OpCodeDefinitions.OpCodeList.ForEach(x =>
      {
         _opCodeHandlers.Add(x.OpCode, new OpCodeHandler(
            x,
            x.Mnemonic switch
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
            x.AddressingMode switch
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
            }));
      });
   }
}