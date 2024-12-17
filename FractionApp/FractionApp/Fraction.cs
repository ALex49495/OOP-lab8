using System;

namespace FractionApp
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(Fraction other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);

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

        public static bool operator >(Fraction a, Fraction b) => (double)a > (double)b;
        public static bool operator >=(Fraction a, Fraction b) => (double)a >= (double)b;
        public static bool operator <=(Fraction a, Fraction b) => (double)a <= (double)b;
        public static bool operator <(Fraction a, Fraction b) => (double)a < (double)b;
        public static bool operator ==(Fraction a, Fraction b) => (double)a == (double)b;
        public static bool operator !=(Fraction a, Fraction b) => (double)a != (double)b;

        public static explicit operator double(Fraction a)
        {
            return (double)a.Numerator / a.Denominator;
        }

        public void Reduce()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Numerator: {Numerator}, Denominator: {Denominator}");
        }
    }
}
