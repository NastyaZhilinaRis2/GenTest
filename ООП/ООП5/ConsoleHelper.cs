using System;

namespace ООП5
{
    public class ConsoleHelper
    {
        public static int GetValidInputInt()
        {
            int number;
            bool isCorrect = false;
            do
            {
                string input;
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Проверьте корректность введенных данных!");
                    Console.WriteLine();
                }
            }
            while (!isCorrect);
            return number;
        }
        public static int GetValidInputIntPositiv()
        {
            bool isCorrect = false;
            int number;
            do
            {
                number = GetValidInputInt();
                if (number > 0)
                    isCorrect = true;

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Проверьте корректность введенных данных!");
                    Console.WriteLine();
                }
            }
            while (!isCorrect);
            return number;
        }
        public static void Border(string border, int lvl)
        {
            if(lvl == 0)
            {
                if (border == "Upper")
                {
                    Console.WriteLine();
                    Console.WriteLine("===========================================");
                    Console.WriteLine("===========================================");
                }
                else if (border == "Lower")
                {
                    Console.WriteLine();
                    Console.WriteLine("0 - Выход");
                    Console.WriteLine("===========================================");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                }
                
            }
            if(lvl == 1)
            {
                if (border == "Upper")
                {
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------");
                }
                else if (border == "Lower")
                {
                    Console.WriteLine();
                    Console.WriteLine("0 - Назад");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine();
                }
            }
            if(lvl == 2)
            {
                if (border == "Upper")
                {
                    Console.WriteLine();
                    Console.WriteLine("...........................................");
                }
                else if (border == "Lower")
                {
                    Console.WriteLine();
                    Console.WriteLine("0 - Назад");
                    Console.WriteLine("...........................................");
                    Console.WriteLine();
                }
            }
        }
        public static void DisplayMenu()
        {
            Border("Upper", 0);
            Console.WriteLine("1 - Одномерный массив");
            Console.WriteLine("2 - Двумерный массив");
            Console.WriteLine("3 - Рваный массив");
            Border("Lower", 0);

            bool isCorrect = false;
            do
            {
                int num_menu = GetValidInputInt();
                switch (num_menu)
                {
                    case 1:
                        {
                            OneDimensionalArray.MenuOneDimensionalArray();
                            isCorrect = true;
                            break;
                        }
                    case 2:
                        {
                            TwoDimensionalArray.MenuTwoDimensionalArray();
                            isCorrect = true;
                            break;
                        }
                    case 3:
                        {
                            RaggedArray.MenuRaggedArray();
                            isCorrect = true;
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
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
    }
}
