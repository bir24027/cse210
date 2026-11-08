class ListingActivity : Activity
{
    private List<string> _listingPrompts= new List<string>();
    private List<string> _entries= new List<string>();
    private int _entry;
    public ListingActivity(): base("Listing Activity","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",true)
    {
        SetOperatingFunction(PromptUser);
        SetEndFunction(DisplayTypedEntries);
        _listingPrompts.Add("Who are people that you appreciate?");
        _listingPrompts.Add("What are personal strengths of yours?");
        _listingPrompts.Add("Who are people that you have helped this week?");
        _listingPrompts.Add("When have you felt the Holy Ghost this month?");
        _listingPrompts.Add("Who are some of your personal heroes?");
    }
    public void PromptUser()
    {
        if (_entry==0)
        {
            Random random= new Random();
            string randomQuestion=_listingPrompts[random.Next(_listingPrompts.Count-1)];
            Console.WriteLine(randomQuestion);
            Pause(5);
            _entry++;
        }
        Console.Write("<");
        GetUserInput();
        _entry++;


    }
    private void GetUserInput()
    {
        string entry=Console.ReadLine();
        _entries.Add(entry);
    }
    private void DisplayTypedEntries()
    {
        Console.WriteLine($"You typed {GetEntryQuantity()} entries.");
    }
    private int GetEntryQuantity()
    {
        return _entries.Count;
    }
}