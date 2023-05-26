using System;
using System.Linq;

namespace QodenTestTasks.Task3
{
    internal static class String
    {
        public static bool IsOperator(this string item)
        {
            return (new string[] { "+", "-", "*", "/" }).Contains(item);
        }
    }

    internal class Task3
    {
        static int Calculate(int number1, int number2, string operation)
        {
            switch (operation)
            {
                case "+":
                {
                    return number1 + number2;
                }
                case "-":
                {
                    return number1 - number2;
                }
                case "*":
                {
                    return number1 * number2;
                }
                case "/":
                {
                    return number1 / number2;
                }
            }

            return 0;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine()?.Trim();
            var data = input.Split(" ").ToList();

            while (data.Count > 1)
            {
                var operatorPosition = data.FindIndex(item => item.IsOperator());
                data[operatorPosition - 2] = Calculate(
                    int.Parse(data[operatorPosition - 2]),
                    int.Parse(data[operatorPosition - 1]),
                    data[operatorPosition]
                ).ToString();
                data.RemoveAt(operatorPosition - 1);
                data.RemoveAt(operatorPosition - 1);
            }

            Console.WriteLine(data[0]);
        }
    }
}