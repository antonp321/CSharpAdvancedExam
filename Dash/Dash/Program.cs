using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            char[][] inputLinesArr = new char[lines][];
            List<char> moves = new List<char>();

            for (int i = 0; i < lines + 1; i++)
            {
                if (i >= 0 && i < lines)
                {
                    string inputLines = Console.ReadLine();
                    inputLinesArr[i] = inputLines.ToCharArray();
                }
                else if (i == lines)
                {
                    string inputMoves = Console.ReadLine();
                    for (int o = 0; o < inputMoves.Length; o++)
                    {
                        moves.Add(inputMoves[o]);
                    }
                }
            }
            

            //for (int row = 0; row < lines; row++)
            //{
            //    for (int col = 0; col < inputLinesArr[row].Length; col++)
            //    {
            //        Console.Write(inputLinesArr[row][col]);
            //    }
            //    Console.WriteLine();
            //}


            int lives = 3;
            int rowCount = 0;
            int colCount = 0;
            int movesCount = 0;

            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i] == '>')
                {
                    movesCount++;
                    colCount++;
                    if (colCount < 0 || colCount >= inputLinesArr[rowCount].Length)
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        break;
                    }
                    else
                    {
                        if (inputLinesArr[rowCount][colCount] == '|' || inputLinesArr[rowCount][colCount] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                            colCount--;
                            movesCount--;
                        }
                        else if (inputLinesArr[rowCount][colCount] == '#' || inputLinesArr[rowCount][colCount] == '*' || inputLinesArr[rowCount][colCount] == '@')
                        {
                            lives--;
                            Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                            if (lives <= 0)
                            {
                                Console.WriteLine("No lives left! Game Over!");
                                break;
                            }
                        }
                        else if (inputLinesArr[rowCount][colCount] == '$')
                        {
                            inputLinesArr[rowCount][colCount] = '.';
                            lives++;
                            Console.WriteLine("Awesome! Lives left: {0}", lives);
                        }
                        else if (inputLinesArr[rowCount][colCount] == '.')
                        {
                            Console.WriteLine("Made a move!");
                        }
                        else if (inputLinesArr[rowCount][colCount] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                     
                            break;
                        }
                    }
                }

                else if (moves[i] == '<')
                {
                    colCount--;
                    movesCount++;
                    if (colCount < 0 || colCount >= inputLinesArr[rowCount].Length)
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
              
                        break;
                    }
                    else
                    {
                        if (inputLinesArr[rowCount][colCount] == '|' || inputLinesArr[rowCount][colCount] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                            colCount++;
                            movesCount--;
                        }
                        else if ( inputLinesArr[rowCount][colCount] == '#' || inputLinesArr[rowCount][colCount] == '*' || inputLinesArr[rowCount][colCount] == '@')
                        {
                            lives--;
                            Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                            if (lives <= 0)
                            {
                                Console.WriteLine("No lives left! Game Over!");
                                break;
                            }
                        }
                        else if (inputLinesArr[rowCount][colCount] == '$')
                        {
                            inputLinesArr[rowCount][colCount] = '.';
                            lives++;
                            Console.WriteLine("Awesome! Lives left: {0}", lives);
                        }
                        else if (inputLinesArr[rowCount][colCount] == '.')
                        {
                            Console.WriteLine("Made a move!");
                        }
                        else if (inputLinesArr[rowCount][colCount] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                       
                            break;
                        }
                    }
                }
                else if (moves[i] == 'v')
                {
                    rowCount++;
                    movesCount++;
                    if (rowCount < 0 || rowCount >= inputLinesArr.Length)
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                       
                        break;
                    }
                    else
                    {
                        if (inputLinesArr[rowCount][colCount] == '|' || inputLinesArr[rowCount][colCount] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                            rowCount--;
                            movesCount--;
                        }
                        else if ( inputLinesArr[rowCount][colCount] == '#' || inputLinesArr[rowCount][colCount] == '*' || inputLinesArr[rowCount][colCount] == '@')
                        {
                            lives--;
                            Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                            if (lives <= 0)
                            {
                                Console.WriteLine("No lives left! Game Over!");
                                break;
                            }
                        }
                        else if (inputLinesArr[rowCount][colCount] == '$')
                        {
                            inputLinesArr[rowCount][colCount] = '.';
                            lives++;
                            Console.WriteLine("Awesome! Lives left: {0}", lives);
                        }
                        else if (inputLinesArr[rowCount][colCount] == '.')
                        {
                            Console.WriteLine("Made a move!");
                        }
                        else if (inputLinesArr[rowCount][colCount] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                           
                            break;
                        }
                    }
                }
                else if (moves[i] == '^')
                {
                    rowCount--;
                    movesCount++;
                    if (rowCount < 0 || rowCount >= inputLinesArr.Length)
                    {
                        Console.WriteLine("Fell off a cliff! Game Over!");
                       
                        break;
                    }
                    else
                    {
                        if (inputLinesArr[rowCount][colCount] == '|' || inputLinesArr[rowCount][colCount] == '_')
                        {
                            Console.WriteLine("Bumped a wall.");
                            rowCount++;
                            movesCount--;
                        }
                        else if (inputLinesArr[rowCount][colCount] == '#' || inputLinesArr[rowCount][colCount] == '*' || inputLinesArr[rowCount][colCount] == '@')
                        {
                            lives--;
                            Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                            if (lives <= 0)
                            {
                                Console.WriteLine("No lives left! Game Over!");
                                break;
                            }
                        }
                        else if (inputLinesArr[rowCount][colCount] == '$')
                        {
                            inputLinesArr[rowCount][colCount] = '.';
                            lives++;
                            Console.WriteLine("Awesome! Lives left: {0}", lives);
                        }
                        else if (inputLinesArr[rowCount][colCount] == '.')
                        {
                            Console.WriteLine("Made a move!");
                        }
                        else if (inputLinesArr[rowCount][colCount] == ' ')
                        {
                            Console.WriteLine("Fell off a cliff! Game Over!");
                           
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Total moves made: {0}", movesCount++);
        }
    }
}
