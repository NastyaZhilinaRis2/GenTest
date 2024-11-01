using System;

namespace ООП5
{
    public class RaggedArray
    {
        static int row = 0;
        static int[][] raggedArray = new int[row][];
        public static void MenuRaggedArray()
        {
            ConsoleHelper.Border("Upper", 1);
            Console.WriteLine("1 - Создать рваный массив");
            Console.WriteLine("2 - Вывести массив");
            Console.WriteLine("3 - Удалить первую строку, содержащую нули");
            ConsoleHelper.Border("Lower", 1);

            bool isCorrect = false;
            do
            {
                int num_menu = ConsoleHelper.GetValidInputInt();
                switch (num_menu)
                {
                    case 1:
                        {
                            MenuCreateArray();
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
                            DeleteNullStringArray();
                            isCorrect = true;
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
        static void MenuCreateArray()
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
                            CreateArray(1);
                            isCorrect = true;
                            break;
                        }
                    case 2:
                        {
                            CreateArray(2);
                            isCorrect = true;
                            break;
                        }
                    case 0:
                        {
                            MenuRaggedArray();
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

            raggedArray = new int[row][];

            for (int i = 0; i < row; i++)
            {
                Console.Write($"\nВведите количество столбцов для {i+1} строки: ");
                int col = ConsoleHelper.GetValidInputIntPositiv();
                raggedArray[i] = new int [col];

                if (typeCreate == 1)
                    Console.WriteLine($"\nВведите элементы для этой строки: ");
                for (int j = 0; j < col; j++)
                {
                    if (typeCreate == 1)
                        raggedArray[i][j] = ConsoleHelper.GetValidInputInt();
                    else if (typeCreate == 2)
                        raggedArray[i][j] = random.Next(0, 5);
                }

            }
            Console.WriteLine("\nМассив заполнен!");
            MenuRaggedArray();
        }
        static void PrintArray()
        {
            if (raggedArray.Length == 0)
                Console.WriteLine("\nМассив пуст!");
            else
            {
                Console.WriteLine("\nРваный массив:");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < raggedArray[i].Length; j++)
                        Console.Write($"{raggedArray[i][j],4}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            MenuRaggedArray();
        }
        static void DeleteNullStringArray()
        {
            if (raggedArray.Length == 0)
                Console.WriteLine("\nМассив пуст!");
            else
            {
                bool isDone = false;
                for (int i = 0; i < row && !isDone; i++)
                {
                    for (int j = 0; j < raggedArray[i].Length && !isDone; j++)
                    {
                        if (raggedArray[i][j] == 0)
                        {
                            DeleteStringArray(i);
                            isDone = true;
                            break;
                        }
                    }
                }
                if (isDone)
                    Console.WriteLine("\nУдаление произведено!");
                else
                    Console.WriteLine("\nНулей нет!");
            }
            MenuRaggedArray();
        }
        static void DeleteStringArray(int indexRow)
        {
            int[][] temp = new int[row - 1][];
            int iTemp = 0;
            for (int i = 0; i < row; i++)
            {
                if (i != indexRow)
                {
                    temp[iTemp] = new int[raggedArray[i].Length];
                    for (int j = 0; j < raggedArray[i].Length; j++)
                    {
                        temp[iTemp][j] = raggedArray[i][j];
                    }
                    iTemp++;
                }
                    
            }
            row--;
            raggedArray = temp;
        }
    }
}
