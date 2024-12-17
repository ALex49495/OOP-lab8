using System;
using System.Collections.Generic;

namespace FractionApp
{
    class Program
    {
        static List<Fraction> fractions = new List<Fraction>();

        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("uk-UA");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Виберіть завдання:");
                Console.WriteLine("1. Створити об'єкти класу Fraction");
                Console.WriteLine("2. Показати інформацію про об'єкт");
                Console.WriteLine("3. Виконати арифметичні операції");
                Console.WriteLine("4. Виконати порівняння об'єктів");
                Console.WriteLine("5. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateFractions();
                        break;
                    case "2":
                        ShowInfo();
                        break;
                    case "3":
                        PerformArithmeticOperations();
                        break;
                    case "4":
                        CompareFractions();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        static void CreateFractions()
        {
            fractions.Add(new Fraction());
            fractions.Add(new Fraction(3, 4));
            fractions.Add(new Fraction(fractions[1]));

            Console.WriteLine("Фракції створено.");
        }

        static void ShowInfo()
        {
            foreach (var fraction in fractions)
            {
                fraction.ShowInfo();
            }
        }

        static void PerformArithmeticOperations()
        {
            if (fractions.Count >= 2)
            {
                var result1 = fractions[0] + fractions[1];
                var result2 = fractions[0] - fractions[1];
                var result3 = fractions[0] * fractions[1];
                var result4 = fractions[0] / fractions[1];

                Console.WriteLine($"Додавання: {result1}");
                Console.WriteLine($"Віднімання: {result2}");
                Console.WriteLine($"Множення: {result3}");
                Console.WriteLine($"Ділення: {result4}");
            }
            else
            {
                Console.WriteLine("Не достатньо фракцій для виконання операцій.");
            }
        }

        static void CompareFractions()
        {
            if (fractions.Count >= 2)
            {
                var result1 = fractions[0] > fractions[1];
                var result2 = fractions[0] >= fractions[1];
                var result3 = fractions[0] < fractions[1];
                var result4 = fractions[0] <= fractions[1];
                var result5 = fractions[0] == fractions[1];
                var result6 = fractions[0] != fractions[1];

                Console.WriteLine($"fractions[0] > fractions[1]: {result1}");
                Console.WriteLine($"fractions[0] >= fractions[1]: {result2}");
                Console.WriteLine($"fractions[0] < fractions[1]: {result3}");
                Console.WriteLine($"fractions[0] <= fractions[1]: {result4}");
                Console.WriteLine($"fractions[0] == fractions[1]: {result5}");
                Console.WriteLine($"fractions[0] != fractions[1]: {result6}");
            }
            else
            {
                Console.WriteLine("Не достатньо фракцій для порівняння.");
            }
        }
    }
}
