using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

public class Log
{
    private static List<string> log= new List<string>();
    private static Action _currentAction;
    public static void SetAction(Action action)
    {
        _currentAction=action;
    }
    public static Action GetAction()
    {
        return _currentAction;
    }
    public static void Initialize()
    {
        try
        {
            log=File.ReadAllLines("MindfulnessProgram.log").ToList();
            
        }
        catch
        {
            
        }
        Write("App Starting...");        

    }
    public static void Write(string content, string level="Info")
    {
        string color="\u001b[32m";
        string resetColor="\u001b[0m";

        if (level=="Warning")
        {
            color="\u001b[33m";
        }
        else if (level=="Error")
        {
            color="\u001b[31m";
        }
        DateTime currentTime= DateTime.Now;
        string logLine=$"{color}[{level}]{resetColor}{currentTime.ToString("yyyy-MM-dd HH:mm:ss")} : {content}";
        log.Add(logLine);
       using( StreamWriter logFile= new StreamWriter("MindfulnessProgram.log",true))
        {
            logFile.WriteLine(logLine);
        }
    }
    public static void DisplayLog()
    {
        Console.Clear();
        Console.Write("\x1b[3J");

        foreach (string line in log)
        {
            Console.WriteLine(line);
        }
        Console.Write("Press Enter to Continue.");
        Console.ReadLine();
        Console.Clear();
        Console.Write("\x1b[3J");

    }
}