using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string info = "";
            Console.WriteLine("Пример из методички (2 + 3 * (4)^2)\n");
            TProc<int> proc = new TProc<int>();
            TProc<double> test = new TProc<double>();
            proc.Rop_Set(4);
            info = proc.RetRop();
            proc.FunctionSet(2);
            Console.WriteLine($"Установка правой ({info}) части при функции: {proc.GetFunction()}");
            proc.FunctionRun();
            info = proc.RetRop();
            Console.WriteLine($"Результат первой операции = {info}");
            proc.Lop_Res_Set(3);
            info = proc.RetLop_Res();
            proc.OperationSet(3);
            Console.WriteLine($"Установка левой ({info}) части при функции: {proc.OperationGet()}");
            proc.OperationRun();
            info = proc.RetLop_Res();
            Console.WriteLine($"Результат второй операции = {info}");
            proc.Rop_Set(2);
            info = proc.RetRop();
            proc.OperationSet(1);
            Console.WriteLine($"Установка правой ({info}) части при функции: {proc.OperationGet()}");
            proc.OperationRun();
            info = proc.RetLop_Res();
            Console.WriteLine($"Результат третьей операции = {info}");
            test.Rop_Set(379.00);
            test.FunctionSet(1);
            test.FunctionRun();
            double result = test.RetTRop();
            Console.WriteLine($"Обратное значение = {result}");

        }
    }
}
