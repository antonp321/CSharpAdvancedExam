using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlympicsAreComing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> name = new List<string>();
            List<string> country = new List<string>();

            var atlets = new Dictionary<string, List<string>>();

            while (input != "report")
            {
                string[] inputArr = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);               
                name.Add(inputArr[0]);
                country.Add(inputArr[1]);
                input = Console.ReadLine();
            }

            for (int i = 0; i < name.Count; i++)
            {
                name[i] = name[i].Trim();
                name[i] = name[i].Replace(@"\s", "");
                name[i] = name[i].Replace("\t", "");
                name[i] = name[i].Replace(" ", "");
            }

            for (int i = 0; i < country.Count; i++)
            {
                country[i] = country[i].Trim();
                country[i] = country[i].Replace("\t", "");
                country[i] = Regex.Replace(country[i], @"\s+", " ");
               
            }

            for (int i = 0; i < country.Count; i++)
            {
                if (!atlets.ContainsKey(country[i]))
                {
                    atlets.Add(country[i], new List<string>());
                }
                atlets[country[i]].Add(name[i]);
            }

            var orderedAtlets = atlets.OrderByDescending(x => x.Value.Count());

            StringBuilder result = new StringBuilder();

            foreach (var item in orderedAtlets)
            {
                result.AppendFormat("{0} ({1} participants): {2} wins", item.Key, item.Value.Distinct().Count(), item.Value.Count()).AppendLine();
            }

            Console.Write(result.ToString());
        }
    }
}
