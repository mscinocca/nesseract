using NESseract.Core.Cpu;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NESseract.Core.Test.Cpu;

public class ROMLog
{
   public readonly List<CPUTickState> ROMLogLines = new();

   public void Parse(string log)
   {
      var logLines = log.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

      foreach(var logLine in logLines)
      {
         var romLogLine = new CPUTickState
         {
            PC = ushort.Parse(logLine.Substring(0, 6).Trim(), NumberStyles.HexNumber),
            OpCode = byte.Parse(logLine.Substring(6, 3).Trim(), NumberStyles.HexNumber),
            Operand1 = byte.Parse(string.IsNullOrEmpty(logLine.Substring(9, 3).Trim()) ? "0" : logLine.Substring(9, 3).Trim(), NumberStyles.HexNumber),
            Operand2 = byte.Parse(string.IsNullOrEmpty(logLine.Substring(12, 3).Trim()) ? "0" : logLine.Substring(12, 3).Trim(), NumberStyles.HexNumber),
            MnemonicSyntax = logLine.Substring(15, 33).Trim(),
            A = byte.Parse(logLine.Substring(50, 3).Trim(), NumberStyles.HexNumber),
            X = byte.Parse(logLine.Substring(55, 3).Trim(), NumberStyles.HexNumber),
            Y = byte.Parse(logLine.Substring(60, 3).Trim(), NumberStyles.HexNumber),
            P = byte.Parse(logLine.Substring(65, 3).Trim(), NumberStyles.HexNumber),
            SP = byte.Parse(logLine.Substring(71, 3).Trim(), NumberStyles.HexNumber),
            CYC = ushort.Parse(logLine[90..].Trim())
         };

         ROMLogLines.Add(romLogLine);
      }
   }
}