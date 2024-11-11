using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            TPoly tPoly1 = new TPoly();
            TPoly tPoly2 = new TPoly();
            tPoly1.Members.Add(new TMember(1, 1));
            tPoly1.Members.Add(new TMember(8, 6));
            tPoly1.Members.Add(new TMember(11, 51));
            tPoly2.Members.Add(new TMember(-6, 6));
            tPoly2.Members.Add(new TMember(20, 130));

            string firstPolynome = tPoly1.Show();
            string secondPolynome = tPoly2.Show();
            string resultMinus = tPoly1.Minus().Show();
            Console.WriteLine($"Первый полином = {firstPolynome}\nВторой полином = {secondPolynome}\n");
            Console.WriteLine($"Первый полином с обратным знаком = {resultMinus}");

            tPoly2.Members.Add(new TMember(3, 6));
            string secondPolynomeAdd = tPoly2.Show();
            Console.WriteLine($"Второй полином с добавлением элемента той же степени = {secondPolynomeAdd}");

            TPoly mul = tPoly1.Mul(tPoly2);
            string mulPolynomes = mul.Show();
            Console.WriteLine($"Произведение первого полинома на второй = {mulPolynomes}");

            TPoly sub = tPoly1.Sub(tPoly2);
            string subPolynomes = sub.Show();
            Console.WriteLine($"Разница первого полинома и второго = {subPolynomes}");

            Console.WriteLine($"Равны ли эти полиндромы между собой? {(tPoly1.Equals(tPoly2) ? "\nДа!" : "\nНет!")}");

            string diffFirstPolynome = tPoly1.Diff().Show();
            string diffSecondPolynome = tPoly2.Diff().Show();
            Console.WriteLine($"Производная от первого полинома = {diffFirstPolynome}\nПроизводная от второго полинома = {diffSecondPolynome}\n");

            double result1 = tPoly1.Calculate(6.31);
            double result2 = tPoly2.Calculate(-5.4);
            Console.WriteLine($"Результат первого полинома в точке 6.31 = {result1}\nРезультат второго полинома в точке -5.4 = {result2}\n");

            Tuple<int, int> fromFirstPolynome = tPoly1.TakeElement(2);
            Tuple<int, int> fromSecondPolynome = tPoly2.TakeElement(1);
            Console.WriteLine($"Элемент по индексу 2 из первого полинома = {fromFirstPolynome}\nЭлемент по индексу 1 из второго полинома = {fromSecondPolynome}\n");

            sub.Clear();
            string subClear = sub.Show();
            Console.WriteLine($"Очистили полином, содержащий в себе произведение первого на второй: {subClear}\n");

            int degreeFirst = tPoly1.ReturnDegree();
            int degreeSecond = tPoly2.ReturnDegree();
            Console.WriteLine($"Наибольшая степень в первом полиноме = {degreeFirst}\nНаибольшая степень во втором полиноме = {degreeSecond}\n");

            int maxCoeffFirst = tPoly1.ReturnCoefficent(degreeFirst);
            int maxCoeffSecond = tPoly2.ReturnCoefficent(degreeSecond);
            Console.WriteLine($"Коэффицент стоящий у наибольшей степени в первом полиноме = {maxCoeffFirst}\nКоэффицент стоящий у наибольшей степени во втором полиноме = {maxCoeffSecond}\n");
        }
    }
}
