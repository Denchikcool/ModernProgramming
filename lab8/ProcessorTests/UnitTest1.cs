using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab8;

namespace ProcessorTests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            TProc<int> proc = new TProc<int>();

            Assert.AreEqual(EOperation.None, proc.Operation);
            Assert.AreEqual(EFunction.None, proc.Function);
            Assert.AreEqual(0, proc.Lop_Res);
            Assert.AreEqual(0, proc.Rop);
        }

        [TestMethod]
        public void ConstructorWithValues_int()
        {
            TProc<int> proc = new TProc<int>(5, 10);

            Assert.AreEqual(EOperation.None, proc.Operation);
            Assert.AreEqual(EFunction.None, proc.Function);
            Assert.AreEqual(proc.RetTLop_Res(), proc.Lop_Res);
            Assert.AreEqual(proc.RetTRop(), proc.Rop);
        }

        [TestMethod]
        public void ConstructorWithValues_float()
        {
            TProc<float> proc = new TProc<float>(-4.73f, 0.43f);

            Assert.AreEqual(EOperation.None, proc.Operation);
            Assert.AreEqual(EFunction.None, proc.Function);
            Assert.AreEqual(proc.RetTLop_Res(), proc.Lop_Res);
            Assert.AreEqual(proc.RetTRop(), proc.Rop);
        }

        [TestMethod]
        public void ConstructorWithValues_double()
        {
            TProc<double> proc = new TProc<double>(0.0005, -94.9263);

            Assert.AreEqual(EOperation.None, proc.Operation);
            Assert.AreEqual(EFunction.None, proc.Function);
            Assert.AreEqual(proc.RetTLop_Res(), proc.Lop_Res);
            Assert.AreEqual(proc.RetTRop(), proc.Rop);
        }

        [TestMethod]
        public void OperationClear_ResetsOperation_Int()
        {
            TProc<int> proc = new TProc<int>();
            proc.OperationSet(2);
            proc.OperationClear();

            Assert.AreEqual(EOperation.None, proc.OperationGet());
        }

        [TestMethod]
        public void OperationRun_Add_Int()
        {
            TProc<int> proc = new TProc<int>(5, 3);
            proc.OperationSet(1);
            proc.OperationRun();

            int actual = 8;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Add_Float()
        {
            TProc<float> proc = new TProc<float>(5.72f, 3.20f);
            proc.OperationSet(1);
            proc.OperationRun();

            float actual = 8.92f;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Add_Double()
        {
            TProc<double> proc = new TProc<double>(8.32, -6.99);
            proc.OperationSet(1);
            proc.OperationRun();

            double actual = 1.33;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Sub_Int()
        {
            TProc<int> proc = new TProc<int>(5, 3);
            proc.OperationSet(2);
            proc.OperationRun();

            int actual = 2;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Sub_Float()
        {
            TProc<float> proc = new TProc<float>(9.11f, -7.091f);
            proc.OperationSet(2);
            proc.OperationRun();

            float actual = 16.201f;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Sub_Double()
        {
            TProc<double> proc = new TProc<double>(-24.85, 22.15);
            proc.OperationSet(2);
            proc.OperationRun();

            double actual = -47;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Mul_Int()
        {
            TProc<int> proc = new TProc<int>(62, 4);
            proc.OperationSet(3);
            proc.OperationRun();

            int actual = 248;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Mul_Float()
        {
            TProc<float> proc = new TProc<float>(0.1f, -62.23f);
            proc.OperationSet(3);
            proc.OperationRun();

            float actual = -6.223f;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Mul_Double()
        {
            TProc<double> proc = new TProc<double>(0.001, 723.6813);
            proc.OperationSet(3);
            proc.OperationRun();

            double actual = 0.7236813;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Div_Int()
        {
            TProc<int> proc = new TProc<int>(10, 2);
            proc.OperationSet(4);
            proc.OperationRun();

            int actual = 5;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Div_Float()
        {
            TProc<float> proc = new TProc<float>(73.5f, 4.25f);
            proc.OperationSet(4);
            proc.OperationRun();

            float actual = 17.2941176f;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void OperationRun_Div_Double()
        {
            TProc<double> proc = new TProc<double>(-14.5, 2.5);
            proc.OperationSet(4);
            proc.OperationRun();

            double actual = -5.8;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void OperationRun_Div_ByZero_Int()
        {
            TProc<int> proc = new TProc<int>(10, 0);
            proc.OperationSet(4);
            proc.OperationRun();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void OperationRun_Div_ByZero_Float()
        {
            TProc<float> proc = new TProc<float>(-72.01f, 0.0f);
            proc.OperationSet(4);
            proc.OperationRun();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void OperationRun_Div_ByZero_Double()
        {
            TProc<double> proc = new TProc<double>(0.001, 0);
            proc.OperationSet(4);
            proc.OperationRun();
        }

        [TestMethod]
        public void OperationSet_ValidOperation()
        {
            TProc<int> proc = new TProc<int>();
            proc.OperationSet(1);

            Assert.AreEqual(proc.OperationGet(), EOperation.Add);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperationSet_InvalidOperation_ThrowsException()
        {
            TProc<int> proc = new TProc<int>();
            proc.OperationSet(10);
        }

        [TestMethod]
        public void OperationGet_ReturnsCorrectOperation()
        {
            TProc<int> proc = new TProc<int>();
            proc.OperationSet(2);

            Assert.AreEqual(EOperation.Sub, proc.OperationGet());
        }

        [TestMethod]
        public void FunctionClear_ResetsFunction()
        {
            TProc<int> proc = new TProc<int>();
            proc.FunctionSet(1);
            proc.FunctionClear();

            Assert.AreEqual(proc.GetFunction(), EFunction.None);
        }

        [TestMethod]
        public void FunctionRun_Rev_Int_Valid()
        {
            TProc<int> proc = new TProc<int>(5, 2);
            proc.FunctionSet(1);
            proc.FunctionRun();

            string actual = "0";

            Assert.AreEqual(proc.RetRop(), actual);
        }

        [TestMethod]
        public void FunctionRun_Rev_Float_Valid()
        {
            TProc<float> proc = new TProc<float>();
            proc.Rop_Set(-2.5f);
            proc.FunctionSet(1);
            proc.FunctionRun();

            float actual = -0.4f;

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        [TestMethod]
        public void FunctionRun_Rev_Double_Valid()
        {
            TProc<double> proc = new TProc<double>();
            proc.Rop_Set(100.0);
            proc.FunctionSet(1);
            proc.FunctionRun();

            double actual = 0.01;

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void FunctionRun_Rev_Int_Zero_ThrowsException()
        {
            TProc<int> proc = new TProc<int>(5, 0);
            proc.FunctionSet(1);
            proc.FunctionRun();
        }

        [TestMethod]
        public void FunctionSet_ValidFunction()
        {
            TProc<int> proc = new TProc<int>();
            proc.FunctionSet(0);

            Assert.AreEqual(proc.GetFunction(), EFunction.None);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FunctionSet_InvalidFunction()
        {
            TProc<int> proc = new TProc<int>();
            proc.FunctionSet(3);
        }

        [TestMethod]
        public void GetFunction_ReturnsCorrectFunction()
        {
            TProc<int> proc = new TProc<int>();
            proc.FunctionSet(2);

            Assert.AreEqual(EFunction.Sqr, proc.GetFunction());
        }

        [TestMethod]
        public void Lop_Res_Set_SetsCorrectValue_Int()
        {
            TProc<int> proc = new TProc<int>();
            int newValue = 10;
            proc.Lop_Res_Set(newValue);

            int actual = 10;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void Lop_Res_Set_SetsCorrectValue_Float()
        {
            TProc<float> proc = new TProc<float>();
            float newValue = -9.05f;
            proc.Lop_Res_Set(newValue);

            float actual = -9.05f;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void Lop_Res_Set_SetsCorrectValue_Double()
        {
            TProc<double> proc = new TProc<double>();
            double newValue = 15.82;
            proc.Lop_Res_Set(newValue);

            double actual = 15.82;

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        [TestMethod]
        public void Lop_Res_Set_SetsCorrectValue_Char()
        {
            TProc<char> proc = new TProc<char>();
            char newValue = 'a';
            proc.Lop_Res_Set(newValue);

            char actual = 'a';

            Assert.AreEqual(proc.RetTLop_Res(), actual);
        }

        /*[TestMethod]
        public void Lop_Res_Set_SetsCorrectValue_String()
        {
            TProc<string> proc = new TProc<string>();
            string newValue = "hello";
            proc.Lop_Res_Set(newValue);

            string actual = "hello";

            Assert.AreEqual(proc.RetLop_Res(), actual);
        }*/

        [TestMethod]
        public void Rop_Set_SetsCorrectValue_Int()
        {
            TProc<int> proc = new TProc<int>();
            int newValue = 5;
            proc.Rop_Set(newValue);

            int actual = 5;

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        [TestMethod]
        public void Rop_Set_SetsCorrectValue_Float()
        {
            TProc<float> proc = new TProc<float>();
            float newValue = -11.5f;
            proc.Rop_Set(newValue);

            float actual = -11.5f;

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        [TestMethod]
        public void Rop_Set_SetsCorrectValue_Double()
        {
            TProc<double> proc = new TProc<double>();
            double newValue = 0.0234;
            proc.Rop_Set(newValue);

            double actual = 0.0234;

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        [TestMethod]
        public void Rop_Set_SetsCorrectValue_Char()
        {
            TProc<char> proc = new TProc<char>();
            char newValue = 'm';
            proc.Rop_Set(newValue);

            char actual = 'm';

            Assert.AreEqual(proc.RetTRop(), actual);
        }

        /*[TestMethod]
        public void Rop_Set_SetsCorrectValue_String()
        {
            TProc<string> proc = new TProc<string>();
            string newValue = "byebye";
            proc.Rop_Set(newValue);

            string actual = "byebye";

            Assert.AreEqual(proc.RetTRop(), actual);
        }*/

        [TestMethod]
        public void ReSetByDefault_Int()
        {
            TProc<int> proc = new TProc<int>(4, 10);
            proc.ReSet();
            int actaul = 0;

            Assert.AreEqual(proc.RetTLop_Res(), actaul);
            Assert.AreEqual(proc.RetTRop(), actaul);
        }

        [TestMethod]
        public void ReSetByDefault_Float()
        {
            TProc<float> proc = new TProc<float>(-25.5f, 4.7f);
            proc.ReSet();
            float actaul = 0.0f;

            Assert.AreEqual(proc.RetTLop_Res(), actaul);
            Assert.AreEqual(proc.RetTRop(), actaul);
        }

        [TestMethod]
        public void ReSetByDefault_Double()
        {
            TProc<double> proc = new TProc<double>(55.67, -23.974);
            proc.ReSet();
            double actaul = 0.0;

            Assert.AreEqual(proc.RetTLop_Res(), actaul);
            Assert.AreEqual(proc.RetTRop(), actaul);
        }

        [TestMethod]
        public void ReSetByDefault_Char()
        {
            TProc<char> proc = new TProc<char>('a', 'b');
            proc.ReSet();
            char actaul = '\0';

            Assert.AreEqual(proc.RetTLop_Res(), actaul);
            Assert.AreEqual(proc.RetTRop(), actaul);
        }

        /*[TestMethod]
        public void ReSetByDefault_String()
        {
            TProc<string> proc = new TProc<string>("hello", "byebye");
            proc.ReSet();
            string actaul = null;

            Assert.AreEqual(proc.RetLop_Res(), actaul);
            Assert.AreEqual(proc.RetRop(), actaul);
        }*/
    }
}
