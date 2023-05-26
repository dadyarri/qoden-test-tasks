using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace QodenTestTasks.Task1
{
    public class HashTable
    {
        private readonly int _divider;
        public LinkedArray[] values;

        public HashTable(int divider)
        {
            _divider = divider;
            values = Array.Empty<LinkedArray>();
        }

        public void Insert(int newValue)
        {
            var hash = GetHashOf(newValue);
            GetOrCreateArray(hash).Insert(newValue);
        }

        private int GetHashOf(int value)
        {
            return value % _divider;
        }
        
        private LinkedArray TryGetArray(int key)
        {
            var result = values.Where(array => array.Key == key).ToArray();
            return result.Length != 0 ? result[0] : null;
        }

        private LinkedArray GetOrCreateArray(int key)
        {
            var result = TryGetArray(key);

            if (result != null) return result;

            Array.Resize(ref values, values.Length + 1);
            var newLinkedArray = new LinkedArray(key);
            values[values.Length - 1] = newLinkedArray;
            return newLinkedArray;
        }

        private int GetMaxKey()
        {
            return values.Max(array => array.Key);
        }

        public void Print()
        {
            for (var i = 0; i < GetMaxKey() + 1; i++)
            {
                var currentLine = TryGetArray(i);
                if (currentLine == null)
                {
                    Console.WriteLine($"{i}:");
                    continue;
                }

                Console.WriteLine(currentLine);
            }
        }
    }
}