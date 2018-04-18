using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1() //X gana horizontal en 3x3
        {
            var validations = new Validations();
            string[,] matrix = new String[,] { { "X", "O", "3" }, 
                                               { "X", "5", "O"}, 
                                               { "X", "8", "9" } };
            bool playerPlaying = true;
            bool expectedResult = true;
            int size = 3;
            bool actualResult = Validations.Vertical(matrix, size, playerPlaying);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test2() //O gana diagonal en 4x4
        {
            var validations = new Validations();
            string[,] matrix = new String[,] { { "O", "X", "2", "O" }, 
                                               { "X", "O", "6", "7" }, 
                                               { "8", "9", "O", "11" },
                                               { "X", "X", "14", "O"}};
            bool playerPlaying = false;
            bool expectedResult = true;
            int size = 4;
            bool actualResult = Validations.Diagonal1(matrix, size, playerPlaying);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test3() //X gana diagonal en 4x4
        {
            var validations = new Validations();
            string[,] matrix = new String[,] { { "O", "O", "2", "X" },
                                               { "X", "O", "X", "7" },
                                               { "8", "X", "O", "11" },
                                               { "X", "X", "14", "O"}};
            bool playerPlaying = true;
            bool expectedResult = true;
            int size = 4;
            bool actualResult = Validations.Diagonal2(matrix, size, playerPlaying);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test4() //O gana vertical en 6x6.
        {
            var validations = new Validations();
            string[,] matrix = new String[,] { { "O", "O", "2", "X", "4", "5" },
                                               { "X", "O", "8", "O", "10", "11" },
                                               { "O", "O", "O", "X", "16", "17" },
                                               { "X", "O", "20", "X", "22", "23"},
                                               { "X", "O", "26", "X", "28", "29"},
                                               { "X", "O", "32", "X", "34", "35"}};
            bool playerPlaying = false;
            bool expectedResult = true;
            int size = 6;
            bool actualResult = Validations.Vertical(matrix, size, playerPlaying);
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}