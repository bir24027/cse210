using System;
using System.Formats.Asn1;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        float number;
        List <float> numbers= new List<float>();
        do
        {
            Console.Write("Enter number: ");
            string answer=Console.ReadLine();
            number=float.Parse(answer);
            if (number!=0)
            {
                numbers.Add(number);
            }

            

        }while (number!=0);
        float total=0;
        float count=0;
        float largest=0;
        float smallest=numbers.Where(n=>n>0).Min();
        foreach (float i in numbers)
        {
            total+=i;
            count++;
            if (i>largest)
            {
                largest=i;
            }
            if (i>0)
            {
                
            }
        }
        float average=total/count;
        numbers.Sort();
        Console.WriteLine($"The sum is {total}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        Console.WriteLine("Here is the sorted list: ");
        foreach (float i in numbers)
        {
            Console.WriteLine(i);
        }
    }
}