using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Str
    {
        string? str;
        public Str() 
        {
            str = null;
        }
        public Str(string str)
        {
            this.str = str;
        }
        public void ManualFill()
        {
            Console.WriteLine("\tВведите строку");
            str = Console.ReadLine();
            Console.WriteLine();
        }
        public void PreparedLines()
        {
            string str1 = "int is a data type that represents integers.";
            string str2 = "double is a data type for floating-point numbers.";
            string str3 = "In C#, you can create structures with the struct keyword.";

            string msg = $"\tВыберите строку из заготовленных\n1. {str1}\n\n2. {str2}\n\n3.{str3}\n\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;
            
            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str = str1;
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str = str2;
                    notExit = false;
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    str = str3;
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        public void ShowStr()
        {
            Console.WriteLine("----- Строка -----");

            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Пустая строка!\n");
                return;
            }    

            Console.WriteLine(str + '\n');
        }
        public void CyclicShift()
        {   
            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Нет слов для циклического сдвига!");
                return;
            }

            string tempStr = "";
            int numberWord = 0;
            for (int i = 0; i < str.Length; i++)
            {
                string tempBeginWord = "";
                string tempEndWord = "";
                if (char.IsLetter(str[i]))
                {
                    string tempWord = "";
                    numberWord++;
                    for (int k = i; k < str.Length; k++)
                    {
                        if (!char.IsLetter(str[k]))
                            break;
                        tempWord += str[k];
                    }

                    int j = 0;
                    for (; j < (numberWord) % tempWord.Length; j++)
                        tempBeginWord += tempWord[j];
                    for (; j < tempWord.Length; j++)
                        tempEndWord += tempWord[j];

                    i += j - 1;
                }
                else
                    tempStr += str[i];

                tempEndWord = tempEndWord + tempBeginWord;
                tempStr += tempEndWord;
            }
            str = tempStr;
        }
    }
}
