public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _timesCompleted=0;
    private int _completionRequirement;

    public ChecklistGoal(string name,string description, int pointValue, int bonus, int completionRequirement) :base(name,description, pointValue, "Checklist")
    {
        _completionRequirement = completionRequirement;
        _bonus = bonus;
    }
    public ChecklistGoal(string saveInfo):base(saveInfo)
    {
        string[] saveData = saveInfo.Split(":");
        _completionRequirement = int.Parse(saveData[5]);
        _bonus = int.Parse(saveData[6]);
        _timesCompleted = int.Parse(saveData[7]);
    }
    public override void Display()
    {
        string startingDisplayString = GetDisplayString();
        Console.WriteLine($"{startingDisplayString} - Completed {_timesCompleted} of {_completionRequirement} times.");
    }
    public override string GetSaveInfo()
    {
        string saveString= base.GetSaveInfo();
        saveString += $":{_completionRequirement}:{_bonus}:{_timesCompleted}";
        return saveString;
    }
    public override int Complete()
    {
         int points = _pointValue;
         _timesCompleted ++;
         if (_timesCompleted == _completionRequirement)
        {
            points+=_bonus;
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("Good Job!");
            Console.ResetColor();
        }
        return points;
    }
}