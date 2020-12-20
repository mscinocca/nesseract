namespace NESseract.Core.Cpu
{
   public struct CPUTickState
   {
      public ushort PC { get; set; }
      public byte OpCode { get; set; }
      public byte Operand1 { get; set; }
      public byte Operand2 { get; set; }
      public byte InstructionBytes { get; set; }
      public OpCode Nemonic { get; set; }
      public string AddressSyntax { get; set; }
      public string OperationSyntax { get; set; }
      public byte A { get; set; }
      public byte X { get; set; }
      public byte Y { get; set; }
      public byte P { get; set; }
      public byte SP { get; set; }
      public ushort CYC { get; set; }

      private string nemonixSyntax;

      public string NemonicSyntax
      {
         get { return string.IsNullOrEmpty(nemonixSyntax) ? $"{Nemonic} {AddressSyntax + " " + OperationSyntax}".Trim() : nemonixSyntax; }
         set { nemonixSyntax = value; }
      }

      public string Log
      {
         get
         {
            return $"{PC:X04}  {OpCode:X02} {(InstructionBytes >= 2 ? Operand1 : @"  "):X02} {(InstructionBytes == 3 ? Operand2 : @"  "):X02}  {NemonicSyntax,-27} A:{A:X02} X:{X:X02} Y:{Y:X02} P:{P:X02} SP:{SP:X02} PPU:{"0",3},{"0",3} CYC:{CYC}";
         }
      }
   }
}
