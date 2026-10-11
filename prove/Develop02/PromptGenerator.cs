using System.ComponentModel.DataAnnotations;

public class PromptGenerator
{
    public List <string> _promptList= new List<string>();
    public PromptGenerator()
    {
        _promptList.Add("Who is the most interesting person I interacted with today?");
        _promptList.Add("What was the best part of my day?");
        _promptList.Add("How did I see the hand of the Lord in my life today?");
        _promptList.Add("What was the strongest emotion I felt today?");
        _promptList.Add("If I had one thing I could do over today, what would it be?");
        _promptList.Add("What did I do out of the ordinary today?");
        _promptList.Add("What did I learn today, and how can I apply it to become a better person tommorrow?");
        _promptList.Add("What did I accomplish today?");
        _promptList.Add("What did I do to overcome my challenges today, and what challenges did I face?");
        _promptList.Add("What did I do today to help me come closer to Christ?");
    }
    public string RandomPrompt()
    {
        Random random= new Random();
        int length=0;
        foreach (string prompt in _promptList)
        {
            length++;
        }
        int randomNumber= random.Next(0,length-1);
        string randomPrompt=_promptList[randomNumber];
        return randomPrompt;
    }
}