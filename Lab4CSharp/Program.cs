using System;

class Program
{
    static void Main(string[] args)
    {
        // Налаштування кодування
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool exit = false;

        while (!exit)
        {
            Console.Clear(); // Очищуємо екран для нового вибору
            Console.WriteLine("====================================================");
            Console.WriteLine("   МЕНЮ ЛАБОРАТОРНОЇ РОБОТИ №4");
            Console.WriteLine("====================================================");
            Console.WriteLine("1. Тестування Point (Завдання 1)");
            Console.WriteLine("2. Тестування VectorInt (Завдання 2)");
            Console.WriteLine("3. Тестування Відеокасет (Завдання 3)");
            Console.WriteLine("0. Вихід з програми");
            Console.WriteLine("====================================================");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "3":
                    Task3.Execute();
                    break;
                case "0":
                    exit = true;
                    continue; 
                default:
                    Console.WriteLine("Помилка: такого пункту немає.");
                    break;
            }

            Console.WriteLine("Завдання завершено. Зробіть скріншот зараз.");
            Console.WriteLine("Натисніть ENTER, щоб повернутися в меню...");
            Console.ReadLine();
        }
    }

    static void RunTask1()
    {
        Console.WriteLine("\n РЕЗУЛЬТАТ ЗАВДАННЯ 1 (Point) ");
        Point p = new Point(10, 10, 1);
        p.Display();
        p++;
        Console.Write("Після p++: "); p.Display();
    }

    static void RunTask2()
    {
        Console.WriteLine("\n  РЕЗУЛЬТАТ ЗАВДАННЯ 2 (VectorInt) ");
        VectorInt v = new VectorInt(3, 50);
        v.Display();
        VectorInt v2 = v + 10;
        Console.Write("Вектор + 10: "); v2.Display();
    }
}