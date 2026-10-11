public class Journal
{
    public List <Entry> _entries= new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry.GetDateString()}");
            Console.WriteLine($"Prompt: {entry.GetPrompt()}");
            Console.WriteLine($"Response: {entry.GetResponse()}");
        }
    }
    public void DisplayAllMetaDataIncluded()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Prompt: {entry.GetPrompt()}");
            Console.WriteLine($"Response: {entry.GetResponse()}");
            Console.WriteLine($"Date: {entry.GetDateString()}");
            Console.WriteLine($"Time since entry: {entry.GetTimePassed()}");
            Console.WriteLine($"OS that the entry was created on: {entry.GetOSString()}");
        }
    }
    public void SaveToFile()
    {
        File.Save(this);
    }
    public static Journal LoadFromFile()
    {
        Journal journal= File.Load();
        return journal;
    }

}