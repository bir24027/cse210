public class SimpleGoal:Goal
{
    public SimpleGoal(string name,string description, int pointValue): base(name, description, pointValue, "Simple")
    {
        
    }
    public SimpleGoal(string saveInfo):base(saveInfo)
    {
        
    }
    public override void Display()
    {
        Console.WriteLine(GetDisplayString());
    }
}