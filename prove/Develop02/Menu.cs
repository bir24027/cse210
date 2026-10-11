using System.Collections;
using System.Net;

public class Menu
{
    public int _userInt;
    private bool _operating=true;
    public Journal _journal = new Journal();
    public void Display()
    {
        while (_operating)
        {
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("1: Write a Journal Entry");
            Console.WriteLine("2: Display all Journal Entries");
            Console.WriteLine("3: Save Current Journal");
            Console.WriteLine("4: Load Journal from a File");
            Console.WriteLine("5:Exit");
            _userInt=int.Parse(Console.ReadLine()??"5");
            if (_userInt==1)
            {
                Write();
            }
            if (_userInt==2)
            {
                Console.Write("Include Metadata? y/n ");
                string response=Console.ReadLine()??"n";
                DisplayJournal(response);
            }
            if (_userInt==3)
            {
                Save();
            }
            if (_userInt==4)
            {
                Load();
            }
            if (_userInt==5)
            {
                Exit();
            }

        }
    }
    public void Write()
    {
        PromptGenerator promptGenerator= new PromptGenerator();
        string prompt= promptGenerator.RandomPrompt();
        Console.WriteLine($"Here is your prompt: {prompt} Press Enter when finished.");
        string response =Console.ReadLine();
        Entry entry= new Entry();
        entry.StorePrompt(prompt);
        entry.StoreResponse(response);
        _journal.AddEntry(entry);

    }
    public void DisplayJournal(string response)
    {
        
        if (response=="y")
        {
            _journal.DisplayAllMetaDataIncluded();
        }
        else
        {
        _journal.DisplayAll();
        }

    }
    public void Save()
    {
        _journal.SaveToFile();
    }
    public void Load()
    {
        _journal= File.Load();
    }
    public void Exit()
    {
        _operating=false;
    }
}