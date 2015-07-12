using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string matrixCordinates = Console.ReadLine();
            string[] matrixCordArr = matrixCordinates.Split(' ');
            char[,] matrix = new char[int.Parse(matrixCordArr[0]), int.Parse(matrixCordArr[1])];
            string input = Console.ReadLine();
            string rowColRadius = Console.ReadLine();
            string[] rowColRadiusArr = rowColRadius.Split(' ');
            int impactRow = int.Parse(rowColRadiusArr[0]);
            int impactCol = int.Parse(rowColRadiusArr[1]);
            int impactRadius = int.Parse(rowColRadiusArr[2]);
            int defaultImpactRadius = int.Parse(rowColRadiusArr[2]);

            int count = 0;
            int checker = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                checker++;
                if (checker % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[count];
                        count++;
                        if (count == input.Length)
                        {
                            count = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = input[count];
                        count++;
                        if (count == input.Length)
                        {
                            count = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol) <= impactRadius * impactRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                        }
                    }
                }
            }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

            }
        }
    }
