using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab7;
using lab6;

namespace MemoryTests
{
    [TestClass]
    public class MemoryTests
    {
        [TestMethod]
        public void WriteMemory_int()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(3);
            int actual = 3;

            Assert.AreEqual(actual, num1.ReadNumber());
        }

        [TestMethod]
        public void WriteMemory_float()
        {
            TMemory<float> num1 = new TMemory<float>();
            num1.WriteMemory(0.08f);
            float actual = 0.08f;

            Assert.AreEqual(actual, num1.ReadNumber());
        }

        [TestMethod]
        public void WriteMemory_NegativeDouble()
        {
            TMemory<double> num1 = new TMemory<double>();
            num1.WriteMemory(-7.92);
            double actual = -7.92;

            Assert.AreEqual(actual, num1.ReadNumber());
        }

        [TestMethod]
        public void WriteMemory_char()
        {
            TMemory<char> num1 = new TMemory<char>();
            num1.WriteMemory('b');
            char actual = 'b';

            Assert.AreEqual(actual, num1.ReadNumber());
        }

        [TestMethod]
        public void WriteMemory_complexNumber()
        {
            TEditor complexNumber = new TEditor();
            complexNumber.WriteNumber("-0,3+(i*5,09)");
            TMemory<string> complexNumberMemory = new TMemory<string>("-0,3+(i*5,09)");

            Assert.AreEqual(complexNumber.ReadNumber(), complexNumberMemory.ReadNumber());
        }

        [TestMethod]
        public void GetAndReadState_int()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(5);
            int temp = num1.Get();

            Assert.AreEqual(temp, num1.ReadNumber());
            Assert.IsFalse(num1.ReadState());
        }

        [TestMethod]
        public void GetAndReadState_float()
        {
            TMemory<float> num1 = new TMemory<float>();
            num1.WriteMemory(82.125f);
            float temp = num1.Get();

            Assert.AreEqual(temp, num1.ReadNumber());
            Assert.IsFalse(num1.ReadState());
        }

        [TestMethod]
        public void GetAndReadState_double()
        {
            TMemory<double> num1 = new TMemory<double>();
            num1.WriteMemory(44.32);
            double temp = num1.Get();

            Assert.AreEqual(temp, num1.ReadNumber());
            Assert.IsFalse(num1.ReadState());
        }

        [TestMethod]
        public void GetAndReadState_char()
        {
            TMemory<char> num1 = new TMemory<char>();
            num1.WriteMemory('s');
            char temp = num1.Get();

            Assert.AreEqual(temp, num1.ReadNumber());
            Assert.IsFalse(num1.ReadState());
        }

        [TestMethod]
        public void GetAndReadState_complexNumber()
        {
            TEditor complexNumber = new TEditor();
            complexNumber.WriteNumber("82,3-(i*0,29)");
            TMemory<TEditor> complexNumberMemory = new TMemory<TEditor>(complexNumber);
            complexNumberMemory.WriteMemory(complexNumber);
            TEditor actual = complexNumberMemory.ReadNumber();

            Assert.AreEqual(complexNumberMemory.Get(), actual);
            Assert.IsFalse(complexNumberMemory.ReadState());
        }

        [TestMethod]
        public void Add_int()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(10);
            num1.Add(5);

            int actual = 15;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Add_float()
        {
            TMemory<float> num1 = new TMemory<float>();
            num1.WriteMemory(21.6652f);
            num1.Add(1.92f);

            float actual = 23.5852f;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Add_double()
        {
            TMemory<double> num1 = new TMemory<double>();
            num1.WriteMemory(-38.81);
            num1.Add(-72.9015);

            double actual = -111.7115;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Add_complexNumber()
        {
            TEditor complexNumber = new TEditor();
            complexNumber.WriteNumber("-102,3-(i*87,011)");
            TMemory<string> complexNumberMemory = new TMemory<string>("32,30+(i*5,21)");

            complexNumberMemory.Add(complexNumber.ReadNumber());

            string actual = "32,30+(i*5,21)-102,3-(i*87,011)";

            Assert.AreEqual(complexNumberMemory.ReadNumber(), actual);
        }

        [TestMethod]
        public void CheckState_true()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(2);

            Assert.IsTrue(num1.ReadState());
        }

        [TestMethod]
        public void ReadState_false()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(-22);
            int number = num1.Get();

            Assert.IsFalse(num1.ReadState());
        }

        [TestMethod]
        public void Clear_int()
        {
            TMemory<int> num1 = new TMemory<int>();
            num1.WriteMemory(90);
            num1.Clear();

            int actual = 0;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Clear_float()
        {
            TMemory<float> num1 = new TMemory<float>();
            num1.WriteMemory(51.92f);
            num1.Clear();

            float actual = 0.0f;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Clear_double()
        {
            TMemory<double> num1 = new TMemory<double>();
            num1.WriteMemory(-0.67);
            num1.Clear();

            double actual = 0.0;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Clear_char()
        {
            TMemory<char> num1 = new TMemory<char>();
            num1.WriteMemory('c');
            num1.Clear();

            char actual = '\0';

            Assert.AreEqual(num1.ReadNumber(), actual);
        }

        [TestMethod]
        public void Clear_complexNumber()
        {
            TEditor editor = new TEditor();
            editor.WriteNumber("0.93+(i*0,)");

            TMemory<string> num1 = new TMemory<string>();
            num1.WriteMemory(editor.ReadNumber());
            num1.Clear();

            string actual = null;

            Assert.AreEqual(num1.ReadNumber(), actual);
        }
    }
}
