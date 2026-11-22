public class Milestone
{
    private string _name;
    private int _pointCost;
    public Milestone(string name, int pointCost)
    {
        _name=name;
        _pointCost=pointCost;
    }
    public Milestone(string saveString)
    {
        string[] saveInfo=saveString.Split(":");
        _name=saveInfo[0];
        _pointCost=int.Parse(saveInfo[1]);

    }
    public string GetName()
    {
        return _name;
    }
    public int GetPointRequirements()
    {
        return _pointCost;
    }
    public string GetSaveInfo()
    {
        return $"{_name}:{_pointCost}\n";
    }
    public void Award()
    {
        Console.WriteLine($"Congratulations! You have earned the {_name} award! (Press Enter to Continue)");
        Console.ReadLine();

    }
}