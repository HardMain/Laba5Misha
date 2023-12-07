using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Matrix
    {
        int[,] matrix;
        static Random random = new Random();

        public Matrix()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в матрице: ";
            errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            msg = "Введите количество столбцов в матрице: ";
            errorMsg = "\nКоличество колонок должно быть положительным числом!\n";
            countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            matrix = new int[countRows, countCols];
            Console.WriteLine();
        }
        public void ManualFill()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = CheckAndInput.InputIntNumber($"Введите элемент {i + 1}-й строки {j + 1}-ого столбца: ");
            }
            Console.WriteLine();
        }
        public void RandomFill()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(-50, 50);
            }
        }
        public void ShowMatrix()
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Матрица пуста!\n");
                return;
            }

            Console.WriteLine("----- Матрица -----");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        public void DeleteRow()
        {
            if (matrix.Length == 0)
                return;

            int indexForDelete = FindNumberRowsForDelete();
            if (indexForDelete == -1)
            {
                Console.WriteLine("\nНе нашлось строки для удаления!\n");
                return;
            }

            int[,] tempArray = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            for (int i = 0, z = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != indexForDelete)
                        tempArray[z,j] = matrix[i,j];
                }
                if (i != indexForDelete)
                    ++z;
            }

            Console.WriteLine();
            matrix = tempArray;
        }
        public int FindNumberRowsForDelete()
        {
            int countZero = 0;
            int indexForDelete = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                countZero = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        countZero++;

                    if (countZero > 1)
                    {
                        indexForDelete = i;
                        break;
                    }
                }

                if (indexForDelete != -1)
                    break;
            }
            return indexForDelete;
        }
        public void ContinuePartOne()
        {
            string msg = "\n1. Продолжить задание\n2. Перейти к следующему\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    DeleteRow();
                    ShowMatrix();
                    ContinuePartOne();
                    notExit = false;
                }
                else if (choice == 2)
                    return;
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
    }
}