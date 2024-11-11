using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab9;

namespace PolynomTests
{
    [TestClass]
    public class PolynomTests
    {
        [TestMethod]
        public void TestAdd1()
        {
            TPoly tpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 0));

            string actual = "1x^0";

            Assert.AreEqual(tpoly.Show(), actual);
        }

        [TestMethod]
        public void TestAdd2()
        {
            TPoly tpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 1));

            string actual = "1x^1+1x^0";

            Assert.AreEqual(tpoly.Show(), actual);
        }

        [TestMethod]
        public void TestAdd3()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(2, 5));
            tpoly1.Members.Add(new TMember(5, 5));

            string actual = "7x^5";

            Assert.AreEqual(tpoly1.Show(), actual);
        }

        [TestMethod]
        public void TestMul1()
        {
            TPoly tpoly = new TPoly();
            TPoly newtpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 1));
            newtpoly.Members.Add(new TMember(1, 0));
            newtpoly.Members.Add(new TMember(1, 1));

            TPoly addpoly = tpoly.Add(newtpoly);
            addpoly = tpoly.Mul(newtpoly);

            string actual = "1x^2+2x^1+1x^0";

            Assert.AreEqual(addpoly.Show(), actual);
        }

        [TestMethod]
        public void TestMul2()
        {
            TPoly tpoly = new TPoly();
            TPoly newtpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 2));
            newtpoly.Members.Add(new TMember(2, 0));
            newtpoly.Members.Add(new TMember(1, 1));

            TPoly addpoly = tpoly.Add(newtpoly);
            addpoly = tpoly.Mul(newtpoly);

            string actual = "1x^3+2x^2+1x^1+2x^0";

            Assert.AreEqual(addpoly.Show(), actual);
        }

        [TestMethod]
        public void TestSub1()
        {
            TPoly tpoly1 = new TPoly();
            TPoly tpoly2 = new TPoly();
            tpoly1.Members.Add(new TMember(-21, 4));
            tpoly1.Members.Add(new TMember(6, 9));
            tpoly2.Members.Add(new TMember(8, 7));
            tpoly2.Members.Add(new TMember(-12, 43));

            TPoly subpoly = tpoly1.Sub(tpoly2);

            string actual = "12x^43+6x^9-8x^7-21x^4";

            Assert.AreEqual(subpoly.Show(), actual);
        }

        [TestMethod]
        public void TestSub2()
        {
            TPoly tpoly1 = new TPoly();
            TPoly tpoly2 = new TPoly();
            tpoly1.Members.Add(new TMember(-21, 4));
            tpoly1.Members.Add(new TMember(6, 4));
            tpoly2.Members.Add(new TMember(8, 4));
            tpoly2.Members.Add(new TMember(-12, 4));

            TPoly subpoly = tpoly1.Sub(tpoly2);

            string actual = "-11x^4";

            Assert.AreEqual(subpoly.Show(), actual);
        }

        [TestMethod]
        public void TestClear()
        {
            TPoly tpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Clear();

            string actual = "";

            Assert.AreEqual(tpoly.Show(), actual);
        }

        [TestMethod]
        public void TestCalc1()
        {
            TPoly tpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 2));
            tpoly.Members.Add(new TMember(3, 3));
            tpoly.Members.Add(new TMember(4, 2));

            double actual = 44;

            Assert.AreEqual(tpoly.Calculate(2), actual);
        }

        [TestMethod]
        public void TestCalc2()
        {
            TPoly tpoly = new TPoly();
            tpoly.Members.Add(new TMember(1, 2));
            tpoly.Members.Add(new TMember(3, 0));
            tpoly.Members.Add(new TMember(4, 0));

            double actual = 11;

            Assert.AreEqual(tpoly.Calculate(2), actual);
        }

        [TestMethod]
        public void TestEquals1()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(1, 2));

            TPoly tpoly2 = new TPoly();
            tpoly2.Members.Add(new TMember(1, 2));


            Assert.IsTrue(tpoly1.Equals(tpoly2));
        }

        [TestMethod]
        public void TestEquals2()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(1, 2));

            TPoly tpoly2 = new TPoly();
            tpoly2.Members.Add(new TMember(0, 2));


            Assert.IsFalse(tpoly1.Equals(tpoly2));
        }

        [TestMethod]
        public void TestDiff1()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(1, 3));

            string actual = "3x^2";

            Assert.AreEqual(tpoly1.Diff().Show(), actual);
        }

        [TestMethod]
        public void TestElementAt1()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 22));

            Assert.AreEqual(new System.Tuple<int, int>(11, 11), tpoly1.TakeElement(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestElementAt2()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(-21, 33));
            tpoly1.Members.Add(new TMember(6, -4));
            tpoly1.Members.Add(new TMember(10, 6));

            tpoly1.TakeElement(5);
        }

        [TestMethod]
        public void TestRetDegree()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 22));

            int actual = 22;

            Assert.AreEqual(tpoly1.ReturnDegree(), actual);
        }

        [TestMethod]
        public void TestRetCoeff1()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(3, 7));
            tpoly1.Members.Add(new TMember(-84, 15));

            int actual = -84;

            Assert.AreEqual(tpoly1.ReturnCoefficent(15), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRetCoeff2()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(-7, 32));
            tpoly1.Members.Add(new TMember(7, 6));
            tpoly1.Members.Add(new TMember(112, 2));

            tpoly1.ReturnCoefficent(33);
        }

        [TestMethod]
        public void TestMinus()
        {
            TPoly tpoly1 = new TPoly();
            tpoly1.Members.Add(new TMember(11, 1));
            tpoly1.Members.Add(new TMember(-22, 3));
            tpoly1.Members.Add(new TMember(20, 2));

            string actual = "22x^3-20x^2-11x^1";

            Assert.AreEqual(tpoly1.Minus().Show(), actual);
        }
    }
}
