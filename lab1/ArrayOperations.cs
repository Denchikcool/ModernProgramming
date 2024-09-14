using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class ArrayOperations
    {
        public class invalid_argumanet_2: ArgumentException
        {
            public invalid_argumanet_2(string message) : base(message) { }
        }
        public static int[] SumArrays(int[] a, int[] b)
        {
            if (a.Length != b.Length) throw new invalid_argumanet_2("Массивы должны быть одинаковой длины!");

            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }

            return result;
        }

        public static void CyclicShifLeft(double[] a, int shift)
        {
            int n = a.Length;
            shift = shift % n;
            if (shift < 0) throw new invalid_argumanet_2("Сдвиг не может быть отрицательным!");
            if (shift > 0)
            {
                for (int i = 0; i < shift; i++)
                {
                    double temp = a[0];
                    for (int j = 0; j < n - 1; j++)
                    {
                        a[j] = a[j + 1];
                    }
                    a[n - 1] = temp;
                }
            }
        }

        public static int FindSequenceStart(int[] vec, int[] seq)
        {
            if (seq.Length > vec.Length) throw new invalid_argumanet_2("Подстрока не может быть больше, чем исходная строка!");

            for (int i = 0; i <= vec.Length - seq.Length; i++)
            {
                bool correct = true;
                for (int j = 0; j < seq.Length; j++)
                {
                    if (vec[i + j] != seq[j])
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
