using BLL.Interfaces;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;

        private readonly IMatrixManager _matrixManager;

        private readonly int _matrixRowsLegth;

        private readonly int _matrixColumnsLegth;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            _matrixRowsLegth = matrix.First().Length;
            _matrixColumnsLegth = matrix.Count();
            _matrixManager = new MatrixManager(_matrixRowsLegth, _matrixColumnsLegth);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            var charMatrix = _matrixManager.GetMatrix(_matrix);
            var dictionary = new ConcurrentDictionary<string, int>();
            var tasks = new List<Task>
            {
                Task.Run(() =>
                    {
                        foreach (var word in wordStream)
                        {
                            var words = SearchWord(word, charMatrix);
                            dictionary.AddOrUpdate(word, words.Count(), (key, oldValue) => oldValue + words.Count());
                        }
                    }
                )
            };

            Task.WaitAll(tasks.ToArray());

            var topWords = dictionary.Where(i => i.Value > 0)
                                               .OrderByDescending(x => x.Value)
                                               .Select(element => element.Key)
                                               .Take(10).ToList();

            return topWords;
        }

        private IEnumerable<string> SearchWord(string word, char[,] charMatrix)
        {
            var matchWords = new List<string>();

            for (var i = 0; i < _matrixRowsLegth; i++)
            {
                for (var j = 0; j < _matrixColumnsLegth; j++)
                {
                    var result = _matrixManager.SearchWordExistence(charMatrix, i, j, word);

                    if (result)
                        matchWords.Add(word);
                }
            }

            return matchWords;
        }
    }
}
