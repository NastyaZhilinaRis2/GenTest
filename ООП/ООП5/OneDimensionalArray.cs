using System;

namespace ООП5
{
    public class OneDimensionalArray
    {
        static int[] oneDimensionalArray = new int[0];
        public static void MenuOneDimensionalArray()
        {
            ConsoleHelper.Border("Upper", 1);
            Console.WriteLine("1 - Создать одномерный массив");
            Console.WriteLine("2 - Вывести массив");
            Console.WriteLine("3 - Удалить все четные элементы");
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
                            DeleteElementsArray();
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
                            Console.WriteLine();
                            Console.WriteLine("В меню нет такого пункта! Проверьте корректность введенных данных!");
                            Console.WriteLine();
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
                            MenuOneDimensionalArray();
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
            Console.Write("\nВведите размер массива: ");
            int size = ConsoleHelper.GetValidInputIntPositiv();
            
            oneDimensionalArray = new int[size];
            if (typeCreate == 1) 
                Console.WriteLine("\nВведите элементы массива: ");
            for (int i = 0; i < size; i++)
            {
                if (typeCreate == 1)
                oneDimensionalArray[i] = ConsoleHelper.GetValidInputInt();
                else if (typeCreate == 2) 
                    oneDimensionalArray[i] = random.Next(0, 100);
            }
            Console.WriteLine("\nМассив заполнен!");
            MenuOneDimensionalArray();
        }
        static void PrintArray()
        {
            if(oneDimensionalArray.Length == 0)
                Console.WriteLine("\nМассив пуст!");
            else
            {
                Console.WriteLine("\nОдномерный массив:");
                for (int i = 0; i < oneDimensionalArray.Length; i++)
                {
                    Console.Write(oneDimensionalArray[i] + "  ");
                }
                Console.WriteLine();
            }
            MenuOneDimensionalArray();
        }
        static void DeleteElementsArray()
        {
            if (oneDimensionalArray.Length == 0)
                Console.WriteLine("\nМассив пуст!");
            else
            {
                bool isDone = false;
                for (int i = 0; i < oneDimensionalArray.Length; i++)
                {
                    if (oneDimensionalArray[i] % 2 == 0)
                    {
                        int[] temp = new int[oneDimensionalArray.Length - 1];
                        int k = 0;
                        for (int j = 0; j < oneDimensionalArray.Length; j++)
                        {
                            if (j != i)
                            {
                                temp[k] = oneDimensionalArray[j];
                                k++;
                            }
                        }
                        oneDimensionalArray = temp;
                        i--;
                        isDone = true;
                    }

                }
                if (isDone)
                    Console.WriteLine("\nУдаление произведено!");
                else
                    Console.WriteLine("\nЧетных элементов нет!");
            }
            MenuOneDimensionalArray();
        }
    }
}
