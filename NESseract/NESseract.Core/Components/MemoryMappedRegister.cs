using NESseract.Core.Components;

namespace NESseract.Core.Bus
{
   public class MemoryMappedRegister
   {
      private readonly MemoryChip memory;

      private byte value;

      public byte Value
      {
         get
         {
            return value;
         }

         set
         {
            this.value = value;

            memory[Address] = value;
         }
      }

      public ushort Address { get; private set; }

      public MemoryMappedRegister(MemoryChip memory, ushort address)
      {
         this.memory = memory;

         Address = address;

         this.memory.RegisterMap(address, (byte value) => this.value = value);
      }
   }
}
