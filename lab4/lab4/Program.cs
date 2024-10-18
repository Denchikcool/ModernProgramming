using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            try
            {
                Matrix a = new Matrix(3, 3);
                Matrix b = new Matrix(3, 3);
                Matrix square = new Matrix(5, 5);
                Matrix d = new Matrix(7, 10);
                Matrix c;

                for (int i = 0; i < a.I; i++)
                {
                    for (int j = 0; j < a.J; j++)
                    {
                        a[i, j] = rnd.Next(10, 20);
                    }
                }

                Console.WriteLine("Матрица A: \n");
                a.Show();

                for (int i = 0; i < b.I; i++)
                {
                    for (int j = 0; j < b.J; j++)
                    {
                        b[i, j] = rnd.Next(10, 20);
                    }
                }

                Console.WriteLine("\nМатрица B: \n");
                b.Show();

                for (int i = 0; i < square.I; i++)
                {
                    for (int j = 0; j < square.J; j++)
                    {
                        square[i, j] = rnd.Next(10, 20);
                    }
                }

                Console.WriteLine("\nМатрица Square: \n");
                square.Show();

                for (int i = 0; i < d.I; i++)
                {
                    for (int j = 0; j < d.J; j++)
                    {
                        d[i, j] = rnd.Next(10, 20);
                    }
                }

                Console.WriteLine("\nМатрица D: \n");
                d.Show();

                c = a + b;
                Console.WriteLine("\nМатрица C (сложение матриц A и B): \n");
                c.Show();

                c = a - b;
                Console.WriteLine("\nМатрица C (вычитание матриц A и B): \n");
                c.Show();

                c = a * b;
                Console.WriteLine("\nМатрица C (умножение матриц A и B): \n");
                c.Show();

                Console.WriteLine();
                Console.WriteLine("Матрица Square транспонированная: \n");
                square.Transp();
                square.Show();

                int min = d.Min();
                Console.WriteLine($"\nМинимальный элемент в матрице d = {min}\n");

                string str = d.ToString();
                Console.WriteLine($"Строковое представление матрицы d:\n{str}\n");

                int[] indexes = { 3, 5 };
                int element = d.TakeElement(indexes[0], indexes[1]);
                Console.WriteLine($"Элемент с индексами [{indexes[0]}, {indexes[1]}] = {element}\n");

                int rows = d.CountRows();
                Console.WriteLine($"Количество строк в матрице d = {rows}\n");

                int cols = d.CountCols();
                Console.WriteLine($"Количество столбцов в матрице d = {cols}\n");
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
