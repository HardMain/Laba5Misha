using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    internal static class Menu
    {
        static public void CallMenu()
        {
            bool isNonExit = true;
            int choice = 0;
            string msg = "", errorMsg = "\nТакого пункта меню не существует!\n";

            do
            {
                Console.Clear();
                Console.WriteLine("----- Добро пожаловать в МЕНЮ программы! -----\n");
                msg = "1. Удалить из массива первую строку, в которой больше одного элемента равного 0.\n" +
                      "2. Сдвинуть циклически влево каждое слово на количество символов равное номеру этого слова в строке.\n" +
                      "3. Завершить работу программы.\n-> ";

                choice = CheckAndInput.InputIntNumber(msg);
                switch (choice)
                {
                    case 1:
                        Console.Clear(); Matrix matrix = new Matrix(); choiceFill(matrix); matrix.ShowMatrix(); matrix.DeleteRow(); matrix.ShowMatrix(); Console.WriteLine(); break;
                    case 2:
                        Console.Clear(); Str str = new Str(); choiceFill(str); str.ShowStr(); str.CyclicShift(); str.ShowStr(); break;
                    case 3:
                        isNonExit = false; break;
                    default:
                        Console.WriteLine(errorMsg); break;
                }

                if (isNonExit)
                {
                    Console.Write("Нажмите любую клавишу для продолжения. . .");
                    Console.ReadKey();
                }

            } while (isNonExit);
        }
        static public void choiceFill(Matrix matrix)
        {
            string msg = "\tВыберите как заполнить матрицу\n1.Вручную\n2.Рандомно\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    matrix.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    matrix.RandomFill();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        static public void choiceFill(Str str)
        {
            string msg = "\tВыберите как заполнить строку\n1.Вручную\n2.Выбрать заготовленную\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str.PreparedLines();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
    }
}
