public class ReflectingActivity:Activity
{
    private List<string> _questions= new List<string>();
    private List<string>_followUpQuestions= new List<string>();
    private int _questionNumber=0;
    public ReflectingActivity():base("Reflecting Activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",true)
    {
        SetOperatingFunction(Display);
        _questions.Add("Think of a time when you stood up for someone else.");
        _questions.Add("Think of a time when you did something really difficult.");
        _questions.Add("Think of a time when you helped someone in need.");
        _questions.Add("Think of a time you helped someone in need.");
        _questions.Add("Think of a time when you did something truly selfless.");
        _followUpQuestions.Add("Why was this experience meaningful to you?");
        _followUpQuestions.Add("Have you ever done anything like this before?");
        _followUpQuestions.Add("How did you get started?");
        _followUpQuestions.Add("How did you feel when it was complete?");
        _followUpQuestions.Add("What made this time different than other times when you were not as successful?");
        _followUpQuestions.Add("What is your favorite thing about this experience?");
        _followUpQuestions.Add("What could you learn from this experience that applies to other situations?");
        _followUpQuestions.Add("What did you learn about yourself through this experience?");
        _followUpQuestions.Add("How can you keep this experience in mind in the future?");

    }
    private void Display()
    {
        if (_questionNumber==0)
        {
            DisplayQuestion(_questions);
        }
        else
        {
            DisplayQuestion(_followUpQuestions);
        }
        GetUserInput();
        _questionNumber++;
        Pause(5);
    }
    private void DisplayQuestion(List <string> questions)
    {
        Random random= new Random();
        string randomQuestion=questions[random.Next(questions.Count-1)];
        Console.WriteLine(randomQuestion);
    }
    private void GetUserInput()
    {
        Console.ReadLine();
    }
}