using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouplesFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(' ');
            int[] inputNumbers = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
            {
                inputNumbers[i] = int.Parse(inputArr[i]);
            }

            List<string> mainCollection = new List<string>();

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                mainCollection.Add(inputNumbers[i].ToString() + " " + inputNumbers[i + 1].ToString());
            }

            var query = mainCollection.GroupBy(x => x)
              .Where(g => g.Count() > 0)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

            double couples = 0.0;
            foreach (var item in query)
            {
                couples += item.Counter;
            }

            foreach (var item in query)
            {
                double percent = (item.Counter * 100.00) / couples;
                Console.WriteLine("{0} -> {1:F2}%", item.Element, percent);
            }
        }
    }
}
