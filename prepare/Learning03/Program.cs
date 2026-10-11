using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber=new Random();
        int count=0;
        int times=20;
        List<Fraction> fractions=new List<Fraction>();
        do
        {
            fractions.Add(new Fraction());
            Fraction fraction=fractions[count];
            fraction.SetTop(randomNumber.Next(0,100));
            fraction.SetBottom(randomNumber.Next(0,100));
            count++;
            Console.WriteLine($"Fraction {count}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
        }while (count!=times);
    }
}