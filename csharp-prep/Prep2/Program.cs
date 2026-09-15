using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string gradeString=Console.ReadLine();
        int grade=int.Parse(gradeString);
        string gradeLetter;
        if (grade>=90)
        {
            gradeLetter="A";
        }
        else if (grade>=80)
        {
            gradeLetter="B";
        }
        else if (grade>=70)
        {
            gradeLetter="C";
        }
        else if(grade>=60)
        {
            gradeLetter="D";
        }
        else
        {
            gradeLetter="F";
        }
        int gradeLastDigit= grade%10;
        string sign;
        if (gradeLastDigit>=7)
        {
            sign="+";
        }
        else if (grade<3)
        {
            sign="-";
        }
        else
        {
            sign="";
        }
        if (gradeLetter=="A"&& sign=="+")
        {
            sign="";
        }
        else if (gradeLetter=="F"&&(sign=="+"||sign=="-"))
        {
            sign="";
        }
        Console.WriteLine($"Your grade is {gradeLetter}{sign}");
        if (grade>=70)
        {
            Console.WriteLine("Congrulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass, just keep trying and you will get it!");
        }
    }
}