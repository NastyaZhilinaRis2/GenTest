using System;

namespace ООП1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isStatusProg = true;
            do
            {
                ChooseEx();
                Console.WriteLine("Продолжить - 1, выйти - 0");
                int statusProg = InputIntervalInt(0, 1);
                switch (statusProg)
                {
                    case 0:
                        {
                            isStatusProg = false;
                            break;
                        }
                    case 1:
                        {
                            isStatusProg = true;
                            break;
                        }
                } 
            }
            while (isStatusProg);
        }
        //проверка на ввод числа типа int
        static int InputInt()
        {
            int number;
            bool isCorrectInput = true;
            do
            {
                string input;
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    isCorrectInput = false;
                }
                else Console.WriteLine("Неверный ввод!");
            }
            while (isCorrectInput);
            return number;
        }
        //проверка на ввод числа типа float
        static double InputDouble()
        {
            double number;
            bool isCorrectInput = true;
            do
            {
                string input;
                input = Console.ReadLine();
                if (double.TryParse(input, out number))
                {
                    isCorrectInput = false;
                }
                else Console.WriteLine("Неверный ввод!");
            }
            while (isCorrectInput);
            return number;
        }
        //проверка на ввод числа типа int из интервала от left до right
        static int InputIntervalInt(int left, int right)
        {
            bool isCorrectInput = true;
            int input;
            do
            {
                input = InputInt();
                if (left <= input && input <= right)
                    isCorrectInput = false;
                else Console.WriteLine($"Ввод должен находиться в интервале от {left} до {right}");
            }
            while (isCorrectInput);
            return input;
        }
        static void ChooseEx()
        {
            Console.WriteLine("Введите номер задания (1-3): ");
            int numberEx = InputIntervalInt(1, 3);
            switch (numberEx)
            {
                case 1:
                    {
                        FirstEx();
                        break;
                    }
                case 2:
                    {
                        SecondEx();
                        break;
                    }
                case 3:
                    {
                        ThirdEx();
                        break;
                    }
            }
        }
        static void FirstEx()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Установка кодировки UTF-8
            double m, n, x;
            Console.Write("m = ");
            m = InputDouble();
            Console.Write("n = ");
            n = InputDouble();

            Console.WriteLine("1) m + --n = " + (m + (--n)));

            Console.WriteLine("m = " + m + ", n = " + n);

            if (m++ < --n) Console.WriteLine("m++ < --n - True");
            else Console.WriteLine("2) m++ < --n  - False");

            Console.WriteLine("m = " + m + ", n = " + n);

            if (--m > n--) Console.WriteLine("3) --m > n-- - True");
            else Console.WriteLine("3) --m > n--  - False");

            Console.WriteLine("m = " + m + ", n = " + n);

            bool isCorrectInput = true;
            do
            {
                Console.Write("x = ");
                x = InputDouble();
                if (Math.Atan(Math.Pow(x, 2)) % Math.PI == 0)
                    Console.WriteLine($"ctg({x}) не существует!");
                if (Math.Pow(x, 3) + Math.Pow(x, 4) < 0)
                    Console.WriteLine($"Выражение под корнем не может быть отрицательным!");
                else isCorrectInput = false;
            }
            while (isCorrectInput);

            double outF = Math.Pow((Math.Pow(x, 3) + Math.Pow(x, 4)), 1d / 5d) + (1 / Math.Tan(Math.Atan(Math.Pow(x, 2))));

            Console.WriteLine($"4)⁵√(({x})⁴ + ({x})³) + ctg(arctg({x}²)) = {outF}");
            Console.WriteLine();
        }
        static void SecondEx()
        {
            Console.WriteLine("Введите X: ");
            double x = InputDouble();
            Console.WriteLine("Введите Y: ");
            double y = InputDouble();
            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 4)
            {
                if ((y + x) >= 2
                    || (y - x) >= 2
                    || (y + x) <= -2
                    || (y - x) <= -2)
                    Console.WriteLine("True!\n");
                else
                    Console.WriteLine("False!\n");
            }
            else
                Console.WriteLine("False!\n");
        }
        static void ThirdEx()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Установка кодировки UTF-8
            float a = 1000, b = 0.0001f, resultF;
            double resultD;
            resultF = (float)(((double)Math.Pow(a-b, 3) - (double)Math.Pow(a, 3))/((double)Math.Pow((-b), 3) + 3*a* (double)Math.Pow(b, 2) - 3* (double)Math.Pow(a, 2)*b));
            resultD = (double)((double)Math.Pow(a-b, 3) - (double)Math.Pow(a, 3))/((double)Math.Pow((-b), 3) + 3*a* (double)Math.Pow(b, 2) - 3*Math.Pow(a, 2)*b);
            Console.WriteLine($"Выражение:\n\n   (a-b)³ - (a³)\n __________________\n\n  -b³ + 3ab² - 3a²b\n\n");
            Console.WriteLine($"Результат для типа float: {resultF}");
            Console.WriteLine($"Результат для типа double: {resultD}\n");
        }
    }
}
