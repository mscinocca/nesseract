using NESseract.Core.Cpu.Definitions;

namespace NESseract.Core.Cpu;

public struct CPUTickState
{
   public ushort PC { get; init; }
   public byte OpCode { get; init; }
   public byte Operand1 { get; init; }
   public byte Operand2 { get; init; }
   public byte InstructionBytes { get; init; }
   public OpCode Mnemonic { get; init; }
   public string AddressSyntax { get; init; }
   public string OperationSyntax { get; init; }
   public bool IllegalOpCode { get; init; }
   public byte A { get; init; }
   public byte X { get; init; }
   public byte Y { get; init; }
   public byte P { get; init; }
   public byte SP { get; init; }
   public ushort CYC { get; init; }

   private readonly string _mnemonicSyntax;

   public string MnemonicSyntax
   {
      get => string.IsNullOrEmpty(_mnemonicSyntax) ? $"{(IllegalOpCode ? "*" : "")}{Mnemonic} {AddressSyntax + " " + OperationSyntax}".Trim() : _mnemonicSyntax;
      init => _mnemonicSyntax = value;
   }

   public string Log
   {
      get => $"{PC:X04}  {OpCode:X02} {(InstructionBytes >= 2 ? Operand1 : @"  "):X02} {(InstructionBytes == 3 ? Operand2 : @"  "):X02}  {MnemonicSyntax,-27} A:{A:X02} X:{X:X02} Y:{Y:X02} P:{P:X02} SP:{SP:X02} PPU:{"0",3},{"0",3} CYC:{CYC}";
   }
}