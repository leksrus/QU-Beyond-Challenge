using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL
{
    public class MatrixManager : IMatrixManager
    {
        private const int Rows = 64;

        private const int Columns = 64;

        private readonly int[] _x = { 0, 1 };

        private readonly int[] _y = { -1, 0 };


        public char[,] GetMatrix(IEnumerable<string> matrix)
        {
            var charMatrix = new char[Rows, Columns];
            var colIndex = 0;

            foreach (var row in matrix)
            {
                var rowLength = row.Length;

                for (var i = 0; i < rowLength; i++)
                    charMatrix[colIndex, i] = row[i];

                colIndex++;
            }

            return charMatrix;
        }

        public bool SearchWord(char[,] grid, int row, int col, string word)
        {
            // If first character of word doesn't match  
            // with given starting point in grid.  
            if (grid[row, col] != word[0])
                return false;

            var len = word.Length;

            // Search word in all 8 directions  
            // starting from (row,col)  
            for (int direction = 0; direction < 2; direction++)
            {
                // Initialize starting point  
                // for current direction  
                int k, rd = row + _x[direction], cd = col + _y[direction];

                // First character is already checked,  
                // match remaining characters  
                for (k = 1; k < len; k++)
                {
                    // If out of bound break  
                    if (rd >= Rows || rd < 0 || cd >= Columns || cd < 0)
                        break;

                    // If not matched, break  
                    if (grid[rd, cd] != word[k])
                        break;

                    // Moving in particular direction  
                    rd += _x[direction];
                    cd += _y[direction];
                }

                // If all character matched, then value of k 
                // must be equal to length of word  
                if (k == len)
                    return true;
            }

            return false;
        }
    }
}
