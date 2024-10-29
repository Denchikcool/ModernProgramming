using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab6;

namespace lab6Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Init_And_Output_1()
        {
            TEditor testClass = new TEditor();
            string output = "10,3+(i*0,8)";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void Init_And_Output_2()
        {
            TEditor testClass = new TEditor();
            string output = "-12,6-(i*66,2)";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void Init_And_Output_3()
        {
            TEditor testClass = new TEditor();
            string output = "0,3+(i*0,0)";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void Init_And_Output_4()
        {
            TEditor testClass = new TEditor();
            string output = "0,+(i*0,)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void IsZero_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("12,36+(i*12,35)");
            Assert.IsFalse(testClass.IsZero());
        }
        [TestMethod]
        public void IsZero_2()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("0,+(i*0,)");
            Assert.IsTrue(testClass.IsZero());
        }
        [TestMethod]
        public void IsZero_3()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("0,+(i*12,54)");
            Assert.IsFalse(testClass.IsZero());
        }
        [TestMethod]
        public void IsZero_4()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("0,43+(i*0,)");
            Assert.IsFalse(testClass.IsZero());
        }
        [TestMethod]
        public void ToggleMinus_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("12,36+(i*12,35)");
            testClass.ToggleMinus();
            string output = "-12,36+(i*12,35)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void ToggleMinus_2()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("-12,36+(i*12,35)");
            testClass.ToggleMinus();
            string output = "12,36+(i*12,35)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void ToggleMinus_3()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("12,36+(i*12,35)");
            testClass.ToggleMode();
            testClass.ToggleMinus();
            string output = "12,36-(i*12,35)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void ToggleMinus_4()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("12,36-(i*12,35)");
            testClass.ToggleMode();
            testClass.ToggleMinus();
            string output = "12,36+(i*12,35)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddNumber_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("0,36+(i*1,4)");
            testClass.AddNumber(4);
            string output = "4,36+(i*1,4)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddNumber_2()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("-25,6-(i*44,44)");
            testClass.ToggleNumberMode();
            testClass.AddNumber(0);
            string output = "-25,60-(i*44,44)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddNumber_3()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("-25,6-(i*44,44)");
            testClass.ToggleMode();
            testClass.AddNumber(2);
            string output = "-25,6-(i*442,44)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddNumber_4()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("-25,6-(i*44,44)");
            testClass.ToggleMode();
            testClass.ToggleNumberMode();
            testClass.AddNumber(5);
            string output = "-25,6-(i*44,445)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void DelNumber_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("5,4+(i*44,44)");
            testClass.DelNumber();
            string output = "0,4+(i*44,44)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void DelNumber_2()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("55,55-(i*3,3)");
            testClass.ToggleNumberMode();
            testClass.DelNumber();
            string output = "55,5-(i*3,3)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void DelNumber_3()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("24,03-(i*3,3)");
            testClass.ToggleMode();
            testClass.DelNumber();
            string output = "24,03-(i*0,3)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void DelNumber_4()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("90,1+(i*5,97)");
            testClass.ToggleMode();
            testClass.ToggleNumberMode();
            testClass.DelNumber();
            string output = "90,1+(i*5,9)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void Clear_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("55,55-(i*3,3)");
            testClass.Clear();
            string output = "0,+(i*0,)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddZero_1()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("92,36+(i*1,4)");
            testClass.AddZero();
            string output = "920,36+(i*1,4)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddZero_2()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("0,02+(i*0,01)");
            testClass.ToggleNumberMode();
            testClass.AddZero();
            string output = "0,020+(i*0,01)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddZero_3()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("8,201+(i*6,9)");
            testClass.ToggleMode();
            testClass.AddZero();
            string output = "8,201+(i*60,9)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
        [TestMethod]
        public void AddZero_4()
        {
            TEditor testClass = new TEditor();
            testClass.WriteNumber("3,0+(i*32,901)");
            testClass.ToggleMode();
            testClass.ToggleNumberMode();
            testClass.AddZero();
            string output = "3,0+(i*32,9010)";
            Assert.AreEqual(output, testClass.ReadNumber());
        }
    }
}
