using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            TEditor editor = new TEditor();
            editor.WriteNumber("-62,6+(i*52,9)");
            TMemory<int> num1 = new TMemory<int>();
            TMemory<float> num2 = new TMemory<float>();
            TMemory<double> num3 = new TMemory<double>();
            //TMemory<char> num4 = new TMemory<char>();
            TMemory<TEditor> num5 = new TMemory<TEditor>(editor);

            num1.WriteMemory(3);
            Console.WriteLine($"num1 = {num1.ReadNumber()}, " + (num1.ReadState() ? "state true" : "state false"));
            num1.Add(6);
            Console.WriteLine($"num1 = {num1.ReadNumber()}, " + (num1.ReadState() ? "state true" : "state false"));
            num1.Clear();
            Console.WriteLine($"num1 = {num1.ReadNumber()}, " + (num1.ReadState() ? "state true\n" : "state false\n"));

            num2.WriteMemory(-4.03f);
            Console.WriteLine($"num2 = {num2.ReadNumber()}, " + (num2.ReadState() ? "state true" : "state false"));
            num2.Add(-33.95f);
            Console.WriteLine($"num2 = {num2.ReadNumber()}, " + (num2.ReadState() ? "state true" : "state false"));
            float tempNum2 = num2.Get();
            Console.WriteLine($"tempNum2 = {tempNum2}, " + (num2.ReadState() ? "state true\n" : "state false\n"));

            num3.WriteMemory(0.0001);
            Console.WriteLine($"num3 = {num3.ReadNumber()}, " + (num3.ReadState() ? "state true" : "state false"));
            double tempNum3 = num3.Get();
            Console.WriteLine($"tempNum3 = {tempNum3}, " + (num3.ReadState() ? "state true\n" : "state false\n"));

            //num4.WriteMemory('h');
            //Console.WriteLine($"num4 = {num4.ReadNumber()}, " + (num4.ReadState() ? "state true" : "state false"));
            //num4.Clear();
            //Console.WriteLine($"num4 = {num4.ReadNumber()}, " + (num4.ReadState() ? "state true\n" : "state false\n"));

            num5.WriteMemory(editor);
            Console.WriteLine($"num5 = {num5.ReadNumber()}, " + (num5.ReadState() ? "state true" : "state false"));
            //num5.Add("-102,3-(i*87,011)");
            Console.WriteLine($"num5 = {num5.ReadNumber()}, " + (num5.ReadState() ? "state true" : "state false"));
            TEditor tempNum5 = num5.Get();
            Console.WriteLine($"tempNum5 = {tempNum5.ReadNumber()}, " + (num5.ReadState() ? "state true\n" : "state false\n"));
        }
    }
}
