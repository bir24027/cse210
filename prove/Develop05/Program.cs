// In order to exceed the requirements of this assignment, I added a logger in order to log any issues, as 
// well as anything else I feel like logging in the future. I also added an auto-save/load feature, which will save
// chosen save settings in a settings file in the app directory. I also allowed for use of the Native File Explorer
// for Windows, MacOS, and Linux. I also added a more user-friendly menu navigated using arrow keys and enter. 
//Everything I didn't know how to do I looked up on Google.
using System;
using NativeFileDialogNET;
class Program
{
    static void Main(string[] args)
    {
        try
        {
        Menu menu= new Menu();
        menu.Display();
        }
        catch (Exception e)
        {
          Log.Write(e.Message, System.Diagnostics.Tracing.EventLevel.Critical);  
          Log.WriteFull(e.ToString(), System.Diagnostics.Tracing.EventLevel.Critical);  
          throw;
        }
    }
}