using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryLab2;

namespace MyProjectLab2
{
    class Program
    {
        const int MAX = 10;
        const int MIN = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("==================Task 1==================\n");
            int[] numbers = { 27, -631, 228, };
            int max = MyClass.FindMax(numbers[0], numbers[1], numbers[2]);
            Console.WriteLine($"Максимальное число из набора ({numbers[0]}, {numbers[1]}, {numbers[2]}) = {max}\n");
            Console.WriteLine("==========================================\n");

            Random rnd = new Random();
            int rows = rnd.Next(2, 6);
            int cols = rnd.Next(2, 6);

            double[,] matrix_secondTask = new double[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    matrix_secondTask[i, j] = Math.Round(((rnd.NextDouble() * (MAX - MIN)) +  MIN), 2);
                }
            }

            Console.WriteLine("==================Task 2==================\n");
            Console.WriteLine("Матрица A: ");
            for(int i = 0; i < matrix_secondTask.GetLength(0); i++)
            {
                for(int j = 0; j < matrix_secondTask.GetLength(1); j++)
                {
                    Console.Write(matrix_secondTask[i, j] + " | ");
                }
                Console.WriteLine();
            }
            double product = MyClass.ProductOfElementsWithEvenSumOfIndices(matrix_secondTask);
            try
            {
                Console.WriteLine("Произведение элементов с четной суммой индексов: " + Math.Round(product, 2) + '\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Console.WriteLine("==========================================\n");

            int size = rnd.Next(2, 6);
            double[,] matrix_thirdTask = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix_thirdTask[i, j] = Math.Round(((rnd.NextDouble() * (MAX - MIN)) + MIN), 2);
                }
            }

            Console.WriteLine("==================Task 3==================\n");
            Console.WriteLine("Матрица A: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix_thirdTask[i, j] + " | ");
                }
                Console.WriteLine();
            }
            double min = MyClass.MinValueOnAndBelowDiagonal(matrix_thirdTask);
            try
            {
                Console.WriteLine("Минимальное значение на и ниже главной диагонали = " + min + '\n');
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            
            Console.WriteLine("==========================================\n");
        }
    }
}
