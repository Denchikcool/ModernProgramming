using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab10;

namespace SetTest
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void TestElementAt1()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(1);
            set1.Add(2);
            set1.Add(4);
            Assert.AreEqual(set1.ElementAt(0), 1);
            Assert.AreEqual(set1.ElementAt(1), 2);
            Assert.AreEqual(set1.ElementAt(2), 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestElementAt2()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(1);
            set1.Add(2);
            set1.Add(4);
            Assert.AreEqual(set1.ElementAt(0), 1);
            Assert.AreEqual(set1.ElementAt(1), 2);
            Assert.AreEqual(set1.ElementAt(5), 4);
        }

        [TestMethod]
        public void TestClear()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(2);
            set1.Add(3);
            set1.Add(4);

            string actual = "{ 2 3 4 }";

            Assert.AreEqual(set1.Show(), actual);

            set1.Clear();
            actual = "{ }";
            Assert.AreEqual(set1.Show(), actual);
        }

        [TestMethod]
        public void TestRemove()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(-11);
            set1.Add(8);
            set1.Add(62);
            set1.Remove(8);

            string actual = "{ -11 62 }";

            Assert.AreEqual(set1.Show(), actual);
        }

        [TestMethod]
        public void TestIsClear()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(22);
            set1.Add(0);
            set1.Add(4);

            Assert.IsFalse(set1.IsClear());
        }

        [TestMethod]
        public void TestIsClear2()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(91);
            set1.Add(-621);
            set1.Add(82);
            set1.Clear();

            Assert.IsTrue(set1.IsClear());
        }

        [TestMethod]
        public void TestContains()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(9);
            set1.Add(1);
            set1.Add(36);

            Assert.IsTrue(set1.Contains(36));
        }

        [TestMethod]
        public void TestContains2()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(-5);
            set1.Add(5);
            set1.Add(-873);

            Assert.IsFalse(set1.Contains(-874));
        }

        [TestMethod]
        public void TestUnion()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(4);
            set1.Add(-9);
            set1.Add(77);

            TSet<int> set2 = new TSet<int>();
            set2.Add(6);
            set2.Add(-9);
            set2.Add(4);

            string actual = "{ 4 -9 77 6 }";

            Assert.AreEqual(set1.Union(set2).Show(), actual);
        }

        [TestMethod]
        public void TestUnionWithEmptySet()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(4);
            set1.Add(-9);
            set1.Add(77);

            TSet<int> set2 = new TSet<int>();

            string actual = "{ 4 -9 77 }";

            Assert.AreEqual(set1.Union(set2).Show(), actual);
        }

        [TestMethod]
        public void TestExcept()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(83);
            set1.Add(3);
            set1.Add(2);

            TSet<int> set2 = new TSet<int>();
            set2.Add(3);
            set2.Add(97);
            set2.Add(2);

            string actual = "{ 83 }";

            Assert.AreEqual(set1.Except(set2).Show(), actual);
        }

        [TestMethod]
        public void TestExceptWithAllSameElements()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(97);
            set1.Add(3);
            set1.Add(2);

            TSet<int> set2 = new TSet<int>();
            set2.Add(3);
            set2.Add(97);
            set2.Add(2);

            string actual = "{ }";

            Assert.AreEqual(set1.Except(set2).Show(), actual);
        }

        [TestMethod]
        public void TestIntersect()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(9);
            set1.Add(0);
            set1.Add(-53);

            TSet<int> set2 = new TSet<int>();
            set2.Add(0);
            set2.Add(8);
            set2.Add(72);

            string actual = "{ 0 }";

            Assert.AreEqual(set1.Intersect(set2).Show(), actual);
        }

        [TestMethod]
        public void TestIntersectNoSameElements()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(9);
            set1.Add(0);
            set1.Add(-53);

            TSet<int> set2 = new TSet<int>();
            set2.Add(2);
            set2.Add(8);
            set2.Add(72);

            string actual = "{ }";

            Assert.AreEqual(set1.Intersect(set2).Show(), actual);
        }

        [TestMethod]
        public void TestCount()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(10);
            set1.Add(2);
            set1.Add(-4);

            int actual = 3;

            Assert.AreEqual(set1.Count(), actual);
        }

        [TestMethod]
        public void TestCountWithSameElements()
        {
            TSet<int> set1 = new TSet<int>();
            set1.Add(10);
            set1.Add(2);
            set1.Add(2);

            int actual = 2;

            Assert.AreEqual(set1.Count(), actual);
        }

        [TestMethod]
        public void Equals()
        {
            TSet<int> set1 = new TSet<int>();
            TSet<int> set2 = new TSet<int>();

            set1.Add(10);
            set1.Add(2);
            set1.Add(-7);
            set2.Add(-7);
            set2.Add(10);
            set2.Add(2);

            Assert.IsTrue(set1.Equals(set2));
        }

        [TestMethod]
        public void NotEqualsDifferentCount()
        {
            TSet<int> set1 = new TSet<int>();
            TSet<int> set2 = new TSet<int>();

            set1.Add(10);
            set1.Add(-7);
            set2.Add(-7);
            set2.Add(10);
            set2.Add(2);

            Assert.IsFalse(set1.Equals(set2));
        }

        [TestMethod]
        public void NotEqualsDifferentElements()
        {
            TSet<int> set1 = new TSet<int>();
            TSet<int> set2 = new TSet<int>();

            set1.Add(10);
            set1.Add(-7);
            set1.Add(3);
            set2.Add(-7);
            set2.Add(10);
            set2.Add(2);

            Assert.IsFalse(set1.Equals(set2));
        }

        [TestMethod]
        public void Copy()
        {
            TSet<int> set1 = new TSet<int>();
            TSet<int> set2 = new TSet<int>();

            set1.Add(4);
            set1.Add(0);
            set1.Add(-64);
            set1.Add(72);

            set2 = set1.Copy();

            Assert.IsTrue(set1.Equals(set2));
        }
    }
}
