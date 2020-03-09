using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMatrixManager
    {
        char[,] GetMatrix(IEnumerable<string> matrix);

        bool SearchWordExistence(char[,] grid, int row, int col, string word);
    }
}
