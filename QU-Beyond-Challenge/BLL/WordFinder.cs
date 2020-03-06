using BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            throw new NotImplementedException();
        }
    }
}
