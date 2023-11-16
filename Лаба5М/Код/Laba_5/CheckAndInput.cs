using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal static class CheckAndInput
    {
        static public int InputIntNumber(string msg, string errorMsg = "\nНекорректный ввод числа!\n")
        {
            string? strEl;
            int el = 0;
            do
            {
                Console.Write(msg);
                strEl = Console.ReadLine();
                if (!int.TryParse(strEl, out el))
                    Console.WriteLine(errorMsg);
            } while (!int.TryParse(strEl, out el));

            return el;
        }
        static public int InputPositiveNumber(string msg, string errorMsg)
        {
            int el = 0;
            do
            {
                el = CheckAndInput.InputIntNumber(msg);
                if (el < 1)
                    Console.WriteLine(errorMsg);
            } while (el < 1);

            return el;
        }

        static public int InputWithinBoundariesArray(int[] array, string msg, string errorMsg) //ввод в границах массива
        {
            int el = 0;
            do
            {
                el = CheckAndInput.InputIntNumber(msg);
                if (el < 1 || el > array.Length + 1)
                    Console.WriteLine(errorMsg);
            } while (el < 1 || el > array.Length + 1);

            return el;
        }
    }
}
