using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<int> etas = new List<int>()
            {
                300,
                400,
                512
            };

            foreach(int element in etas)
            {
                int i = I(element);
                int k = K(element, i);
                double eta2k = Eta2k(element);
                double nk = Nk(eta2k);
                double n = N(k, nk);
                double v = V(k, nk, eta2k);
                double p = P(n);
                double tk = Tk(n);
                double t = T(tk);
                double b0 = B0(v);
                double tn = Tn(b0, t);

                Console.WriteLine($"Значение = {element}");
                Console.WriteLine($"Число уровней иерархии = {i}");
                Console.WriteLine($"Общее число модулей = {k}");
                Console.WriteLine($"Eta2k = {eta2k}");
                Console.WriteLine($"Nk = {nk}");
                Console.WriteLine($"Длина программы = {n}");
                Console.WriteLine($"Объём ПС = {v}");
                Console.WriteLine($"Длина ПС, выраженная в количестве команд ассемблера = {p}");
                Console.WriteLine($"Календарное время программирования = {tk}");
                Console.WriteLine($"Время отладки = {t}");
                Console.WriteLine($"Начальное количество ошибок = {b0}");
                Console.WriteLine($"Надежность ПС = {tn}");
                Console.WriteLine("=============================================");
            }
        }

        private static int I(int eta)
        {
            return (int)(Math.Log(eta, 2) / 3 + 1);
        }

        private static int K(int eta, int i)
        {
            int total = 1;
            for(int j = 1; j < i; j++)
            {
                total += (int)(eta / Math.Pow(8, j));
            }

            return total;
        }

        private static double N(int k, double nk)
        {
            return k * nk;
        }

        private static double Nk(double eta2k)
        {
            return 2 * eta2k * Math.Log(eta2k, 2);
        }

        private static double Eta2k(int eta)
        {
            return eta * Math.Log(eta, 2);
        }

        private static double V(int k, double nk, double eta2k)
        {
            return k * nk * Math.Log((2 * eta2k), 2);
        }

        private static double P(double n)
        {
            return 3 * n / 8;
        }

        private static double Tk(double p)
        {
            return p / (5 * 20);
        }

        private static double T(double tk)
        {
            return tk / 2;
        }

        private static double B0(double v)
        {
            return v / 3000;
        }

        private static double Tn(double b0, double t)
        {
            return t / Math.Log(b0);
        }
    }
}
