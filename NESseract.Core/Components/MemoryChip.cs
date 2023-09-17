using System;
using System.Collections.Generic;

namespace NESseract.Core.Components;

public abstract class MemoryChip
{
   private readonly byte[] _memory;

   protected readonly Memory<byte> MemorySpan;

   private readonly Dictionary<ushort, List<Action<byte>>> _memoryActionMap;

   protected MemoryChip(int size)
   {
      _memory = new byte[size];

      MemorySpan = new Memory<byte>(_memory);

      _memoryActionMap = new Dictionary<ushort, List<Action<byte>>>();
   }

   public byte this[ushort address]
   {
      get
      {
         address = DecodeAddress(address);

         return _memory[address];
      }

      set
      {
         address = DecodeAddress(address);

         _memory[address] = value;

         if (!_memoryActionMap.ContainsKey(address))
         {
            return;
         }

         for(var i = 0; i < _memoryActionMap[address].Count; i++)
         {
            _memoryActionMap[address][i](value);
         }
      }
   }

   public byte this[int address]
   {
      get => this[(ushort)address];

      set => this[(ushort)address] = value;
   }

   protected abstract ushort DecodeAddress(ushort address);

   public void SetBlock(byte[] blockData, int sourceIndex, int destinationIndex, int length)
   {
      Array.Copy(blockData, sourceIndex, _memory, destinationIndex, length);
   }

   public void SetBlock(Memory<byte> blockData, int sourceIndex, int destinationIndex, int length)
   {
      Array.Copy(blockData.ToArray(), sourceIndex, _memory, destinationIndex, length);
   }

   public void RegisterMap(ushort address, Action<byte> mapAction)
   {
      address = DecodeAddress(address);

      if(!_memoryActionMap.ContainsKey(address))
      {
         _memoryActionMap.Add(address, new List<Action<byte>>());
      }

      _memoryActionMap[address].Add(mapAction);
   }
}