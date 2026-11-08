using System;
using System.Net;
// I exceeded the requirements by adding what I have called the grounding activity, where you list 5 things you can see, 4 things you can touch, 3 things you can hear, 2 things you can taste, and 1 thing you can smell.
//I also added a logger. I learned how to append to a file by looking it up on Google.
class Program
{
    static bool DisplayMenu()
    {
        
        List<Activity> activities= new List<Activity>();
        activities.Add(new BreathingActivity(3,3));
        activities.Add(new ReflectingActivity());
        activities.Add(new ListingActivity());
        activities.Add(new GroundingActivity());
        int i=0;
        foreach(Activity activity in activities)
        {
            i++;
            Console.WriteLine($"{i}:{activity.GetTitle()}");
        }
        Console.WriteLine($"{activities.Count+1}:View Log");
        Console.WriteLine($"{activities.Count+2}:Exit");
        Console.Write("Please choose an option: ");
        string userInput= Console.ReadLine();
        int activityNumber= int.Parse(userInput);
        if (activityNumber==(activities.Count+1))
        {
            Log.DisplayLog();
        }
        else if (activityNumber==(activities.Count+2))
        {
            Console.WriteLine("Thank you for taking the time to use the mindfulness program!");
            return false;
        }
        else
        {
        Activity SelectedActivity= activities[activityNumber-1];
        SelectedActivity.StartActivity();
        }
        
        return true;

    }
    static void Main(string[] args)
    {
        Log.Initialize();
        Console.CursorVisible=false;
        bool operating=true;
        Log.Write("App started sucessfully.");
        do
        {
        try
        {
        
        operating=DisplayMenu();
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred...");
            Log.Write(ex.Message,"Error");
            Activity.Pause(5);
            Console.Write("Would you like to try to continue? (y for yes, n for no)");
            string _userResponse=Console.ReadLine();
            if (_userResponse=="y")
                {
                    operating=true;
                    try
                    {
                    Log.GetAction();
                    }
                    catch 
                    {
                        
                    }
                }
            else
                {
                    operating=false;
                }

        }
        }while (operating);
        Console.CursorVisible=true;
        Log.Write("App quited successfully");
    }
}