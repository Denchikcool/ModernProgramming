using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab4;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueI()
        {
            //act
            Matrix a = new Matrix(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueJ()
        {
            //act
            Matrix a = new Matrix(2, 0);
        }

        [TestMethod]
        public void CorrectMatrix()
        {
            //act
            Matrix a = new Matrix(2, 2);
        }

        [TestMethod]
        public void CorrectSet()
        {
            //act
            Matrix a = new Matrix(2, 2);
            a[1, 1] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueSetI()
        {
            //act
            Matrix a = new Matrix(2, 2);
            a[5, 1] = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueSetJ()
        {
            //act
            Matrix a = new Matrix(2, 2);
            a[1, 3] = 2;
        }

        [TestMethod]
        public void CorrectGet()
        {
            //act
            Matrix a = new Matrix(2, 2);
            int r = a[1, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueGetI()
        {
            //act
            Matrix a = new Matrix(2, 2);
            int r = a[3, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void WrongValueGetJ()
        {
            //act
            Matrix a = new Matrix(2, 2);
            int r = a[1, 5];
        }

        [TestMethod]
        public void Sum()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 2; expected[0, 1] = 2; expected[1, 0] = 2; expected[1, 1] = 2;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a + b;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void SumWrongRows()
        {
            //arrange
            Matrix a = new Matrix(3, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1; a[2, 0] = 1; a[2, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void SumWrongCols()
        {
            //arrange
            Matrix a = new Matrix(2, 3);
            a[0, 0] = 1; a[0, 1] = 1; a[0, 2] = 1; a[1, 0] = 1; a[1, 1] = 1; a[1, 2] = 1; 
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a + b;
        }

        [TestMethod]
        public void Subtraction()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 5; a[0, 1] = 3; a[1, 0] = 10; a[1, 1] = -7;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 9; b[0, 1] = 3; b[1, 0] = 15; b[1, 1] = -9;
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = -4; expected[0, 1] = 0; expected[1, 0] = -5; expected[1, 1] = 2;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a - b;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void SubtractionWrongRows()
        {
            //arrange
            Matrix a = new Matrix(3, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1; a[2, 0] = 1; a[2, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a - b;
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void SubtractionWrongCols()
        {
            //arrange
            Matrix a = new Matrix(2, 3);
            a[0, 0] = 1; a[0, 1] = 1; a[0, 2] = 1; a[1, 0] = 1; a[1, 1] = 1; a[1, 2] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            Matrix actual = new Matrix(2, 2);
            //act
            actual = a - b;
        }

        [TestMethod]
        public void Multiply()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 3; a[0, 1] = 2; a[1, 0] = -6; a[1, 1] = 12;
            Matrix b = new Matrix(2, 3);
            b[0, 0] = 6; b[0, 1] = 21; b[0, 2] = 0; b[1, 0] = -2; b[1, 1] = 4; b[1, 2] = 7;
            Matrix expected = new Matrix(2, 3);
            expected[0, 0] = 14; expected[0, 1] = 71; expected[0, 2] = 14; expected[1, 0] = -60; expected[1, 1] = -78; expected[1, 2] = 84;
            Matrix actual = new Matrix(2, 3);
            //act
            actual = a * b;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MultiplyWrongSize()
        {
            //arrange
            Matrix a = new Matrix(2, 3);
            a[0, 0] = 3; a[0, 1] = 2; a[0, 2] = 43; a[1, 0] = -6; a[1, 1] = 12; a[1, 2] = 0;
            Matrix b = new Matrix(2, 3);
            b[0, 0] = 6; b[0, 1] = 21; b[0, 2] = 0; b[1, 0] = -2; b[1, 1] = 4; b[1, 2] = 7;
            Matrix actual = new Matrix(2, 3);
            //act
            actual = a * b;
        }

        [TestMethod]
        public void Transposition()
        {
            //arrange
            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 4;
            expected[1, 0] = 2; expected[1, 1] = 5;
            Matrix actual = new Matrix(2, 2);
            actual[0, 0] = 1; actual[0, 1] = 2;
            actual[1, 0] = 4; actual[1, 1] = 5;
            //act
            actual.Transp();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TranspositionWrongSize()
        {
            //arrange
            Matrix a = new Matrix(2, 3);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3;
            a[1, 0] = 4; a[1, 1] = 5; a[1, 2] = 6;
            //act
            a.Transp();
        }

        [TestMethod]
        public void MinElement()
        {
            //arrange
            Matrix a = new Matrix(3, 2);
            a[0, 0] = 33; a[0, 1] = 5;
            a[1, 0] = 0; a[1, 1] = -2;
            a[2, 0] = 90; a[2, 1] = -13;
            int expected = -13;
            //act
            int actual = a.Min();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MatrixToString()
        {
            //arrange
            Matrix a = new Matrix(3, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;
            a[2, 0] = 5; a[2, 1] = 6;
            string expected = "{{1, 2}, {3, 4}, {5, 6}}";
            //act
            string actual = a.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TakeElement()
        {
            //arrange
            int row = 2;
            int col = 1;
            Matrix a = new Matrix(3, 3);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3;
            a[1, 0] = 4; a[1, 1] = 5; a[1, 2] = 6;
            a[2, 0] = 7; a[2, 1] = 8; a[2, 2] = 9;
            int expected = 8;
            //act
            int actual = a.TakeElement(row, col);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TakeElementWrongI()
        {
            //arrange
            int row = -1;
            int col = 1;
            Matrix a = new Matrix(3, 3);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3;
            a[1, 0] = 4; a[1, 1] = 5; a[1, 2] = 6;
            a[2, 0] = 7; a[2, 1] = 8; a[2, 2] = 9;
            //act
            int actual = a.TakeElement(row, col);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TakeElementWrongJ()
        {
            //arrange
            int row = 2;
            int col = 5;
            Matrix a = new Matrix(3, 3);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3;
            a[1, 0] = 4; a[1, 1] = 5; a[1, 2] = 6;
            a[2, 0] = 7; a[2, 1] = 8; a[2, 2] = 9;
            //act
            int actual = a.TakeElement(row, col);
        }

        [TestMethod]
        public void CountRows()
        {
            //arrange
            Matrix a = new Matrix(4, 1);
            a[0, 0] = 1;
            a[1, 0] = 2;
            a[2, 0] = 3;
            a[3, 0] = 4;
            int expected = 4;
            //act
            int actual = a.CountRows();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountCols()
        {
            //arrange
            Matrix a = new Matrix(4, 1);
            a[0, 0] = 1;
            a[1, 0] = 2;
            a[2, 0] = 3;
            a[3, 0] = 4;
            int expected = 1;
            //act
            int actual = a.CountCols();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equel1()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            //act
            bool r = a == b;
            //assert
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void Equel2()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 2; a[0, 1] = 1; a[1, 0] = -8; a[1, 1] = 10;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 11; b[0, 1] = 1; b[1, 0] = 0; b[1, 1] = 32;
            //act
            bool r = a == b;
            //assert
            Assert.IsFalse(r);
        }

        [TestMethod]
        public void NotEquel()
        {
            //arrange
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 2; a[0, 1] = 1; a[1, 0] = -8; a[1, 1] = 10;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 11; b[0, 1] = 1; b[1, 0] = 0; b[1, 1] = 32;
            //act
            bool r = a != b;
            //assert
            Assert.IsTrue(r);
        }
    }
}
