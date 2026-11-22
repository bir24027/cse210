using System.ComponentModel;
using System.Diagnostics.Tracing;

public class Log()
{
    public static void Write(string message, EventLevel eventLevel)
    {
        using (StreamWriter log= new StreamWriter("goalprogram.log",true))
        {
            log.WriteLine($"{DateTime.Now} [{eventLevel.ToString()}]: {message}");
        }
        WriteFull(message,eventLevel);
    }
    public static void WriteFull(string message, EventLevel eventLevel)
    {
        using (StreamWriter log= new StreamWriter("goalprogramfull.log",true))
        {
            log.WriteLine($"{DateTime.Now} [{eventLevel.ToString()}]: {message}");
        }
        
    }
}