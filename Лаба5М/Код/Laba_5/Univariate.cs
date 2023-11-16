using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Univariate : ArrayBase
    {
        int[] array;
        public Univariate()
        {
            string msg = "Введите размер одномерного массива(>0): ";
            string errorMsg = "\nКоличество элементов должно быть положительным!\n";

            array = new int[CheckAndInput.InputPositiveNumber(msg, errorMsg)];
            Console.WriteLine();
        }
        public override void RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-50, 50);
        }
        public override void ManualFill()
        {
            string? msg;

            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                msg = $"Введите {i + 1}-й элемент: ";
                array[i] = CheckAndInput.InputIntNumber(msg);
            }
        }
        public void ShowArrayObj()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Одномерный массив -----");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine('\n');
        }
        public void ShowArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Одномерный массив -----");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine('\n');
        }

        public void AddElements()
        {
            int countEvenElements = GetCountEvenElements(array);

            int[] tempArray = new int[array.Length + countEvenElements];

            for (int i = 0, k = 0; i < tempArray.Length; i++, k++)
            {
                if (array[k] % 2 == 0)
                {
                    tempArray[i] = array[k];
                    tempArray[++i] = 0;
                }
                else
                    tempArray[i] = array[k];
            }

            array = tempArray;
            ShowArray(array);
        }
        public int GetCountEvenElements(int[] tempArray)
        {
            int countElements = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] % 2 == 0)
                    countElements++;
            }

            return countElements;
        }
    }
}
