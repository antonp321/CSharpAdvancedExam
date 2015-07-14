using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGravity
{
    class Program
    {
        static void Main(string[] args)
        {
            int theMatrixColsLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            char[] inputInCharsSymbols = input.ToCharArray();
            int matrixRows = 0;
            if (inputInCharsSymbols.Length % theMatrixColsLength == 0)
            {
                matrixRows = inputInCharsSymbols.Length / theMatrixColsLength;
            }
            else
            {
                matrixRows = (inputInCharsSymbols.Length / theMatrixColsLength) + 1;
            }
            char[,] gravityMatrix = new char[matrixRows, theMatrixColsLength];
            int inputCharsSymbolsCounter = 0;

            for (int row = 0; row < gravityMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < gravityMatrix.GetLength(1); col++)
                {
                    if (inputCharsSymbolsCounter > inputInCharsSymbols.Length - 1)
                    {
                        gravityMatrix[row, col] = ' ';
                    }
                    else
                    {
                        gravityMatrix[row, col] = inputInCharsSymbols[inputCharsSymbolsCounter];
                    }
                    inputCharsSymbolsCounter++;
                }
            }

            bool fallen = false;
            do
            {
                fallen = false;
                for (int row = 0; row < gravityMatrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < gravityMatrix.GetLength(1); col++)
                    {
                        if (gravityMatrix[row, col] != ' ' && gravityMatrix[row + 1, col] == ' ')
                        {
                            gravityMatrix[row + 1, col] = gravityMatrix[row, col];
                            gravityMatrix[row, col] = ' ';
                            fallen = true;
                        }
                    }
                }
            } while (fallen);

            StringBuilder result = new StringBuilder();

            result.Append("<table>");
            for (int row = 0; row < gravityMatrix.GetLength(0); row++)
            {
                result.Append("<tr>");
                for (int col = 0; col < gravityMatrix.GetLength(1); col++)
                {
                    result.Append("<td>" + gravityMatrix[row, col] + "</td>");
                }
                result.Append("</tr>");
                if (row == gravityMatrix.GetLength(0) - 1)
                {
                    result.Append("</table>");
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
