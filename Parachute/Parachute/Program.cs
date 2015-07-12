using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachute
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<int, List<char>> matrixLines = new Dictionary<int, List<char>>();
            int linesNumber = 0;
            char[] colCount = line.ToCharArray();
            List<string> checkWhereHeLanded = new List<string>();
            List<int> cordinates = new List<int>();

            while (line != "END")
            {
                linesNumber++;
                matrixLines.Add(linesNumber, new List<char>());
                char[]chars = line.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    matrixLines[linesNumber].Add(chars[i]);
                }

                line = Console.ReadLine();
            }

            char[,] matrix = new char[linesNumber, colCount.Length];
            int row1 = 0;
                foreach (var item in matrixLines.Values)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row1, col] = item[col];
                    }
                    row1++;
                }

                int x = 0;
                int y = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'o')
                        {
                            x = row;
                            y = col;
                        }
                    }
                }

                //Console.WriteLine("row = {0}, col = {1}", x, y);

                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if(matrix[x,y] == matrix[row, col])
                        {
                            int checkLeft = 0;
                            int checkRight = 0;
                            for (int i = 0; i < matrix.GetLength(1); i++)
                            {
                                if (matrix[row + 1, i] == '>')
                                {
                                    checkRight++;
                                }
                                else if (matrix[row + 1, i] == '<')
                                {
                                    checkLeft++;
                                }
                            }
                            if (checkLeft == 0 && checkRight == 0)
                            {
                                if (matrix[row +1 , col] == '/' || matrix[row + 1, col] == '\\' || matrix[row + 1, col] == '|')
                                {
                                    checkWhereHeLanded.Add("dog");
                                    cordinates.Add(row + 1);
                                    cordinates.Add(col - checkLeft);
                                }
                                else if (matrix[row + 1, col] == '_')
                                {
                                    checkWhereHeLanded.Add("boss");
                                    cordinates.Add(row + 1);
                                    cordinates.Add(col - checkLeft);
                                }
                                else if (matrix[row + 1, col] == '~')
                                {
                                    checkWhereHeLanded.Add("cat");
                                    cordinates.Add(row + 1);
                                    cordinates.Add(col - checkLeft);
                                }
                                matrix[row + 1, col] = matrix[x, y];
                            }
                            else
                            {
                                if (checkLeft > 0 && checkRight > 0)
                                {
                                    int rightAndLeft = 0;
                                    rightAndLeft = checkRight - checkLeft;
                                    matrix[row + 1, col + rightAndLeft] = matrix[x, y];

                                    checkLeft = 0;
                                    checkRight = 0;
                                }
                                else if (checkLeft > 0)
                                {
                                    if (matrix[row + 1, col - checkLeft] == '/' || matrix[row + 1, col - checkLeft] == '\\' || matrix[row + 1, col - checkLeft] == '|')
                                    {
                                        checkWhereHeLanded.Add("dog");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col - checkLeft);
                                    }
                                    else if (matrix[row + 1, col - checkLeft] == '_')
                                    {
                                        checkWhereHeLanded.Add("boss");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col - checkLeft);
                                    }
                                    else if (matrix[row + 1, col - checkLeft] == '~')
                                    {
                                        checkWhereHeLanded.Add("cat");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col - checkLeft);
                                    }
                                    matrix[row + 1, col - checkLeft] = matrix[x, y];
                                    checkLeft = 0;
                                }
                                else if (checkRight > 0)
                                {
                                    if (matrix[row + 1, col + checkRight] == '/' || matrix[row + 1, col + checkRight] == '\\' || matrix[row + 1, col + checkRight] == '|')
                                    {
                                        checkWhereHeLanded.Add("dog");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col + checkRight);
                                    }
                                    else if (matrix[row + 1, col + checkRight] == '_')
                                    {
                                        checkWhereHeLanded.Add("boss");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col + checkRight);
                                    }
                                    else if (matrix[row + 1, col + checkRight] == '~')
                                    {
                                        checkWhereHeLanded.Add("cat");
                                        cordinates.Add(row + 1);
                                        cordinates.Add(col + checkRight);
                                    }
                                    matrix[row + 1, col + checkRight] = matrix[x, y];
                                    checkRight = 0;
                                }
                            }
                               
                        }
                    }
                }

                //for (int row = 0; row < matrix.GetLength(0); row++)
                //{
                //    for (int col = 0; col < matrix.GetLength(1); col++)
                //    {
                //        Console.Write(matrix[row, col]);
                //    }
                //    Console.WriteLine();
                //}

                if (checkWhereHeLanded[0] == "dog")
                {
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    Console.WriteLine(cordinates[0] + " " + cordinates[1]);
                }
                else if (checkWhereHeLanded[0] == "cat")
                {
                    Console.WriteLine("Drowned in the water like a cat!");
                    Console.WriteLine(cordinates[0] + " " + cordinates[1]);
                }
                else if (checkWhereHeLanded[0] == "boss")
                {
                    Console.WriteLine("Landed on the ground like a boss!");
                    Console.WriteLine(cordinates[0] + " " + cordinates[1]);
                }
        }
    }
}
