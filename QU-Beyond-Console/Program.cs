using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL;
using Microsoft.Extensions.Configuration;

namespace QU_Beyond_Challenge
{
    class Program
    {
        private static IConfiguration _configuration;

        static void Main(string[] args)
        {
            Configure();
            var matrix = GetMatrix();
            var wordStream = GetWordStream();
            var topWords = new WordFinder(matrix).Find(wordStream);

            topWords.ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }


        private static void Configure()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }

        private static IEnumerable<string> GetMatrix()
        {
            var rowsNumber = 64;

            var matrix = new List<string>();

            for (var i = 0; i <= rowsNumber; i++)
                matrix.Add(_configuration["Matrix:row" + i]);

            return matrix;
        }

        private static IEnumerable<string> GetWordStream()
        {
            var wordsNumber = 12;
            var wordSteam = new List<string>();

            for (var i = 0; i <= wordsNumber; i++)
                wordSteam.Add(_configuration["WordStream:word" + i]);

            return wordSteam;
        }
    }
}
