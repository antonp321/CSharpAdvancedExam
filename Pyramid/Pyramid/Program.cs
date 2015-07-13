using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int pyramidRows = int.Parse(Console.ReadLine());
            int[][] numbersArr = new int[pyramidRows][];
            List<int> highestRowNumbers = new List<int>();

            for (int row = 0; row < pyramidRows; row++)
            {
                string input = Console.ReadLine();
                string[] stringNumbersArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] integers = new int[stringNumbersArr.Length];
                for (int col = 0; col < integers.Length; col++)
                {
                    integers[col] = int.Parse(stringNumbersArr[col]);
                }
                numbersArr[row] = integers;
            }

            int max = numbersArr[0][0];
            highestRowNumbers.Add(max);
            int maxChecking = 0;

            for (int row = 1; row < numbersArr.Length; row++)
            {
                for (int col = 0; col < numbersArr[row].Length; col++)
                {
                    maxChecking = max;
                    if (numbersArr[row][col] > maxChecking)
                    {
                        max = numbersArr[row][col];
                        highestRowNumbers.Add(max);
                        for (int i = 0; i < numbersArr[row].Length; i++)
                        {
                            if (numbersArr[row][i] < max && numbersArr[row][i] > highestRowNumbers[highestRowNumbers.Count - 2])
                            {
                                highestRowNumbers.Remove(max);
                                max = numbersArr[row][i];
                                highestRowNumbers.Add(max);
                            }
                        }
                        break;
                    }
                    else
                    {
                        maxChecking++;
                    }
                }
                        
            }
        
            int count = 0;

            foreach (var item in highestRowNumbers)
            {
                count++;
                if (count == highestRowNumbers.Count)
                {
                    Console.Write("{0}", item);
                }
                else
                {
                    Console.Write("{0}, ", item);
                }
            }
            Console.WriteLine();
        }
    }
}   
