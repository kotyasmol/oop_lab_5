using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace o_lab_5_
{
    internal class Program
    {
        public static int CheckInput(string s)
        {
            int n;
            while (true)
            {
                Console.Write(s);
                bool isCheck = !int.TryParse(Console.ReadLine(), out n);
                if (isCheck || n < 1)
                {
                    Console.WriteLine("\nНекорректный ввод\n");
                }
                else
                {
                    break;
                }
            }
            return n;
        }


        public static void PrintMenu()
        {
            int choice;
            string s = "Меню:\n1. Работа с одномерными массивами\n2. Работа с двумерными массивами\n3. Работа с рваными массивами\n4. Выход\n";
            choice = CheckInput(s);//
            // проверка на хуйню (choice);
            do 
            { 
                 switch (choice)
                 {
                     case 1:
                         Console.WriteLine();
                         break;
                     case 2:
                        Console.WriteLine();
                        break;


            }
        } while (choice!=4);

        }
        static void Main(string[] args)
        {
                PrintMenu();
        }
    }
}
