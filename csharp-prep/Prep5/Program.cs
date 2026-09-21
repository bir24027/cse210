using System;
using System.Data;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name=Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        int number=0;
        bool sucess=false;
        do
        {
            try
            {
                Console.Write("Please enter your favorite number: ");
                string numberString=Console.ReadLine();
                number=int.Parse(numberString);
                sucess=true;
            }
            catch (FormatException)
            {
                Console.WriteLine("That input is not a correctly formatted number. Please try again.");

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You cannot input nothing! Please try again.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is out of bounds. Please pick a different number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured.");
                Console.WriteLine("Exception message: "+ ex.Message);
            }
        }while (sucess==false);

        return number;
    }
    static void PromptUserBirthYear(ref int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        string yearString=Console.ReadLine();
        birthYear=int.Parse(yearString);        
    }
    static int SquareNumber(int number)
    {
        int squaredNumber=number*number;
        return squaredNumber;
    }
    static void DisplayResult(string name, int squaredNumber,int birthYear)
    {
        string yearString=DateTime.Today.ToString("yyyy");
        int year=int.Parse(yearString);
        int age=year-birthYear;
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {age} this year.");
    }
        static void Main(string[] args)
    {
        DisplayWelcome();
        string name=PromptUserName();
        int number=PromptUserNumber();
        int birthYear=0;
        PromptUserBirthYear(ref birthYear);
        int squaredNumber=SquareNumber(number);
        DisplayResult(name,squaredNumber,birthYear);
    }

}