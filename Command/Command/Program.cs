using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(' ');
            string command = Console.ReadLine();
            bool isItInvalid = false;
            List<string> mostImportantList = new List<string>();
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                mostImportantList.Add(inputNumbers[i]);
            }

            while (command != "end")
            {
                List<string> numbers = new List<string>();
                string[] commandWords = command.Split(' ');
                int stringsLeft = 0;
                if (commandWords[0] == "reverse" || commandWords[0] == "sort")
                {
                    if (int.Parse(commandWords[4]) >= 0)
                    {
                        for (int i = int.Parse(commandWords[2]); i < mostImportantList.Count; i++)
                        {
                            stringsLeft++;
                        }
                    }

                    if (int.Parse(commandWords[2]) > mostImportantList.Count - 1 || int.Parse(commandWords[2]) < 0 || int.Parse(commandWords[4]) > stringsLeft || int.Parse(commandWords[4]) < 0)
                    {
                        isItInvalid = true;
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                if (isItInvalid == false && (commandWords[0] == "reverse" || commandWords[0] == "sort"))
                    {
                        for (int i = int.Parse(commandWords[2]); i < int.Parse(commandWords[2]) + int.Parse(commandWords[4]); i++)
                        {
                            numbers.Add(mostImportantList[i]);
                        }
                        if (commandWords[0] == "reverse")
                        {
                            numbers.Reverse();
                        }
                        else if (commandWords[0] == "sort")
                        {
                            numbers.Sort();
                        }


                        int count = 0;
                        for (int i = int.Parse(commandWords[2]); i < int.Parse(commandWords[2]) + int.Parse(commandWords[4]); i++)
                        {
                            mostImportantList[i] = numbers[count];
                            count++;
                        }
                    }

                    else if (commandWords[0] == "rollLeft")
                    {

                        int times = int.Parse(commandWords[1]);
                        for (int i = 0; i < times; i++)
                        {
                            mostImportantList.Add(mostImportantList[0]);
                            mostImportantList.Remove(mostImportantList[0]);
                        }
                    }

                    else if (commandWords[0] == "rollRight")
                    {
                        mostImportantList.Reverse();

                        int times = int.Parse(commandWords[1]);
                        for (int i = 0; i < times; i++)
                        {
                            mostImportantList.Add(mostImportantList[0]);
                            mostImportantList.Remove(mostImportantList[0]);
                        }

                        mostImportantList.Reverse();
                    
                }
                command = Console.ReadLine();
            }

                int count4 = 0;
                Console.Write("[");
                foreach (var item in mostImportantList)
                {
                    count4++;
                    if (count4 == mostImportantList.Count)
                    {
                        Console.Write("{0}] ", item);
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



