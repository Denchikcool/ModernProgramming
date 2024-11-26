using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<int> dictionarySizes = new List<int>()
            {
                16,
                32,
                64,
                128
            };

            foreach(int element in dictionarySizes)
            {
                double theoreticalLength = CalculateProgramLength(element / 2, element / 2);
                double theoreticalVariance = CalculateVariance(element);
                //стандартное отклонение
                double standardDeviation = Math.Sqrt(theoreticalVariance);
                //относительная ожидаемая погрешность
                double delta = 1.0 / (2 * Math.Log(element, 2));
                double temp = 0.0;

                for(int i = 0; i < 100000; i++)
                {
                    double simulatedLength = SimulateProgramLength(element);
                    temp += simulatedLength;
                }

                temp = temp / 100000;
                Console.WriteLine($"Для словаря длины {element}: ");
                Console.WriteLine($"Теоретическая длина программы = {theoreticalLength}");
                Console.WriteLine($"Эмулированная длина программы = {temp}");
                Console.WriteLine($"Теоретическая дисперсия = {theoreticalVariance}");
                Console.WriteLine($"Стандартное отклонение = {standardDeviation}");
                Console.WriteLine($"Относительная погрешность = {delta} (в процентах = {delta * 100}%)");
                Console.WriteLine("------------------------------------\n");
            }
        }

        //математическое ожидание длины программы
        private static double CalculateProgramLength(int operators, int operands)
        {
            double eta = operators + operands;
            return 0.9 * eta * Math.Log(eta, 2);
        }

        //дисперсия
        private static double CalculateVariance(int eta)
        {
            return (Math.PI * Math.PI * eta * eta) / 6.0;
        }

        private static double SimulateProgramLength(int eta)
        {
            List<bool> dictionary = new List<bool>(eta);

            for (int i = 0; i < eta; i++)
            {
                dictionary.Add(false);
            }

            int drawn = 0, length = 0;

            Random rnd = new Random();

            while (drawn < eta)
            {
                int randomIndex = rnd.Next(eta);
                length++;
                if (!dictionary[randomIndex])
                {
                    dictionary[randomIndex] = true;
                    drawn++;
                }
            }

            return length;
        }
    }
}
