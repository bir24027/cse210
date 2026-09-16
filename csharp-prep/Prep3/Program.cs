using System;
using System.Globalization;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator=new Random();
        string continuePlay;
        do
        {
        int number=randomGenerator.Next(0,100);
        int guess;
        string answer;
        int guesses=0;
        do
        {
            guesses++;
            Console.Write("What is your guess? ");
            answer=Console.ReadLine();
            guess=int.Parse(answer);
            if (guess>number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess<number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess==number)
            {
                Console.WriteLine("Your guess is correct!");
            }
        }while(guess!=number);
        Console.WriteLine($"You guessed {guesses} times.");
        Console.Write("Do you want to play again?");
        continuePlay=Console.ReadLine();
        }while (continuePlay=="Yes");
    }
}