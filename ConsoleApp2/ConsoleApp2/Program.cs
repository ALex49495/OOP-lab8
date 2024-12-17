using System;
using System.Globalization;
using System.Text;

namespace FractionApp
{
    public class Number
    {
        public int Value { get; set; }

        public Number()
        {
            Value = 0;
            Console.WriteLine("Базовий конструктор за замовчуванням викликано.");
        }

        public Number(int value)
        {
            Value = value;
            Console.WriteLine("Базовий конструктор з параметром викликано.");
        }

        public Number(Number other)
        {
            Value = other.Value;
            Console.WriteLine("Базовий конструктор копіювання викликано.");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Number Value: {Value}");
        }
    }

    public class Fraction : Number
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() : base()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator) : base(numerator)
        {
            Numerator = numerator;
            Denominator = denominator != 0 ? denominator : 1;
        }

        public Fraction(Fraction other) : base(other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        public void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Fraction: {Numerator}/{Denominator} (скорочений вигляд)");
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : GCD(b, a % b);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Fraction operator +(Fraction a)
        {
            return a;
        }

        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (double)a > (double)b;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (double)a < (double)b;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return (double)a >= (double)b;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return (double)a <= (double)b;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static explicit operator double(Fraction f)
        {
            return (double)f.Numerator / f.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування консолі для української мови
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Продемонструвати роботу класу Fraction");
                Console.WriteLine("2. Вийти");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemonstrateFraction();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void DemonstrateFraction()
        {
            Fraction f1 = new Fraction();
            Fraction f2 = new Fraction(3, 4);
            Fraction f3 = new Fraction(f2);

            Console.WriteLine("\nКонструктори:");
            Console.WriteLine(f1);
            Console.WriteLine(f2);
            Console.WriteLine(f3);

            Console.WriteLine("\nАрифметичні операції:");
            Fraction sum = f2 + f3;
            Fraction diff = f2 - f3;
            Fraction product = f2 * f3;
            Fraction quotient = f2 / f3;

            Console.WriteLine($"Сума: {sum}");
            Console.WriteLine($"Різниця: {diff}");
            Console.WriteLine($"Добуток: {product}");
            Console.WriteLine($"Частка: {quotient}");

            Console.WriteLine("\nПорівняння:");
            Console.WriteLine(f2 > f1);
            Console.WriteLine(f2 == f3);

            Console.WriteLine("\nПеретворення до double:");
            Console.WriteLine((double)f2);

            Fraction f4 = new Fraction(8, 12);
            f4.Simplify();
            Console.WriteLine($"Скорочений дріб: {f4}");
        }
    }
}
