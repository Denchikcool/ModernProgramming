using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            TSet<int> set1 = new TSet<int>();
            TSet<int> set2 = new TSet<int>();
            TSet<int> set3 = new TSet<int>();
            set1.Add(1);
            set1.Add(3);
            set1.Add(6);

            set2.Add(2);
            set2.Add(1);
            set2.Add(5);

            set3.Add(87);
            set3.Add(-2);
            set3.Add(0);
            set3.Add(-256);
            set3.Add(43);
            set3.Add(1);

            Console.WriteLine($"Множество set1 = {set1.Show()}");
            Console.WriteLine($"Множество set2 = {set2.Show()}");
            Console.WriteLine($"Множество set3 = {set3.Show()}");

            Console.WriteLine($"Множество set1 без элементов, входящих в множество set2 = {set1.Except(set2).Show()}");
            Console.WriteLine($"Объединение множеств set1 и set2 = {set1.Union(set2).Show()}");
            Console.WriteLine($"Пересечение множеств set1 и set2 = {set1.Intersect(set2).Show()}");
            Console.WriteLine();

            set3.Remove(-256);
            Console.WriteLine($"Удаление элемента -256 из множества set3 = {set3.Show()}");
            Console.WriteLine($"Очищено ли множество set3? {(set3.IsClear() ? "Да" : "Нет")}");
            Console.WriteLine($"Есть в множестве set3 4? {(set3.Contains(4) ? "Да" : "Нет")}");
            Console.WriteLine($"А элемент 43? {(set3.Contains(43) ? "Да" : "Нет")}");

            int count = set3.Count();
            Console.WriteLine($"Количество элементов в множестве set3 = {count}");

            int position = set3.ElementAt(2);
            Console.WriteLine($"Элемент на позиции 3 = {position}");
            set3.Clear();
            Console.WriteLine($"А сейчас очищено ли множество set3? {(set3.IsClear() ? "Да" : "Нет")}");
        }
    }
}
