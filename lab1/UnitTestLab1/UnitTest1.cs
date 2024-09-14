using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab1;

namespace UnitTestLab1
{
    [TestClass]
    public class ArrayOperationsTests
    {
        [TestMethod]
        public void SumArraysTest()
        {
            int[] first = { 1, 2 };
            int[] second = { 3, 4 };
            int[] expected = { 4, 6 };

            int[] actual = ArrayOperations.SumArrays(first, second);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayOperations.invalid_argumanet_2))]
        public void SumArraysTest_invalid_argumanet()
        {
            int[] first = { 1 };
            int[] second = { 3, 4 };

            ArrayOperations.SumArrays(first, second);

        }

        [TestMethod]
        public void CyclicShifLeftTest()
        {
            double[] actual = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int shift = 4;
            double[] expected = { 5.0, 1.0, 2.0, 3.0, 4.0 };

            ArrayOperations.CyclicShifLeft(actual, shift);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayOperations.invalid_argumanet_2))]
        public void CyclicShifLeft_invalid_argumanet()
        {
            double[] actual = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int shift = -2;

            ArrayOperations.CyclicShifLeft(actual, shift);
        }

        [TestMethod]
        public void FindSequenceStartTest1()
        {
            int[] vec = { 4, 67, 32, 5, 997, 52, 0, -53, 63, 841, 11, 8 };
            int[] seq = { 0, -53 };
            int expected = 6;
            int actual = ArrayOperations.FindSequenceStart(vec, seq);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindSequenceStartTest2()
        {
            int[] vec = { 4, 67, 32, 5, 997, 52, 0, -53, 63, 841, 11, 8 };
            int[] seq = { 999, -53 };
            int expected = -1;
            int actual = ArrayOperations.FindSequenceStart(vec, seq);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayOperations.invalid_argumanet_2))]
        public void FindSequenceStart_invalid_argumanet()
        {
            int[] vec = { 999, -53 };
            int[] seq = { 4, 67, 32, 5, 997, 52, 0, -53, 63, 841, 11, 8 };

            ArrayOperations.FindSequenceStart(vec, seq);
        }
    }
}
