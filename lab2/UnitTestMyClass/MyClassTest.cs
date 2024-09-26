using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LibraryLab2;

namespace UnitTestMyClass
{
    [TestClass]
    public class MyClassTest
    {
        [TestMethod]
        public void FindMaxTest1()
        {
            //arrange
            int first = 3;
            int second = 2;
            int third = 1;
            int expected = 3;
            //act
            int actual = MyClass.FindMax(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxTest2()
        {
            //arrange
            int first = 1;
            int second = 3;
            int third = 2;
            int expected = 3;
            //act
            int actual = MyClass.FindMax(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxTest3()
        {
            //arrange
            int first = 1;
            int second = 2;
            int third = 3;
            int expected = 3;
            //act
            int actual = MyClass.FindMax(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxTest4()
        {
            //arrange
            int first = 0;
            int second = 0;
            int third = 0;
            int expected = 0;
            //act
            int actual = MyClass.FindMax(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxTest5()
        {
            //arrange
            int first = 10;
            int second = 10;
            int third = 10;
            int expected = 10;
            //act
            int actual = MyClass.FindMax(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductOfElementsWithEvenSumOfIndicesTest1()
        {
            //arrange
            double[,] matrix = { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0} };
            double expected = 20.0;
            //act
            double actual = MyClass.ProductOfElementsWithEvenSumOfIndices(matrix);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductOfElementsWithEvenSumOfIndicesTest2()
        {
            //arrange
            double[,] matrix = { { 4.0} };
            double expected = 4.0;
            //act
            double actual = MyClass.ProductOfElementsWithEvenSumOfIndices(matrix);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyClass.invalid_exception_2))]
        public void ProductOfElementsWithEvenSumOfIndicesTest3()
        {
            //arrange
            double[,] matrix = null;
            //act
            double actual = MyClass.ProductOfElementsWithEvenSumOfIndices(matrix);

        }

        [TestMethod]
        [ExpectedException(typeof(MyClass.invalid_exception_3))]
        public void ProductOfElementsWithEvenSumOfIndicesTest4()
        {
            //arrange
            int row = 3, col = 0;
            double[,] matrix = new double[row, col];
            //act
            double actual = MyClass.ProductOfElementsWithEvenSumOfIndices(matrix);

        }

        [TestMethod]
        public void MinValueOnAndBelowDiagonalTest1()
        {
            //arrange
            double[,] matrix = { { 43.0, 63.0, 87.0 }, { 1.0, 0.5, 0.4 }, { 115.0, -62.0, 193.0 } };
            double expected = -62.0;
            //act
            double actual = MyClass.MinValueOnAndBelowDiagonal(matrix);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyClass.invalid_exception_1))]
        public void MinValueOnAndBelowDiagonalTest2()
        {
            //arrange
            double[,] matrix = { { 43.0, 63.0}, { 1.0, 0.5}, { 115.0, -62.0} };
            //act
            double actual = MyClass.MinValueOnAndBelowDiagonal(matrix);

        }

        [TestMethod]
        [ExpectedException(typeof(MyClass.invalid_exception_2))]
        public void MinValueOnAndBelowDiagonalTest3()
        {
            //arrange
            double[,] matrix = null;
            //act
            double actual = MyClass.MinValueOnAndBelowDiagonal(matrix);

        }

        [TestMethod]
        [ExpectedException(typeof(MyClass.invalid_exception_3))]
        public void MinValueOnAndBelowDiagonalTest4()
        {
            //arrange
            int rows = 0, cols = 3;
            double[,] matrix = new double[rows, cols];
            //act
            double actual = MyClass.MinValueOnAndBelowDiagonal(matrix);

        }
        
    }
}
