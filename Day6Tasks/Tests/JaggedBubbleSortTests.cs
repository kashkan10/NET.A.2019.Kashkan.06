using NUnit.Framework;
using JaggedBubbleSort;

namespace Tests
{
    public class JaggedBubbleSortTests
    {
        [Test]
        public void SumOfSortAscTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2},
                new int []{1,2,3,4,5}
            };

            int[][] expected= new int[4][]
            {
                new int []{1,2},
                new int []{1,2,3},
                new int []{1,2,3,4,5},
                new int []{1,2,3,4,5,6,7,8}
            };

            array.SumOfSortAsc();
            Assert.AreEqual(array,expected);
        }

        [Test]
        public void SumOfSortDescTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2},
                new int []{1,2,3,4,5}
            };

            int[][] expected = new int[4][]
            {
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2,3,4,5},
                new int []{1,2,3},
                new int []{1,2}
            };

            array.SumOfSortDesc();
            Assert.AreEqual(array, expected);
        }

        [Test]
        public void MaxOfSortAscTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2},
                new int []{1,2,3,4,5,9}
            };

            int[][] expected = new int[4][]
            {
                new int []{1,2},
                new int []{1,2,3},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2,3,4,5,9} 
            };

            array.MaxOfSortAsc();
            Assert.AreEqual(array, expected);
        }

        [Test]
        public void MaxOfSortDescTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2},
                new int []{1,2,3,4,5,9}
            };

            int[][] expected = new int[4][]
            {
                new int []{1,2,3,4,5,9},
                new int []{1,2,3,4,5,6,7,8},
                new int []{1,2,3},
                new int []{1,2}
            };

            array.MaxOfSortDesc();
            Assert.AreEqual(array, expected);
        }

        [Test]
        public void MinOfSortAscTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{4,5,6,7,8},
                new int []{0,1,2},
                new int []{1,2,3,4,5,9}
            };

            int[][] expected = new int[4][]
            {
                new int []{0,1,2},
                new int []{1,2,3},
                new int []{1,2,3,4,5,9},
                new int []{4,5,6,7,8},
            };

            array.MinOfSortAsc();
            Assert.AreEqual(array, expected);
        }

        [Test]
        public void MinOfSortDescTest()
        {
            int[][] array = new int[4][]
            {
                new int []{1,2,3},
                new int []{4,5,6,7,8},
                new int []{0,1,2},
                new int []{1,2,3,4,5,9}
            };

            int[][] expected = new int[4][]
            {
                new int []{4,5,6,7,8},
                new int []{1,2,3},
                new int []{1,2,3,4,5,9},
                new int []{0,1,2}
            };

            array.MinOfSortDesc();
            Assert.AreEqual(array, expected);
        }
    }
}