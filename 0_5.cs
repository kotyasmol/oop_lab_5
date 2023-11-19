using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o_lab_5_
{
    internal class Program
    {
        public static void PrintMenu()
        {
            int choice;
            do
            {
                string s = "Меню:\n1. Работа с одномерными массивами\n2. Работа с двумерными массивами\n3. Работа с рваными массивами\n4. Выход\n";
                choice = CheckInput(s);

                switch (choice)
                {
                    case 1:
                        WorkWithOneDimArray();
                        break;
                    case 2:
                        WorkWithTwoDimArray();
                        break;
                    case 3:
                        WorkWithJaggedArray();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("\nНекорректный ввод\n");
                        break;
                }

            } while (choice != 4);
        }

        public static int CheckInput(string s)
        {
            int n;
            while (true)
            {
                Console.Write(s);
                bool check = !int.TryParse(Console.ReadLine(), out n);
                if (check || n < 1)
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

        public static void WorkWithOneDimArray()
        {
            int[] array = null; // выделение памяти для пустого массива
            int choice;
            do
            {
                string s = "\n1. Создать массив\n2. Напечатать массив\n3. Удалить элемент с заданным номером\n4. Назад\n";
                choice = CheckInput(s);
                switch(choice)
                {
                    case(1):
                        break;
                }
            } while (choice != 4);
        }
        static void Main(string[] args)
        {
                PrintMenu();
        }
    }
}
