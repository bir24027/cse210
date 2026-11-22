using System.ComponentModel;

public abstract class Goal
{
    protected bool _completed;
    protected string _name;
    protected int _pointValue;
    protected string _goalType;
    protected string _description;
    public Goal(string saveInfo)
    {
        string[] saveData= saveInfo.Split(":");
        _goalType=saveData[0];
        _name=saveData[1];
        _description=saveData[2];
        _pointValue=int.Parse(saveData[3]);
        _completed=bool.Parse(saveData[4]);
    }
    public Goal(string name,string description, int pointValue, string goalType)
    {
        _name = name;
        _pointValue = pointValue;
        _goalType = goalType;
        _description = description;
        _completed = false;
    }
    public virtual int Complete()
    {
        _completed=true;
        return _pointValue;    
    }
    public virtual string GetSaveInfo()
    {
        return $"{_goalType}:{_name}:{_description}:{_pointValue}:{_completed}\n";   
    }
    public string GetName()
    {
        return _name;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }
    protected string GetDisplayString()
    {
        string checkboxString="[ ]";
        if (_completed)
        {
            checkboxString="[X]";
        }
        return $"{checkboxString} {_name}- {_description}";
    }
    public abstract void Display();
}