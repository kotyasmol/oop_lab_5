using System;
using System.Xml.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        PrintMenu();
    }

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

    public static void WorkWithOneDimArray()
    {
        int[] array = null;
        int choice;

        do
        {
            string s = "\n1. Создать массив\n2. Напечатать массив\n3. Удалить элементы с нечётными индексами\n4. Назад\n";
            choice = CheckInput(s);

            switch (choice)
            {
                case 1:
                    CreateOneDimArray(out array);
                    break;

                case 2:
                    PrintArray(array);
                    break;

                case 3:
                    DeleteElement(ref array);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("\nНекорректный ввод\n");
                    break;
            }

        } while (choice != 4);
    } 

    public static void WorkWithTwoDimArray()
    {
        int[,] matrix = null;
        int choice;

        do
        {
            string s = "\n1. Создать массив\n2. Напечатать массив\n3. Добавить k столбцов в начало матрицы\n4. Назад\n";
            choice = CheckInput(s);

            switch (choice)
            {
                case 1:
                    CreateTwoDimArray(out matrix);
                    break;

                case 2:
                    PrintArray(matrix);
                    break;

                case 3:
                    AddRowToStart(ref matrix);
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

    public static void WorkWithJaggedArray() 
    {
        int[][] jaggedArray = null;
        int choice;

        do
        {
            string s = "\n1. Создать массив\n2. Напечатать массив\n3. Удалить все строки с четными номерами\n4. Назад\n";
            choice = CheckInput(s);

            switch (choice)
            {
                case 1:
                    CreateJaggedArray(out jaggedArray);
                    break;

                case 2:
                    PrintArray(jaggedArray);
                    break;

                case 3:
                    DeleteRows(ref jaggedArray);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("\nНекорректный ввод\n");
                    break;
            }

        } while (choice != 4);
    }

    public static void CreateOneDimArray(out int[] array)
    {

        int size;
        string s = "Введите количество элементов массива: ";
        size = CheckInput(s);

        int inputChoice;
        s = "1. Создать массив вручную\n2. Создать массив с помощью ДСЧ\n";
        inputChoice = CheckInput(s);

        if (inputChoice == 1)
        {
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите элемент {i}: ");
                bool check = !int.TryParse(Console.ReadLine(), out array[i]);
                if (check)
                {
                    i--;
                    Console.WriteLine("\nНеккоретное значение элемента\n");
                    continue;
                }
            }
        }
        else
        {
            if (inputChoice != 2)
            {
                Console.WriteLine("\nНекорректный ввод\n");
            }
            Random rnd = new Random();
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 10);
            }
        }
        PrintArray(array);
    }

    public static void CreateTwoDimArray(out int[,] matrix)
    {
        int rows;
        string s = "Введите количество строк: ";
        rows = CheckInput(s);
        int cols;
        s = "Введите количество столбцов: ";
        cols = CheckInput(s);
        matrix = new int[rows, cols];

        s = "\n1.Ввести значения массива вручную\n2.Заполнить массив автоматически\n";
        int choice;
        choice = CheckInput(s);

        switch (choice)
        {
            case 1:
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write($"Введите элемент массива [{i}, {j}]: ");
                        bool check = !int.TryParse(Console.ReadLine(), out matrix[i, j]);
                        if (check)
                        {
                            j--;
                            Console.WriteLine("\nНеккоретное значение элемента\n");
                            continue;
                        }
                    }
                }
                break;

            case 2:
                Random rnd = new Random();
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] = rnd.Next(1, 10);
                break;

            default:
                Console.WriteLine("\nНекорректный ввод\n");
                break;
        }

        PrintArray(matrix);
    }

    public static void CreateJaggedArray(out int[][] jaggedArray)
    {
        int rows;
        string s = "Введите количество строк: ";
        rows = CheckInput(s);
        jaggedArray = new int[rows][];

        int choice;
        s = "\n1.Ввести значения массива вручную\n2.Заполнить массив автоматически\n";
        choice = CheckInput(s);

        switch (choice)
        {
            case 1:
                for (int i = 0; i < rows; i++)
                {
                    int cols;
                    string s1 = $"Введите количество элементов в строке {i}: ";
                    cols = CheckInput(s1);

                    jaggedArray[i] = new int[cols];

                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write($"Введите элемент массива [{i}][{j}]: ");
                        bool check = !int.TryParse(Console.ReadLine(), out jaggedArray[i][j]);
                        if (check)
                        {
                            j--;
                            Console.WriteLine("\nНеккоретное значение элемента\n");
                            continue;
                        }
                    }
                }
                break;

            case 2:
                Random rnd = new Random();
                for (int i = 0; i < rows; i++)
                {
                    int cols;
                    string s1 = $"Введите количество элементов {i + 1} строки: ";
                    cols = CheckInput(s1);
                    jaggedArray[i] = new int[cols];
                    for (int j = 0; j < cols; j++)
                        jaggedArray[i][j] = rnd.Next(1, 10);
                }
                break;

            default:
                Console.WriteLine("\nНекорректный ввод\n");
                break;
        }
        PrintArray(jaggedArray);
    }

    public static void PrintArray(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Массив пустой");
            return;
        }

        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");

        Console.WriteLine();
    }

    public static void PrintArray(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            Console.WriteLine("Массив пустой");
            return;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");

            Console.WriteLine();
        }
    }

    public static void PrintArray(int[][] jaggedArray)
    {
        if (jaggedArray == null || jaggedArray.Length == 0)
        {
            Console.WriteLine("Массив пустой");
            return;
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
                Console.Write(jaggedArray[i][j] + " ");

            Console.WriteLine();
        }
    }

    public static void DeleteElement(ref int[] array)
    {

        if (array == null || array.Length == 0)
        {
            Console.WriteLine("\nМассив пуст\n");
            return;
        }
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                count++;
            }
        }

        int[]newArray = new int[count];

        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                newArray[index] = array[i];
                index++;
            }
        }
        PrintArray(newArray);
        Array.Resize(ref array, count); // возможно не совсем так.
        array = newArray;

    } // для первого

    public static void AddRowToStart(ref int[,] matrix) 
    {
        if (matrix == null || matrix.Length == 0)
        {
            Console.WriteLine("\nМассив пуст\n");
            return;
        }

        string s = "Введите количество добавляемых столбцов: ";
        int k = CheckInput(s);
        
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)+k];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(0); j++)
                newMatrix[i, j+k] = matrix[i, j];

        matrix = newMatrix;

       /* Random rnd = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(0) - k; j++)
                matrix[i, j] = rnd.Next(1, 10); */

        /*Random rnd = new Random();
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[0, j] = rnd.Next(1, 10); */

        PrintArray(matrix);
    } // для второго 
    // добавить K столбцов в начало матрицы

    public static void DeleteRows(ref int[][] jaggedArray)
    {

        //Удалить все строки с четными номерами
        if (jaggedArray == null || jaggedArray.Length == 0)
        {
            Console.WriteLine("\nМассив пуст\n");
            return;
        }

        // Считаем количество строк с четными номерами
        int rowCount = 0;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (i % 2 == 0) // Проверяем, является ли номер строки четным
            {
                rowCount++;
            }
        }

        // Создаем новый рваный массив нужного размера
        int[][] newArray = new int[rowCount][];

        // Копируем только строки с нечетными номерами
        int index = 0;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (i % 2 == 0) // Проверяем, является ли номер строки четным
            {
                newArray[index] = jaggedArray[i]; // Копируем строку в новый массив
                index++;
            }
        }

        if (jaggedArray.Length == 0)
        {
            Console.WriteLine("Массив пустой");
        }
        else
        {
            PrintArray(newArray);
        }
        jaggedArray = newArray;

    } // для третьего
}