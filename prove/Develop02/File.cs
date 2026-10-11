using System.Xml.Serialization;

public class File
{
    public static string _filePath;
    public static void GetFilePathFromUser()
    {
        Console.Write("Please enter a file path:");
        _filePath= Console.ReadLine()??"";
    }
    public static void Save(Journal journal)
    {
        GetFilePathFromUser();
        
        using (StreamWriter outputFile= new StreamWriter(_filePath))
        
        {
            foreach (Entry entry in journal._entries)
            {
                outputFile.Write($"{entry.GetDateString()}|{entry.GetPrompt()}|{entry.GetResponse()}| {entry.GetOSSaveString()}");
            }

        }
    }
    public static Journal Load()
    {
        GetFilePathFromUser();
        Journal journal=new Journal();
        string[] lines= System.IO.File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            string[] parts= line.Split("|");
            string date= parts[0].Trim();
            Console.WriteLine(date);
            string prompt=parts[1].Trim();
            string response=parts[2].Trim();
            string OS= parts[3].Trim();
            Entry entry = new Entry(date,prompt,response,OS);
            journal.AddEntry(entry);
        }
        return journal;
    }
}