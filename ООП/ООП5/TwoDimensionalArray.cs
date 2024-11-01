using System;

namespace ООП5
{
    public class TwoDimensionalArray
    {
        static int col = 0, row = 0;
        static int[ , ] twoDimensionalArray = new int [row, col];
        public static void MenuTwoDimensionalArray()
        {
            ConsoleHelper.Border("Upper", 1);
            Console.WriteLine("1 - Создать двумерный массив");
            Console.WriteLine("2 - Вывести массив");
            Console.WriteLine("3 - Добавить строки в конец матрицы");
            ConsoleHelper.Border("Lower", 1);

            bool isCorrect = false;
            do
            {
                int num_menu = ConsoleHelper.GetValidInputInt();
                switch (num_menu)
                {
                    case 1:
                        {
                            MenuCreateArray("создать");
                            isCorrect = true;
                            break;
                        }
                    case 2:
                        {
                            PrintArray();
                            isCorrect = true;
                            break;
                        }
                    case 3:
                        {
                            if (twoDimensionalArray.Length == 0)
                            {
                                Console.WriteLine("\nМассив пуст!");
                                MenuTwoDimensionalArray();
                            }
                            else
                            {
                                MenuCreateArray("добавить");
                                isCorrect = true;
                            }
                            break;
                        }
                    case 0:
                        {
                            ConsoleHelper.DisplayMenu();
                            isCorrect = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nВ меню нет такого пункта! Проверьте корректность введенных данных!\n");
                            break;
                        }
                }
            }
            while (!isCorrect);
        }
        static void MenuCreateArray(string branch)
        {
            ConsoleHelper.Border("Upper", 2);
            Console.WriteLine("1 - Вручную");
            Console.WriteLine("2 - Автоматически");
            ConsoleHelper.Border("Lower", 2);

            bool isCorrect = false;
            do
            {
                int num_menu = ConsoleHelper.GetValidInputInt();
                switch (num_menu)
                {
                    case 1:
                        {
                            if (branch == "создать")
                                CreateArray(1);
                            if (branch == "добавить")
                                AddStringArray(1);
                            isCorrect = true;
                            break;
                        }
                    case 2:
                        {
                            if (branch == "создать")
                                CreateArray(2);
                            if (branch == "добавить")
                                AddStringArray(2);
                            isCorrect = true;
                            break;
                        }
                    case 0:
                        {
                            MenuTwoDimensionalArray();
                            isCorrect = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nВ меню нет такого пункта! Проверьте корректность введенных данных!\n");
                            break;
                        }
                }
            }
            while (!isCorrect);
        }
        static void CreateArray(int typeCreate)
        {
            Random random = new Random();
            Console.Write("\nВведите количество строк: ");
            row = ConsoleHelper.GetValidInputIntPositiv();

            Console.Write("\nВведите количество столбцов: ");
            col = ConsoleHelper.GetValidInputIntPositiv();

            twoDimensionalArray = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                if (typeCreate == 1)
                    Console.WriteLine($"\nВведите элементы {i+1} строки массива: ");
                for (int j = 0; j < col; j++)
                {
                    if (typeCreate == 1)
                        twoDimensionalArray[i, j] = ConsoleHelper.GetValidInputInt();
                    else if (typeCreate == 2)
                        twoDimensionalArray[i, j] = random.Next(0, 100);
                }

            }
            Console.WriteLine("\nМассив заполнен!");
            MenuTwoDimensionalArray();
        }
        static void PrintArray()
        {
            if (twoDimensionalArray.Length == 0)
                Console.WriteLine("\nМассив пуст!");
            else
            {
                Console.WriteLine("\nДвумерный массив:");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                        Console.Write($"{twoDimensionalArray[i, j], 4}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            MenuTwoDimensionalArray();
        }
        static void AddStringArray(int typeCreate)
        {
            Random random = new Random();
            Console.Write("\nВведите количество новых строк: ");
            int rowNew = ConsoleHelper.GetValidInputIntPositiv();

            int[,] temp = new int[row + rowNew, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    temp[i, j] = twoDimensionalArray[i, j];
                }
            }

            if (typeCreate == 1)
                Console.WriteLine("\nВведите новые элементы: ");
            for (int i = row; i < row + rowNew; i++)
            {
                if (typeCreate == 1)
                    Console.WriteLine($"\nВведите элементы {i+1} строки массива: ");
                for (int j = 0; j < col; j++)
                {
                    if (typeCreate == 1)
                        temp[i, j] = ConsoleHelper.GetValidInputInt();
                    else if (typeCreate == 2)
                        temp[i, j] = random.Next(0, 100);
                }

            }
            row += rowNew;
            twoDimensionalArray = new int[row, col];
            twoDimensionalArray = temp;

            Console.WriteLine("\nСтроки добавлены!");
            MenuTwoDimensionalArray();
        }

    }
}
