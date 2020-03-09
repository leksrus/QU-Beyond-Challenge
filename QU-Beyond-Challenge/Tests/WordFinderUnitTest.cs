using System.Collections.Generic;
using BLL;
using Xunit;

namespace Tests
{
    public class WordFinderUnitTest
    {
        [Fact]
        public void FindAllWords()
        {
            var wordFinder = new WordFinder(GetMatrix());
            var wordSteam = GetWordStream();
            var topWord = wordFinder.Find(wordSteam);

            var expectedResult = GetTop10Words();

            Assert.Equal(expectedResult, topWord);
        }

        [Fact]
        public void FindAllWordsEmpty()
        {
            var wordFinder = new WordFinder(GetMatrix());
            var wordSteam = GetWordsStreamTwo();
            var topWord = wordFinder.Find(wordSteam);

            var expectedResult = new List<string>();

            Assert.Equal(expectedResult, topWord);
        }

        private IEnumerable<string> GetMatrix()
        {
            return new List<string>
            {
                { "snowa" },
                { "alltl" },
                { "amrtl" },
                { "paynt" },
                { "ihyaw" },
            };
        }

        private IEnumerable<string> GetWordStream()
        {
            return new List<string>
                {
                    { "snow" },
                    { "all" },
                    { "payne" },
                };
        }

        private IEnumerable<string> GetTop10Words()
        {
            return new List<string>
            {
                { "all" },
                { "snow" },
                { "payne" },
            };
        }

        private IEnumerable<string> GetWordsStreamTwo()
        {
            return new List<string>
            {
                { "mars" },
                { "know" },
                { "payne" },
            };
        }
    }
}
