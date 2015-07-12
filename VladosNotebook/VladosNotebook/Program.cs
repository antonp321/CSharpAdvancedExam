using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace VladosNotebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var mainDictionary = new Dictionary<string, SortedDictionary<string,  List<string>>>();
            var ranksDictionary = new Dictionary<string, SortedDictionary<string, List<string>>>();

            while (input != "END")
            {
                string[] inputArr = input.Split('|');
                if (!mainDictionary.ContainsKey(inputArr[0]) && !ranksDictionary.ContainsKey(inputArr[0]))
                {
                    ranksDictionary.Add(inputArr[0], new SortedDictionary<string, List<string>>());
                    mainDictionary.Add(inputArr[0], new SortedDictionary<string, List<string>>());
                }
                if ((inputArr[1] == "win" || inputArr[1] == "loss" || inputArr[1] == "name" || inputArr[1] == "age") && !ranksDictionary[inputArr[0]].ContainsKey(inputArr[1]))
                {
                    ranksDictionary[inputArr[0]].Add(inputArr[1], new List<string>());
                }
                if ((inputArr[1] == "win" || inputArr[1] == "loss"))
                {
                    ranksDictionary[inputArr[0]][inputArr[1]].Add(inputArr[2]);
                }
                if (inputArr[1] == "name")
                {
                    ranksDictionary[inputArr[0]][inputArr[1]].Add(inputArr[2]);
                }
                if (inputArr[1] == "age")
                {
                    ranksDictionary[inputArr[0]][inputArr[1]].Add(inputArr[2]);
                }

                if (!mainDictionary[inputArr[0]].ContainsKey("opponents"))
                {
                    mainDictionary[inputArr[0]].Add("opponents", new List<string>());
                }
                if(inputArr[1] != "win" && inputArr[1] != "loss" && !mainDictionary[inputArr[0]].ContainsKey(inputArr[1]))
                {
                    mainDictionary[inputArr[0]].Add(inputArr[1], new List<string>());
                }
                if ((inputArr[1] != "win" && inputArr[1] != "loss") && !mainDictionary[inputArr[0]][inputArr[1]].Contains(inputArr[2]))
                {
                    mainDictionary[inputArr[0]][inputArr[1]].Add(inputArr[2]);
                }
                else if (inputArr[1] == "win" || inputArr[1] == "loss")
                {
                    mainDictionary[inputArr[0]]["opponents"].Add(inputArr[2]);
                }
                
                input = Console.ReadLine();
            }

            var validMainDictionary = mainDictionary.Where((x => x.Value.Keys.Contains("name") && x.Value.Keys.Contains("age")));
            var orderedMainDictionary = validMainDictionary.OrderBy(x => x.Key);
            bool isItEmpty = true;
            foreach (var item in orderedMainDictionary)
            {
                isItEmpty = false;
            }
            if (isItEmpty)
            {
                Console.WriteLine("No data recovered.");
            }
            else
            {

            List<double> ranks = new List<double>();
            double wins = 0;
            double losses = 0;
            var validRanksDictionary = ranksDictionary.Where((x => x.Value.Keys.Contains("name") && x.Value.Keys.Contains("age")));
            var orderedRanksDictionary = validRanksDictionary.OrderBy(x => x.Key);
            foreach (var item in orderedRanksDictionary)
            {
                foreach (var item1 in item.Value)
                {
                    if(item1.Key.ToString() == "win")
                    {
                        wins = item1.Value.Count;
                    }
                    else if(item1.Key.ToString() == "loss")
                    {
                        losses = item1.Value.Count;
                    }
                }

                ranks.Add((wins + 1) / (losses + 1));
                wins = 0;
                losses = 0;
            }
            StringBuilder result = new StringBuilder();
            int count = 0;

            foreach (var item in orderedMainDictionary)
            {
                foreach (var item1 in item.Value)
                {
                    if (item1.Value.Count == 0)
                    {
                        item1.Value.Add("(empty)");
                    }
                }
            }

            foreach (var item in orderedMainDictionary) 
            {
                result.AppendFormat("Color: {0}", item.Key).AppendLine();
                foreach (var item1 in item.Value)
                {
                    result.AppendFormat("-{0}: ", item1.Key);
                    item1.Value.Sort(StringComparer.Ordinal);
                    if (item1.Key.ToString() == "opponents")
                    {
                        int check = 1;
                        foreach (var item2 in item1.Value)
                        {
                            if (item1.Value.Count == check)
                            {
                                result.AppendFormat("{0}", item2);
                            }
                            else
                            {
                                result.AppendFormat("{0}, ", item2);
                            }
                            check++;
                        }
                    }
                    else
                    {
                        foreach (var item2 in item1.Value)
                        {
                            result.AppendFormat(item2);
                        }
                    }
                    result.AppendLine();
                }
                result.AppendFormat("-rank: {0:F2}", ranks[count]).AppendLine();
                count++;
            }
            Console.Write(result.ToString());
             }
        }
    }
}
