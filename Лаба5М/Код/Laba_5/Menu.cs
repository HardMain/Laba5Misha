using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Menu
    {
        public Menu()
        {
            bool isNonExit = true;
            int choice = 0;
            string msg = "", errorMsg = "\nТакого пункта меню не существует!\n";

            do
            {
                Console.Clear();
                Console.WriteLine("----- Добро пожаловать в МЕНЮ программы! -----\n");
                msg = "1. Одномерный массив. Добавить после каждого четного элемента элемент со значением 0.\n" +
                      "2. Двумерный массив. Удалить все строки, в которых есть хотя бы один нулевой элемент.\n" +
                      "3. Рваный массив. Добавить К строк в конец массива .\n" +
                      "4. Завершить работу программы.\n-> ";

                choice = CheckAndInput.InputIntNumber(msg);
                switch (choice)
                {
                    case 1:
                        Console.Clear(); Univariate array = new Univariate(); choiceFill(array); MakeAndShowChanges(array); break;
                    case 2:
                        Console.Clear(); Bivariate matrix = new Bivariate(); choiceFill(matrix); MakeAndShowChanges(matrix); break;
                    case 3:
                        Console.Clear(); Ragged ragged = new Ragged(); choiceFill(ragged); MakeAndShowChanges(ragged); break;
                    case 4:
                        isNonExit = false; break;
                    default:
                        Console.WriteLine(errorMsg);
                        break;
                }

                if (isNonExit) 
                {
                    Console.Write("Нажмите любую клавишу для продолжения. . .");
                    Console.ReadKey();
                }

            } while (isNonExit);
        }
        public void choiceFill(ArrayBase obj)
        {
            string msg = "\tВыберите как заполнить массив\n1.Вручную\n2.Рандомно\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);
                if (choice == 1)
                {
                    obj.ManualFill();
                    break;
                }
                else if (choice == 2)
                {
                    obj.RandomFill();
                    break;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (true);
            Console.WriteLine();
        }
        public void MakeAndShowChanges(ArrayBase obj)
        {
            if (obj is Univariate)
            {
                Univariate univariate = (Univariate)obj;
                univariate.ShowArrayObj();
                univariate.AddElements();
            }
            else if (obj is Bivariate)
            {
                Bivariate bivariate = (Bivariate)obj;
                bivariate.ShowMatrix();
                bivariate.DeleteRows();
                bivariate.ShowMatrix();
            }
            else if (obj is Ragged)
            {
                Ragged ragged = (Ragged)obj;
                ragged.ShowRaggedObj();
                ragged.AddRowToEnd();
            }
        }
    }
}
