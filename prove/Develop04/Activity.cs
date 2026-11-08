using System.Runtime.CompilerServices;

public class Activity
{
    private string _activityName;
    private string _activityDescription;
    protected int _activityDuration=0;
    private int _completedTimes=0;
    
    private Action _operatingFunction;
    private Action _endFunction;
    private bool _cursor;
    public Activity(string activityName, string activityDescription, bool cursor)
    {
        _activityName=activityName;
        _activityDescription=activityDescription;
        _cursor=cursor;
        

    }
    protected void SetOperatingFunction(Action OperatingFunction)
    {
        _operatingFunction=OperatingFunction;
    }
    public static void Pause(int pauseDuration, bool activeCursor=false)
    {
        if (activeCursor)
        {
            Console.CursorVisible=false;
        }
        DateTime startTime=DateTime.Now;
        DateTime endTime=startTime.AddSeconds(pauseDuration);
        int i=0;
        List<string> animationStrings=new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        while (DateTime.Now<endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
            if (i>=animationStrings.Count)
            {
                i=0;
            }
        }
        if (activeCursor)
        {
            Console.CursorVisible=true;
        }

    }
    protected void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}.\n {_activityDescription}");
    }
    protected void DisplayFinishedMessage()
    {
        Console.WriteLine($"You have completed {_activityDuration} seconds of the {_activityName}");
    }
    public void StartActivity()
    {
        Log.SetAction(StartActivity);
        Console.Clear();
        Log.Write($"Starting {_activityName}");
        DisplayStartMessage();
        _activityDuration=PromptForDuration();
        Console.WriteLine("Get Ready...");
        Pause(5);
        Console.Clear();
        Console.Write("\x1b[3J");
        Console.CursorVisible=_cursor;
        Log.SetAction(Timer);
        Timer();
        _completedTimes++;
        Console.Clear();
        Console.Write("\x1b[3J");
        EndActivity();
        
    }
    protected void DisplayDuration()
    {
        Console.WriteLine(_activityDuration);
    }
    private int PromptForDuration()
    {
        int inputNumber=0;
        while (inputNumber==0)
        {
        try
        {
            Console.WriteLine("Please enter how long you would like to spend on this activity in seconds: ");
            string userInput=Console.ReadLine();
            inputNumber=int.Parse(userInput);
        }
        catch(FormatException)
        {
            Console.Write("Incorrect value entered. Please try again.");
        }
        } 
        return inputNumber;
    }
    private void Timer()
    {
        DateTime startTime=DateTime.Now;
        DateTime endTime=startTime.AddSeconds(_activityDuration);
        do
        {
        _operatingFunction();
        }while (DateTime.Now<endTime);

    }
    protected void SetEndFunction(Action endFunction)
    {
        _endFunction=endFunction;
    }
    private void EndActivity()
    {
        if (_endFunction!=null)
        {
        _endFunction();
        }
        Console.CursorVisible=false;
        Console.WriteLine("Good job!");
        Pause(5);
        DisplayFinishedMessage();
        Log.Write($"Finished {_activityDuration} seconds of {_activityName}");
    }
    public string GetTitle()
    {
        return _activityName;
    }
    public int GetTimesCompleted()
    {
        return _completedTimes;
    }
}