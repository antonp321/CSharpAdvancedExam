using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            string inputGender = Console.ReadLine();
            string inputEGN = Console.ReadLine();
            List<int> egnToInt = new List<int>();

            string[] splitNames = inputName.Split(' ');
            if (splitNames.Length == 1)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
            }
            else
            {
                if (!char.IsUpper(splitNames[0][0]) || !char.IsUpper(splitNames[1][0]))
                {
                    Console.WriteLine("<h2>Incorrect data</h2>");
                }
                else
                {
                    if (inputGender != "male" && inputGender != "female")
                    {
                        Console.WriteLine("<h2>Incorrect data</h2>");
                    }
                    else
                    {
                        char[] egnNumbers = inputEGN.ToCharArray();
                        for (int i = 0; i < egnNumbers.Length; i++)
                        {
                            egnToInt.Add(int.Parse(egnNumbers[i].ToString()));
                        }

                        int yearsDigits = int.Parse(egnToInt[0].ToString() + egnToInt[1].ToString());
                        int monthsDigits = int.Parse(egnToInt[2].ToString() + egnNumbers[3].ToString());
                        int dayDigits = int.Parse(egnToInt[4].ToString() + egnNumbers[5].ToString());

                        if (dayDigits > 31 && dayDigits < 1)
                        {
                            Console.WriteLine("<h2>Incorrect data</h2>");
                        }
                        else
                        {
                            int genderInteger = egnToInt[8];
                            if ((inputGender == "female" && genderInteger % 2 == 0) || (inputGender == "male" && genderInteger % 2 == 1))
                            {
                                Console.WriteLine("<h2>Incorrect data</h2>");
                            }
                            else
                            {
                                int checkSum = egnToInt[0] * 2 +
                                    egnToInt[1] * 4 +
                                    egnToInt[2] * 8 +
                                    egnToInt[3] * 5 +
                                    egnToInt[4] * 10 +
                                    egnToInt[5] * 9 +
                                    egnToInt[6] * 7 +
                                    egnToInt[7] * 3 +
                                    egnToInt[8] * 6;
                                int checkDivider = checkSum % 11;
                                if (checkDivider == 10)
                                {
                                    checkDivider = 0;
                                }

                                if (checkDivider != egnToInt[9])
                                {
                                    Console.WriteLine("<h2>Incorrect data</h2>");
                                }
                                else
                                {
                                    Console.Write("{");
                                    Console.Write("\"name\":\"" + inputName + "\"" + "," + "\"gender\":\"" + inputGender + "\"" + "," + "\"pin\":\"" + inputEGN + "\"");
                                    Console.Write("}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
