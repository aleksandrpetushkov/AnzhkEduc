using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace tst_00
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstValue, secondValue, thirdValue;

            Console.WriteLine("Введите число 1:");

            firstValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите число 2:");
            secondValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите число 3:");
            thirdValue = double.Parse(Console.ReadLine());

            double sumResult = firstValue + secondValue + thirdValue;
            Console.WriteLine("Сумма этих чисел:" + sumResult);

            double multResult = firstValue * secondValue * thirdValue;
            Console.WriteLine("Произведение этих чисел:" + multResult);

            Console.ReadKey();
        }
        
    }
}
