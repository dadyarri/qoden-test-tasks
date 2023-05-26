using System;
using System.Collections.Generic;
using System.Linq;

namespace QodenTestTasks.Task2
{
    public static class Task2
    {
        private class WordInfo
        {
            public string Word { get; set; }
            public int Count { get; set; }
            public string Dots { get; set; }
        }

        public static void Main(string[] args)
        {
            var words = Console.ReadLine()?.Split(" ");
            var stats = words.GroupBy(word => word).Select(g =>
                    new WordInfo
                    {
                        Word = g.Key,
                        Count = g.Select(w => w).Count()
                    })
                .OrderBy(g => g.Count)
                .ToList();

            var longestWordLength = GetLengthOfLongestWord(stats);
            var topWordFrequency = GetTopWordFrequency(stats);
            MarkMostCommonWords(stats);

            foreach (var wordInfo in stats)
            {
                if (wordInfo.Count != topWordFrequency)
                {
                    var rounded = Math.Round(
                        (float)wordInfo.Count * 10 / topWordFrequency,
                        MidpointRounding.ToEven
                    );
                    wordInfo.Dots = new string('.', (int)rounded);
                }
                
                Console.WriteLine(
                    $"{wordInfo.Word.PadLeft(longestWordLength, '_')} {wordInfo.Dots}");
                
            }
        }

        private static int GetLengthOfLongestWord(IEnumerable<WordInfo> words)
        {
            return words.Max(word => word.Word.Length);
        }

        private static void MarkMostCommonWords(IEnumerable<WordInfo> words)
        {
            var wordFrequency = GetTopWordFrequency(words);
            words
                .Where(word => word.Count == wordFrequency)
                .ToList()
                .ForEach(word => word.Dots = new string('.', 10));
        }

        private static int GetTopWordFrequency(IEnumerable<WordInfo> words)
        {
            return words.Max(word => word.Count);
        }
    }
}