using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayOperations arrayOperations = new ArrayOperations();

            
            Console.WriteLine("====================First Task====================");
            int[] first = { 1, 2, 56 };
            int[] second = { 4, 5, 6 };
            int[] sumArray = ArrayOperations.SumArrays(first, second);
            Console.WriteLine("Первый массив: " + string.Join(", ", first));
            Console.WriteLine("Второй массив: " + string.Join(", ", second));
            Console.WriteLine("Сумма массивов: " + string.Join(", ", sumArray));
            Console.WriteLine("==================================================\n");

            
            Console.WriteLine("\n====================Second Task===================");
            double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0 };
            int shift = 1;
            Console.WriteLine("Исходный массив: " + string.Join(", ", array));
            ArrayOperations.CyclicShifLeft(array, shift);
            Console.WriteLine("Массив после сдвига: " + string.Join(", ", array));
            Console.WriteLine("==================================================\n");

            
            Console.WriteLine("\n====================Third Task====================");
            int[] vec = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] seq = { 6, 7, 8 };
            Console.WriteLine("Первый массив: " + string.Join(", ", vec));
            Console.WriteLine("Второй массив: " + string.Join(", ", seq));
            int index = ArrayOperations.FindSequenceStart(vec, seq);
            Console.WriteLine($"Индекс начала вхождения: {index}");
            Console.WriteLine("==================================================\n");
        }
    }
}
