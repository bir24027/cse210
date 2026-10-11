using System;
//Extras
// Entries store and load the Operating System they were created on
// Entries calculate the amount of time since they were created
//10 Possible Prompts
// Entries store dates as DateTime objects
// If needed in the future, entries have a method to return the date they were created as a DateTime object
//Anything that I needed to learn I learned from google.com
class Program
{
    static void Main(string[] args)
    {
        Menu mainMenu= new Menu();
        mainMenu.Display();
    }
}