using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class MyException : Exception
    {
        public MyException(string s) : base(s) { }
    }
    public class Matrix
    {
        int[,] m;
        public int I {  get; }
        public int J {  get; }

        public Matrix(int i, int j) 
        {
            if (i <= 0) throw new MyException($"Недопустимое значение строки = {i}");
            if(j <= 0) throw new MyException($"Недопустимое значение столбца = {j}");

            I = i; 
            J = j;

            m = new int[i, j];
        }

        public Matrix(int i, int j, int[,] data)
        {
            if (i <= 0 || j <= 0)
                throw new MyException("Неверная размерность матрицы!");
            if (data.GetLength(0) == 0 || data.GetLength(1) == 0) 
                throw new MyException("В матрице должны быть инициализированы оба измерения!");
            if (i != data.GetLength(0) || j != data.GetLength(1))
                throw new MyException("Матрицы должны быть схожи!");
            I = i;
            J = j;

            m = new int[i, j];
            m = data;
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > I - 1) throw new MyException($"Неверное значение i = {i}");
                if (j < 0 | j > J - 1) throw new MyException($"неверное значение j = {j}");

                return m[i, j];
            }

            set
            { 
                if (i < 0 | i > I - 1) throw new MyException($"Неверное значение i = {i}");
                if (j < 0 | j > J - 1) throw new MyException($"неверное значение j = {j}");

                m[i, j] = value;
            }
        }

        public static Matrix operator+(Matrix a, Matrix b)
        {
            if (a.m.GetLength(0) != b.m.GetLength(0) || a.m.GetLength(1) != b.m.GetLength(1)) 
                throw new MyException("Матрицы должны быть одинакового размера!");

            Matrix c = new Matrix(a.I, a.J);

            for(int i = 0; i < a.I; i++)
            {
                for(int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] + b.m[i, j];
                }
            }

            return c;
        }

        public static Matrix operator-(Matrix a, Matrix b)
        {
            if (a.m.GetLength(0) != b.m.GetLength(0) || a.m.GetLength(1) != b.m.GetLength(1)) 
                throw new MyException("Матрицы должны быть одинакового размера!");

            Matrix c = new Matrix(a.I, a.J);

            for(int i = 0; i < a.I; i++)
            {
                for(int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] - b.m[i, j];
                }
            }

            return c;
        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            if (a.m.GetLength(1) != b.m.GetLength(0)) 
                throw new MyException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");

            Matrix c = new Matrix(a.I, b.J);

            for(int i = 0; i < a.I; i++)
            {
                for(int j = 0; j < b.J; j++)
                {
                    c[i, j] = 0;
                    for(int k = 0; k < a.J; k++)
                    {
                        c[i, j] += a.m[i, k] * b.m[k, j];
                    }
                }
            }

            return c;
        }

        public void Transp()
        {
            if (I != J)
                throw new MyException("Для транспонирования матрица должна быть квадратной!");

            int[,] temp = new int[J, I];

            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    temp[j, i] = this[i, j];
                }
            }

            for (int i = 0; i < I; i++)
            {
                for(int j = 0; j < J; j++)
                {
                    this[i, j] = temp[i, j]; 
                }
            }
        }

        public int Min()
        {
            int min = this[0, 0];

            for(int i = 0; i < I; i++)
            {
                for(int j = 0; j < J; j++)
                {
                    if (this[i, j] < min)
                    {
                        min = this[i, j];
                    }
                }
            }
            return min;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");
            for (int i = 0; i < I; i++)
            {
                stringBuilder.Append("{");
                for (int j = 0; j < J; j++)
                {
                    stringBuilder.Append(this[i, j]);
                    if (j < J - 1)
                        stringBuilder.Append(", ");
                }
                stringBuilder.Append("}");
                if(i < I - 1)
                    stringBuilder.Append(", ");
            }
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public int TakeElement(int row, int col)
        {
            if (row < 0 | row > I - 1)
                throw new MyException("i должна находиться в диапазонах размерности матрицы!");
            if (col < 0 | col > J - 1)
                throw new MyException("j должна находиться в диапазонах размерности матрицы!");

            int result = 0;

            for (int i = 0; i < I; i++) 
            {
                for (int j = 0; j < J; j++)
                {
                    if(i == row && j == col)
                        result = this[i, j];
                }
            }

            return result;
        }

        public int CountRows()
        {
            int count = m.GetLength(0);
            return count;
        }

        public int CountCols()
        {
            int count = m.GetLength(1);
            return count;
        }

        public static bool operator==(Matrix a, Matrix b)
        {

            for(int i = 0; i < a.I; i++)
            {
                for(int j = 0; j < a.J; j++)
                {
                    if (a[i,j] != b[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator!=(Matrix a, Matrix b)
        {
            return !(a==b);
        }

        public void Show()
        {
            for(int i = 0; i < I; i++)
            {
                for(int j = 0; j < J; j++)
                {
                    Console.Write("\t" + "| " + this[i, j] + " |");
                }
                Console.WriteLine();
            }
        }

        public override bool Equals(object obj)
        {
            return (this as Matrix)==(obj as Matrix);
        }
    }
}
