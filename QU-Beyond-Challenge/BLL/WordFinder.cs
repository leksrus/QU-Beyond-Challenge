using BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;

        private readonly IMatrixManager _matrixManager;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            _matrixManager = new MatrixManager();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            throw new NotImplementedException();
        }
    }
}
