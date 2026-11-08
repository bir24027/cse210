public class GroundingActivity:Activity
{
    private Dictionary<int,string> _prompts=new Dictionary<int, string>();
    private int _currentPrompt=5;
    public GroundingActivity():base("Grounding Activity", "This activity will help you become more aware of your surroundings and help you calm a stressed mind.",true)
    {
        SetOperatingFunction(Display);
        _prompts.Add(5,"List 5 things you can see");
        _prompts.Add(4, "List 4 things you can touch or feel.");
        _prompts.Add(3,"List 3 things you can hear.");
        _prompts.Add(2, "List 2 things you can smell.");
        _prompts.Add(1, "List 1 thing you can taste.");
    }
    private void Display()
    {
        string prompt=_prompts[_currentPrompt];
        PromptAndCollectInput(prompt, _currentPrompt);
        _currentPrompt--;
        if (_currentPrompt<=0)
        {
            _currentPrompt=5;
        }
    }
    private void PromptAndCollectInput(string prompt, int number)
    {
        Console.WriteLine(prompt);
        for(int i=0; i<number; i++)
        {
            Console.ReadLine();
        }
    }
}