using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;

namespace BLL
{
    public class MatrixManager : IMatrixManager
    {
        private readonly int _rows;

        private readonly int _columns;

        private readonly int[] _x = { 0, 1 };

        private readonly int[] _y = { 1, 0 };

        public MatrixManager(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public char[,] GetMatrix(IEnumerable<string> matrix)
        {
            if (!matrix.Any() || _columns != matrix.Count())
                return null;

            var charMatrix = new char[_rows, _columns];
            var colIndex = 0;

            foreach (var row in matrix)
            {
                var rowLength = row.Length;

                if (_rows != rowLength)
                    return null;

                for (var i = 0; i < rowLength; i++)
                    charMatrix[colIndex, i] = row[i];

                colIndex++;
            }

            return charMatrix;
        }

        public bool SearchWordExistence(char[,] grid, int row, int col, string word)
        {
            if (grid[row, col] != word[0])
                return false;

            var len = word.Length;

            for (var direction = 0; direction < 2; direction++)
            {
                int k, rowDir = row + _x[direction], colDir = col + _y[direction];

                for (k = 1; k < len; k++)
                {
                    if (rowDir >= _rows || rowDir < 0 || colDir >= _columns || colDir < 0)
                        break;

                    if (grid[rowDir, colDir] != word[k])
                        break;

                    rowDir += _x[direction];
                    colDir += _y[direction];
                }

                if (k == len)
                    return true;
            }

            return false;
        }
    }
}
