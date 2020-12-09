namespace NESseract.Core.Cpu
{
   public class CPUTickState
   {
      public ushort PC { get; set; }
      public byte OpCode { get; set; }
      public byte Operand1 { get; set; }
      public byte Operand2 { get; set; }
      public string NemonicSyntax { get; set; }
      public byte A { get; set; }
      public byte X { get; set; }
      public byte Y { get; set; }
      public byte P { get; set; }
      public byte SP { get; set; }
      public ushort CYC { get; set; }
   }
}
