namespace NESseract.Core.Components;

public class MemoryMappedRegister
{
   private readonly MemoryChip _memory;

   public byte Value
   {
      set => _memory[Address] = value;
   }

   private ushort Address { get; }

   public MemoryMappedRegister(MemoryChip memory, ushort address)
   {
      _memory = memory;

      Address = address;

      _memory.RegisterMap(address, value => { Value = value; });
   }
}