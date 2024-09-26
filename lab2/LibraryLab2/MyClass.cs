using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab2
{
    public class MyClass
    {
        static string s1 = "Матрица должна быть квадратной!";
        static string s2 = "Матрица не может быть null!";
        static string s3 = "Матрица не может быть пустой!";
        public class invalid_exception_1 : ArgumentException
        {
            public invalid_exception_1(string message) : base(message) { }
        }

        public class invalid_exception_2 : ArgumentException
        {
            public invalid_exception_2(string message) : base(message) { }
        }

        public class invalid_exception_3 : ArgumentException
        {
            public invalid_exception_3(string message) : base(message) { }
        }

        public static int FindMax(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0) return 0;
            if (a == b && b == c) return a;

            int max = a;
            
            if(b > max)
            {
                max = b;
            }
            if(c > max)
            {
                max = c;
            }
            return max;
        }

        public static double ProductOfElementsWithEvenSumOfIndices(double[,] A)
        {
            if(A == null) throw new invalid_exception_2(s2);

            if (A.GetLength(0) == 0 || A.GetLength(1) == 0) throw new invalid_exception_3(s3);

            if (A.GetLength(0) == 1 && A.GetLength(1) == 1) return A[0, 0];

            double product = 1.0;

            for(int i = 0; i < A.GetLength(0); i++) 
            {
                for(int j = 0; j <  A.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        product *= A[i, j];
                    }
                }
            }
            return product;
        }

        public static double MinValueOnAndBelowDiagonal(double[,] A)
        {
            if (A == null) throw new invalid_exception_2(s2);

            if (A.GetLength(0) == 0 || A.GetLength(1) == 0) throw new invalid_exception_3(s3);

            if (A.GetLength(0) != A.GetLength(1)) throw new invalid_exception_1(s1);


            double min = double.MaxValue;

            for(int i = 0; i < A.GetLength(0); i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    if (A[i, j] < min)
                    {
                        min = A[i, j];
                    }
                }
            }
            return min;
        }
        
    }
}
