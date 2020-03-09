using System.Collections.Generic;
using BLL;
using Xunit;

namespace Tests
{
    public class MatrixManagerUnitTest
    {
        [Fact]
        public void MatrixCreationWithAllData()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetMatrixAllData();
            var charMatrix = matrixManager.GetMatrix(matrix);
            var resultMatrix = GetExpectedMatrixAllData();

            Assert.Equal(resultMatrix, charMatrix);
        }


        [Fact]
        public void MatrixCreationWithEmptyList()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = new List<string>();
            var charMatrix = matrixManager.GetMatrix(matrix);

            Assert.Null(charMatrix);
        }

        [Fact]
        public void MatrixCreationIfColumnsLessCheck()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetMatrixLessColumns();
            var charMatrix = matrixManager.GetMatrix(matrix);

            Assert.Null(charMatrix);
        }

        [Fact]
        public void MatrixCreationIfRowsLessCheck()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetMatrixLessRows();
            var charMatrix = matrixManager.GetMatrix(matrix);

            Assert.Null(charMatrix);
        }

        [Fact]
        public void WordSearchInFirstRowNotExist()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetExpectedMatrixAllData();
            var word = "cool";

            var result = matrixManager.SearchWordExistence(matrix, 0, 0, word);

            Assert.False(result);
        }

        [Fact]
        public void WordSearchInFirstRowExist()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetExpectedMatrixAllData();
            var word = "snow";

            var result = matrixManager.SearchWordExistence(matrix, 0, 0, word);

            Assert.True(result);
        }

        [Fact]
        public void WordSearchDuplicate()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetExpectedMatrixAllData();
            var word = "all";
            var count = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    var result = matrixManager.SearchWordExistence(matrix, i, j, word);

                    if (result)
                        count++;
                }
            }

            Assert.True(count == 2);
        }

        [Fact]
        public void WordSearchNotExist()
        {
            var matrixManager = new MatrixManager(5, 5);
            var matrix = GetExpectedMatrixAllData();
            var word = "payne";
            var result = false;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                    result = matrixManager.SearchWordExistence(matrix, i, j, word);
            }

            Assert.False(result);
        }

        private IEnumerable<string> GetMatrixAllData()
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

        private IEnumerable<string> GetMatrixLessColumns()
        {
            return new List<string>
            {
                { "snowb" },
                { "wjutm" },
                { "amrta" },
                { "payne" }
            };
        }

        private IEnumerable<string> GetMatrixLessRows()
        {
            return new List<string>
            {
                { "snowb" },
                { "wjutm" },
                { "amrt" },
                { "payne" },
                { "ihyab" },
            };
        }

        private char[,] GetExpectedMatrixAllData()
        {
            return new[,]
            {
                {'s', 'n', 'o', 'w', 'a'},
                {'a', 'l', 'l', 't', 'l'},
                {'a', 'm', 'r', 't', 'l'},
                {'p', 'a', 'y', 'n', 't'},
                {'i', 'h', 'y', 'a', 'w'}
            };
        }
    }
}
