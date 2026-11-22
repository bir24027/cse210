public class EternalGoal : Goal
{
    int _timesCompleted = 0;
    public EternalGoal(string name,string description, int pointValue):base(name,description, pointValue,"Eternal")
    {
        
    }
    public EternalGoal(string saveInfo):base(saveInfo)
    {
        string[] saveData = saveInfo.Split(":");
        _timesCompleted = int.Parse(saveData[5]);
    }
    public override void Display()
    {
        Console.WriteLine(GetDisplayString()+$": Completed {_timesCompleted} Times" );
    }
    public override int Complete()
    {
        _timesCompleted++;
        return _pointValue;
    }
    public override string GetSaveInfo()
    {
        string saveString= base.GetSaveInfo();
        saveString += $":{_timesCompleted}";
        return saveString;
    }
}