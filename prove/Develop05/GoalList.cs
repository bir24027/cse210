public class GoalList
{
    private List<Goal> _goalList = new List<Goal>();
    private int _pointsEarned;
    private List<Milestone> _milestonesEarned = new List<Milestone>();
    private List<Milestone> _existingMilestones= new List<Milestone>();
    public GoalList()
    {
        InitializeExistingMilestones();
    }
    public GoalList(string[] saveData)
    {
        InitializeExistingMilestones();
        foreach (string data in saveData)
        {
            string[] lineData= data.Split("|");
            string type=lineData[0];
            if (type =="Points")
            {
            }
            else if (type == "Goal")
            {
                
            }
            else if (type == "Earned Milestone")
            {
                
            }
            else
            {
                throw new Exception("Invalid Save File!");
            }
        }
        foreach (string data in saveData)
        {
            string[] lineData= data.Split("|");
            if(lineData[0] == "Points")
            {
                _pointsEarned = int.Parse(lineData[1]);
            }
            else if(lineData[0] == "Goal")
            {
                string[] goalData=lineData[1].Split(":");
                if (goalData[0] == "Simple")
                {
                    _goalList.Add(new SimpleGoal(lineData[1]));
                }
                else if (goalData[0]=="Checklist")
                {
                    _goalList.Add(new ChecklistGoal(lineData[1]));
                }
                else if(goalData[0]=="Eternal")
                {
                    _goalList.Add(new EternalGoal(lineData[1]));
                }
            }
            else if(lineData[0]=="Earned Milestone")
            {
                _milestonesEarned.Add(new Milestone(lineData[1]));
            }

        }   
    }
    public string GetSaveInfo()
    {
       string saveInfo="";
       saveInfo+=$"Points|{_pointsEarned}\n";
        foreach(Goal goal in _goalList)
        {
            saveInfo += $"Goal|{goal.GetSaveInfo()}";
        }
        foreach (Milestone milestone in _milestonesEarned)
        {
            saveInfo += $"Earned Milestone|{milestone.GetSaveInfo()}";
        }
       return saveInfo;
    }
    public void CompleteGoal(Goal goal)
    {
        _pointsEarned+=goal.Complete();
        foreach (Milestone milestone in _existingMilestones)
        {
            if (_milestonesEarned.Contains(milestone))
            {
                
            }
            else if(_pointsEarned>=milestone.GetPointRequirements())
            {
                milestone.Award();
                _milestonesEarned.Add(milestone);
            }
        }

    }
    private void InitializeExistingMilestones()
    {
        _existingMilestones.Add(new Milestone("Novice",10));

    }
    public int GetPoints()
    {
        return _pointsEarned;
    }
    public List<Goal> GetGoalList()
    {
        return _goalList;
    }
    public void AddGoal(Goal goal)
    {
        _goalList.Add(goal);
        
    }


}