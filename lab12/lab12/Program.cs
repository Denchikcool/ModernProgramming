using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=================Проверка кода на C#=================");
            Console.WriteLine("Запуск программы поиска минимального элемента в массиве и его индекса:\n");
            Calculate(2, 8, 8, 17, 23);
            Console.WriteLine("Запуск программы пузырьковой сортировки:\n");
            Calculate(1, 8, 7, 24, 25);
            Console.WriteLine("Запуск программы бинарного поиска:\n");
            Calculate(3, 12, 9, 21, 25);
            Console.WriteLine("Запуск программы поиска минимального элемента в двумерном массиве и его индекса:\n");
            Calculate(2, 10, 10, 29, 41);
            Console.WriteLine("Запуск программы переворачивания массива:\n");
            Calculate(1, 7, 6, 14, 19);
            Console.WriteLine("Запуск программы циклического сдвига:\n");
            Calculate(2, 11, 6, 14, 19);
            Console.WriteLine("Запуск программы замены элемента в массиве на новое:\n");
            Calculate(3, 6, 4, 6, 6);
        }

        //число единых по смыслу входных и выодных параметров, число отдельных операторов, число отдельных операндов
        //общее число вхождений всех операторов в реализацию, общее число вхождений всех операндов в реализацию
        private static void Calculate(double udot, double u1, double u2, double N1, double N2)
        {
            //число (Страуда) мысленных сравнений в единицу времени (5 < S < 20 в сек.)
            int S = 10;
            //объем реализации
            double V = (N1 + N2) * Math.Log((u1 + u2), 2);
            //потенциальный объем реализации
            double Vdot = (2 + udot) * Math.Log((2 + udot), 2);
            //уровень программы по реализации
            double Lgalka = (2 / u1) * (u2 / N2);

            Console.WriteLine($"Предсказанная длина реализации по соотношению Холстеда (N^) = {u1 * Math.Log(u1, 2) + u2 * Math.Log(u2, 2)}");
            Console.WriteLine($"Потенциальный объём реализации (V*) = {Vdot}");
            Console.WriteLine($"Объём реализации (V) = {V}");
            Console.WriteLine($"Уровень программы = {Vdot / V}");
            Console.WriteLine($"Уровень программы по реализации (L^) = {Lgalka}");
            Console.WriteLine($"Интеллектуальное содержание программы (I) = {(2 / u1) * (u2 / N2) * (N1 + N2) * Math.Log((u1 + u2), 2)}");
            Console.WriteLine($"Прогназируемое время написания программы (T1) = {(V * V / (S * Vdot))}");
            Console.WriteLine($"Прогназируемое время написания программы по Холстеду (T2) = {(u1 * N2 * (u1 * Math.Log(u1, 2) + u2 * Math.Log(u2, 2)) * Math.Log((u1 + u2), 2)) / (2 * S * u2)}");
            Console.WriteLine($"Прогназируемое время написания программы (T3) = {(u1 * N2 * (N1 + N2) * Math.Log((u1 + u2), 2)) / (2 * S * u2)}");
            Console.WriteLine($"Среднее значение уровня языков программирования lamda1 = {Lgalka * Lgalka * V}");
            Console.WriteLine($"Среднее значение уровня языков программирования lamda2 = {Vdot * Vdot / V}\n");
        }

        private static (int , int) FindMin(List<int> a)
        {
            if (a.Count == 0) return (int.MaxValue, -1);

            int minVal = a[0];
            int minIndex = 0;

            for(int i = 1; i < a.Count; i++)
            {
                if (a[i] < minVal)
                {
                    minVal = a[i];
                    minIndex = i;
                }
            }

            return (minVal, minIndex);
        }

        private static void BubbleSort(List<int> a)
        {
            for(int i = 0; i <  a.Count - 1; i++)
            {
                for(int j = a.Count - 1; j > i; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                }
            }
        }

        private static int BinarySearch(List<int> a, int target)
        {
            int left = 0, right = a.Count - 1;

            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (a[mid] == target) return mid;
                if (a[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        private static (int, int, int) FindMinMatrix(List<List<int>> a)
        {
            if (a.Count == 0 || a[0].Count == 0) return (int.MaxValue, -1, 1);

            int minVal = a[0][0], minRow = 0, minCol = 0;

            for(int i = 0; i < a.Count; i++)
            {
                for(int j = 0; j < a[i].Count; j++)
                {
                    if (a[i][j] < minVal)
                    {
                        minVal = a[i][j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }

            return (minVal, minRow, minCol);
        }

        private static void Reverse(List<int> a)
        {
            int left = 0, right = a.Count - 1;

            while(left < right)
            {
                int temp = a[left];
                a[left] = a[right];
                a[right] = temp;
                left++;
                right--;
            }
        }

        private static void CycleShift(List<int> a, int count)
        {
            count %= a.Count;
            if(count == 0) return;

            List<int> temp = new List<int>(a);
            for(int i = 0; i < a.Count; i++)
            {
                a[i] = temp[(i + count) % a.Count];
            }
        }

        private static void ReplaceValue(List<int> a, int oldValue, int newValue)
        {
            for(int i = 0; i < a.Count; i++)
            {
                if (a[i] == oldValue)
                {
                    a[i] = newValue;
                }
            }
        }
    }
}
