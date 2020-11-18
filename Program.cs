using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        const int n = 4;

        static void Main(string[] args)
        {
            var x = ChooseParameters('x');
            var y = ChooseParameters('y');
            var sums = new double[n];
            for (var i = 0; i < n; i ++)
            {
                sums[0] += x[i];
                sums[1] += y[i];
                sums[2] += x[i] * x[i];
                sums[3] += x[i] * y[i];
            }
            var str1 = new double[] { sums[2], sums[0], sums[3] };
            var str2 = new double[] { sums[0], n, sums[1] };
            var t = str1[0];
            if (t != 1)
                for (var i = 0; i < str1.Length; i++)
                    str1[i] /= t;
            var k = str2[0];
            for (var i = 0; i < str1.Length; i++)
                str2[i] -= k * str1[i];
            var b = str2[str2.Length - 1] / str2[str2.Length - 2];
            var a = str1[str1.Length - 1] - str1[str1.Length - 2] * b;
            if (b < 0)
                Console.WriteLine("y = " + a + "x " + b);
            else
                Console.WriteLine("y = " + a + "x + " + b);
            Console.ReadKey();
        }

        private static double[] ChooseParameters(char s)
        {
            var parameters = new double[n];
            Console.WriteLine($"Введите по порядку коэффициенты {s}");
            while (true)
            {
                var m = GetUserInput();
                if (m.Length == n)
                {
                    for (var j = 0; j < n; j++)
                        parameters[j] = m[j];
                    break;
                }
                ShowError();
            }
            return parameters;
        }


        static double[] GetUserInput()
        {
            return Console.ReadLine().Split(' ')
                           .Where(x => !string.IsNullOrWhiteSpace(x) && double.TryParse(x, out var d))
                           .Select(x => double.Parse(x))
                           .ToArray();
        }
        static void ShowError()
        {
            Console.WriteLine("Ошибка! Следуйте командам");
            Console.WriteLine();
        }

    }
}
