
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Menu
{
    Dictionary <string,Action> _options = new Dictionary<string, Action>();
    FileManager _fileManager = new FileManager();
    GoalList _goalList = new GoalList();
    Settings _settingsManager;
    bool _exit= false;

    public Menu()
    {
        _settingsManager =new Settings(this);
        _options.Add("Create Goal",CreateGoal);
        _options.Add("Complete Goal",CompleteGoal);
        _options.Add("View Goals",DisplayGoals);
        _options.Add("Save",Save);
        _options.Add("Load",Load);
        _options.Add("Settings",_settingsManager.SettingsEditor);
        _options.Add("Exit",Exit);
        
    }
    public void Load(GoalList goalList)
    {
        _goalList=goalList;
    }
    public void Display()
    {
        while (!_exit)
        {
            Action selection = DisplayMenu(_options, $"You currently have {_goalList.GetPoints()} points.");
            Console.Clear();
            Console.Write("\x1b[3J");
            selection();
            if (!_exit)
            {
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
            }
            _settingsManager.SettingsManager(_goalList);
        }

    }
    public static Action DisplayMenu(Dictionary <string, Action> options, string topMessage)
    {
        int i = 0;
        int selected = 0;
        string startString;
        string endString;
        void emptyAction()
        {
            
        }
        Action selectedAction = emptyAction;
        List <Action> actions = new List<Action>();
        foreach(KeyValuePair<string,Action> option in options)
        {
            actions.Add(option.Value);
        }

        Console.CursorVisible = false;
        
        bool optionSelected = false;
        while(!optionSelected)
        {
        Console.Clear();
        Console.Write("\x1b[3J");
        Console.WriteLine(topMessage);
        i=0;
        foreach (KeyValuePair<string,Action> option in options)
        {  
            startString = "  ";
            endString = "  ";
            if (i==selected)
            {
                Console.BackgroundColor= ConsoleColor.White;
                Console.ForegroundColor= ConsoleColor.Black;
                startString = ">>";
                endString = "<<";
            }
            Console.WriteLine($"{startString}{option.Key}{endString}");
            i++;
            Console.ResetColor();
        } 
        ConsoleKeyInfo keyInfo =Console.ReadKey(intercept:true);
        ConsoleKey key= keyInfo.Key;
        if (key == ConsoleKey.UpArrow)
        {
            selected--;
            if (selected <= -1)
            {
                selected = options.Count-1;
            }
        }
        else if(key == ConsoleKey.DownArrow)
        {
            selected++;
            if (selected >= options.Count)
            {
                selected=0;
            }
        }
        else if(key == ConsoleKey.Enter)
        {
            optionSelected = true;
             selectedAction = actions[selected];
        }
        else if(key==ConsoleKey.Escape)
            {
                optionSelected = true;
            }
        }
        Console.CursorVisible = true;
        return selectedAction;
    }
    private void Save()
    {
        Console.Write("Please enter a file path (leave blank for file dialog or type Default for default location): ");
        string filePath = Console.ReadLine()??"";
        try
        {
            _fileManager.Save(_goalList,filePath);
        }
        catch (Exception exception)
        {
            if ( FileManager.GetKnownExceptions().Contains(exception))
            {
                Console.WriteLine("File Operation Canceled.");

            }
            else
            {
                throw;
            }
        }

    }
    private void Load()
    {
        try
        {
            Console.Write("Please enter a file path (leave blank for file dialog or type Default for default location): ");
            string filePath=Console.ReadLine()??"";
            _goalList = _fileManager.Load(filePath);
        }
        catch (Exception exception)
        {
            if ( FileManager.GetKnownExceptions().Contains(exception))
            {
                Console.WriteLine("File Operation Canceled.");

            }
            else
            {
                throw;
            }
        }

    }
    private void Exit()
    {
        _exit = true;
    }
    private void CreateGoal()
    {
        Dictionary<string, Action> goalOptions = new Dictionary<string, Action>();
        goalOptions.Add("Simple Goal",CreateSimpleGoal);
        goalOptions.Add("Checklist Goal",CreateChecklistGoal);
        goalOptions.Add("Eternal Goal", CreateEternalGoal);
        Action CreateGoalType = DisplayMenu(goalOptions, "Which type of goal would you like to create?");
        CreateGoalType();

    }
    private void CreateSimpleGoal()
    {
        AddGoal("Simple");
    }
    private void CreateChecklistGoal()
    {
        AddGoal("Checklist");
    }
    private void CreateEternalGoal()
    {
        AddGoal("Eternal");
    }
    private void AddGoal(string goalType)
    {
       Console.CursorVisible=true; 
       Console.Write($"Please enter the name of the new {goalType} goal: ");
       string name = Console.ReadLine()??"";
       Console.Write("Please enter the description of the goal: ");
       string description = Console.ReadLine()??"";
       bool pointsCompletedSuccessfully = false;
       int points = 0;
       do{
        try{
        Console.Write($"How many points is it worth? ");
        points = int.Parse(Console.ReadLine()??"0");
        pointsCompletedSuccessfully = true;
        }
        catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number!");
            }
       }while (!pointsCompletedSuccessfully);
       if (goalType == "Checklist")
        {
            Console.Write("How many times should it be completed before you get the bonus? ");
            int timesRequired = int.Parse(Console.ReadLine()??"1");
            Console.Write("How many bonus points? ");
            int bonus = int.Parse(Console.ReadLine()??"0");
            _goalList.AddGoal(new ChecklistGoal(name, description, points, bonus, timesRequired));

        }
        else if (goalType == "Simple")
        {
            _goalList.AddGoal(new SimpleGoal(name,description,points));
        }
        else if (goalType == "Eternal")
        {
            _goalList.AddGoal(new EternalGoal(name,description,points));
        }

        Console.CursorVisible=false;
    }
    private void CompleteGoal()
    {
        Dictionary <string, Action> completeOptions = new Dictionary<string, Action>();
        try
        {
            foreach(Goal goal in  _goalList.GetGoalList())
            {
                void CompleteSelectedGoal()
                {
                    _goalList.CompleteGoal(goal);
                }
                completeOptions.Add(goal.GetName(),CompleteSelectedGoal);
            }
            DisplayMenu(completeOptions,"Select a goal to complete.")();

        }
        catch (Exception)
        {
            Console.WriteLine("No goals are created yet!");
        }
    }
    private void DisplayGoals()
    {
        foreach (Goal goal in _goalList.GetGoalList())
        {
            goal.Display();
        }
        Console.ReadLine();
    }
}