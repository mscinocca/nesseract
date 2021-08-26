using System;
using System.Collections.Generic;

namespace NESseract.Core.Components
{
   public abstract class MemoryChip
   {
      protected readonly byte[] memory;

      protected readonly Memory<byte> memorySpan;

      protected Dictionary<ushort, List<Action<byte>>> memoryActionMap;

      protected MemoryChip(int size)
      {
         memory = new byte[size];

         memorySpan = new Memory<byte>(memory);

         memoryActionMap = new Dictionary<ushort, List<Action<byte>>>();
      }

      public byte this[ushort address]
      {
         get
         {
            address = DecodeAddress(address);

            return memory[address];
         }

         set
         {
            address = DecodeAddress(address);

            memory[address] = value;

            if(memoryActionMap.ContainsKey(address))
            {
               for(var i = 0; i < memoryActionMap[address].Count; i++)
               {
                  memoryActionMap[address][i](value);
               }
            }
         }
      }

      public byte this[int address]
      {
         get
         {
            return this[(ushort)address];
         }

         set
         {
            this[(ushort)address] = value;
         }
      }

      public abstract ushort DecodeAddress(ushort address);

      public void SetBlock(byte[] blockData, int sourceIndex, int destinationIndex, int length)
      {
         Array.Copy(blockData, sourceIndex, memory, destinationIndex, length);
      }

      public void SetBlock(Memory<byte> blockData, int sourceIndex, int destinationIndex, int length)
      {
         Array.Copy(blockData.ToArray(), sourceIndex, memory, destinationIndex, length);
      }

      public void RegisterMap(ushort address, Action<byte> mapAction)
      {
         address = DecodeAddress(address);

         if(!memoryActionMap.ContainsKey(address))
         {
            memoryActionMap.Add(address, new List<Action<byte>>());
         }

         memoryActionMap[address].Add(mapAction);
      }
   }
}
