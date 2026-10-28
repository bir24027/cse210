using System;

class Program
{
    static void Main(string[] args)
    {
       Assignment assignment= new Assignment("Will Birch", "Stats");
       Console.WriteLine(assignment.GetSummary());
       MathAssignment mathAssignment= new MathAssignment("Will Birch","Stats","1.1","#1-15");
       Console.WriteLine(mathAssignment.GetSummary());
       Console.WriteLine(mathAssignment.GetHomeworkList());
       WritingAssignment writingAssignment= new WritingAssignment("Mary Waters", "European History","The Causes of World War II");
       Console.WriteLine(writingAssignment.GetSummary());
       Console.WriteLine(writingAssignment.GetWritingInformation());
    }

}