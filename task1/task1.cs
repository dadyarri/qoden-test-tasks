using System;
using System.Linq;

namespace QodenTestTasks.Task1
{
    public static class Task1
    {
        public static void Main(string[] args)
        {
            var divider = Convert.ToInt32(Console.ReadLine());
            var hashTable = new HashTable(divider);

            var items = Console.ReadLine()?
                .Split(" ")
                .Select(item => Convert.ToInt32(item))
                .ToArray();

            for (int i = 0; i < items?.Length; i++)
            {
                hashTable.Insert(items[i]);
            }

            hashTable.Print();
        }
    }
}