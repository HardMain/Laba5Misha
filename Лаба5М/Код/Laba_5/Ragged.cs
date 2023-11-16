using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Ragged : ArrayBase
    {
        int[][] ragged;
        public Ragged()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в матрице: ";
            errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            ragged = new int[countRows][];

            errorMsg = "\nКоличество колонок должно быть положительным числом!\n";
            for (int i = 0; i < countRows; i++)
            {
                msg = $"Введите количество столбцов для {i + 1} строки: ";
                countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);

                ragged[i] = new int[countCols];
            }
            Console.WriteLine();
        }
        public override void RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    ragged[i][j] = random.Next(-50, 50);
            }
        }
        public override void ManualFill()
        {
            string? msg;

            Console.WriteLine();
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    msg = $"Введите элемент для {i + 1}-й строки {j + 1}-го столбца: ";
                    ragged[i][j] = CheckAndInput.InputIntNumber(msg);
                }
            }
        }
        public void ShowRaggedObj()
        {
            if (ragged.Length == 0)
            {
                Console.WriteLine("Рваный массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Рваный массив -----");
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    Console.Write($"{ragged[i][j],-4} ");
                Console.WriteLine('\n');
            }
        }
        public void ShowRagged(int[][] ragged)
        {
            if (ragged.Length == 0)
            {
                Console.WriteLine("Рваный массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Рваный массив -----");
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    Console.Write($"{ragged[i][j],-4} ");
                Console.WriteLine('\n');
            }
        }
        public void AddRowToEnd()
        {
            string msg = "Введите количество строк для добавления: ";
            string errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            int countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            int[][] tempArray = new int[ragged.Length + countRows][];

            int j = 0;
            for (int i = 0; i < ragged.Length; i++)
                tempArray[j++] = new int[ragged[i].Length];

            int temp = j;
            errorMsg = "\nКоличество столбцов должно быть положительным числом!\n";
            for (int i = 0; j < tempArray.Length; j++)
            {
                msg = $"Введите количество столбцов для {i++ + 1} строки в добавлении: ";
                int countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);
                tempArray[j] = new int[countCols];
            }
            
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int z = 0; z < ragged[i].Length; z++)
                    tempArray[i][z] = ragged[i][z];
            }

            Console.WriteLine();
            msg = "Введите элемент для добавления: ";
            for (int i = temp; i < tempArray.GetLength(0); i++)
            {
                for (int z = 0; z < tempArray[i].Length; z++)
                    tempArray[i][z] = CheckAndInput.InputIntNumber(msg);
            }

            ragged = tempArray;

            Console.WriteLine();
            ShowRagged(ragged);

            msg = "1. Продолжить добавление\n2. Перейти к другому заданию\n-> ";
            errorMsg = "Такого пункта меню не существует!\n";

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);
                Console.WriteLine();
                if (choice == 1)
                {
                    AddRowToEnd();
                    break;
                }
                else if (choice == 2)
                    break;
                else
                    Console.WriteLine(errorMsg);
            } while (true);
        }
    }
}
