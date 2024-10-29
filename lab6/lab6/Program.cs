using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            TEditor num1 = new TEditor();
            TEditor num2 = new TEditor();
            TEditor num3 = new TEditor();

            string number1 = "-1,36+(i*3,08)";
            string number2 = "43,81-(i*2,5)";

            num1.WriteNumber(number1);
            num2.WriteNumber(number2);
            Console.WriteLine($"Исходное число num1: {num1.ReadNumber()}");
            num1.ToggleMinus();
            Console.WriteLine($"Удаление минуса в действительной части num1: {num1.ReadNumber()}");
            num1.DelNumber();
            Console.WriteLine($"Удаление символа в действительной части num1: {num1.ReadNumber()}");
            num1.AddNumber(8);
            Console.WriteLine($"Добавлние цифры в действительную часть num1: {num1.ReadNumber()}");
            num1.AddNumber(3);
            Console.WriteLine($"Добавлние ещё одной цфиры в действительную часть num1: {num1.ReadNumber()}");
            num1.ToggleNumberMode();
            num1.DelNumber();
            Console.WriteLine($"Удаление цифры из действительной дробной части num1: {num1.ReadNumber()}");
            num1.ToggleMode();
            num1.ToggleMinus();
            Console.WriteLine($"Измнение знака мнимой части на противоположный num1: {num1.ReadNumber()}");
            num1.ToggleMinus();
            Console.WriteLine($"Изменение на исходный знак мнимой части num1: {num1.ReadNumber()}");
            num1.ToggleNumberMode();
            num1.DelNumber();
            Console.WriteLine($"Удаление из мнимой части цифры в целой части num1: {num1.ReadNumber()}");
            num1.ToggleNumberMode();
            num1.AddNumber(4);
            Console.WriteLine($"Добавление цифры в мнимую дробную часть num1: {num1.ReadNumber()}");
            num1.AddNumber(5);
            Console.WriteLine($"Добавление ещё одной цифры в мнимую дробную часть num1: {num1.ReadNumber()}");
            Console.WriteLine();

            Console.WriteLine($"Исходное число num2: {num2.ReadNumber()}");
            Console.WriteLine($"num2 нулевое: " + (num2.IsZero() ? "да" : "нет"));
            num2.ToggleMode();
            num2.ToggleMinus();
            Console.WriteLine($"Измнение знака мнимой части num2: {num2.ReadNumber()}");
            num2.Clear();
            Console.WriteLine($"Очищенное значение num2: {num2.ReadNumber()}");
            Console.WriteLine($"num2 нулевое: " + (num2.IsZero() ? "да" : "нет"));


            num3.ShowEditInfo();
            Console.WriteLine("Нажмите на клавишу Esc для завершения.");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                int command = -1;
                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        command = 0;
                        break;
                    case ConsoleKey.D1:
                        command = 1;
                        break;
                    case ConsoleKey.D2:
                        command = 2;
                        break;
                    case ConsoleKey.D3:
                        command = 3;
                        break;
                    case ConsoleKey.D4:
                        command = 4;
                        break;
                    case ConsoleKey.D5:
                        command = 5;
                        break;
                    case ConsoleKey.D6:
                        command = 6;
                        break;
                    case ConsoleKey.D7:
                        command = 7;
                        break;
                    case ConsoleKey.D8:
                        command = 8;
                        break;
                }

                if (command != -1)
                {
                    num3.Edit(command);
                }
            }
        }
    }
}
