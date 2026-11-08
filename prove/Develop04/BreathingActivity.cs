public class BreathingActivity: Activity
{
    private int _breathInTime;
    private int _breathOutTime;
    public BreathingActivity(int breathInTime, int breathOutTime): base("Breathing Activity","This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing",false)
    {
        _breathInTime=breathInTime;
        _breathOutTime=breathOutTime;
        SetOperatingFunction(Display);
    }
    private void Display()
    {
     BreathTimer();   
    }
    private void BreathTimer()
    {
        Console.WriteLine();
        Console.Write("Breathe in... ");
        for (int i=0; i<=_breathInTime; i++)
        {
            Console.Write(_breathInTime-i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        Console.Write("Breathe out...");
        for (int i=0; i<=_breathOutTime; i++)
        {
           Console.Write(_breathOutTime-i);
           Thread.Sleep(1000);
           Console.Write("\b \b"); 
        }
        Console.WriteLine();
    }
}