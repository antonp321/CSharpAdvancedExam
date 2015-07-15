using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, SortedDictionary<string, List<int>>>();

            for (int i = 0; i < inputLines; i++)
            {
                string input = Console.ReadLine();
                string[] splitTheInput = input.Split(' ');
                string name = splitTheInput[0] + " " + splitTheInput[1];
                string discipline = splitTheInput[2];
                int theGrade = int.Parse(splitTheInput[3]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new SortedDictionary<string, List<int>>());
                }
                if (!grades[name].ContainsKey(discipline))
                {
                    grades[name].Add(discipline, new List<int>());
                }
                grades[name][discipline].Add(theGrade);
            }

            int count = 1;

            var orderedGrades = grades.OrderBy(x => x.Key);
            //var orderedGradesByDiscipline = orderedGrades.OrderBy(x => x.Value.Keys);

            foreach (var item in orderedGrades)
            {
                Console.Write("{0}: [", item.Key);
                count = 1;
                foreach (var item1 in item.Value)
                {
                    if (count == item.Value.Count)
                    {
                        Console.Write("{0} - {1:F2}]", item1.Key, item1.Value.Average());
                    }
                    else
                    {
                        Console.Write("{0} - {1:F2}, ", item1.Key, item1.Value.Average());
                    }
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}
