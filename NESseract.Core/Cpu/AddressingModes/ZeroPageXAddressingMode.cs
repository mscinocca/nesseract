﻿namespace NESseract.Core.Cpu.AddressingModes;

public class ZeroPageXAddressingMode : IAddressingMode
{
   public ushort GetAddress(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
   {
      pageBoundaryCrossed = false;

      return (byte)(operand1 + registers.X);
   }

   public byte GetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, out bool pageBoundaryCrossed)
   {
      var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

      return memory[address];
   }

   public byte GetValue(CPUMemory memory, CPURegisters registers, ushort address)
   {
      return memory[address];
   }

   public void SetValue(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2, byte value, out bool pageBoundaryCrossed)
   {
      var address = GetAddress(memory, registers, operand1, operand2, out pageBoundaryCrossed);

      memory[address] = value;
   }

   public void SetValue(CPUMemory memory, CPURegisters registers, ushort address, byte value)
   {
      memory[address] = value;
   }

   public string GetSyntax(CPUMemory memory, CPURegisters registers, byte operand1, byte operand2)
   {
      return $"${operand1:X02},X @ {(byte)(operand1 + registers.X):X02}";
   }
}