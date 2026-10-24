using System.ComponentModel;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

public class Display
{
    private Scripture _scripture;
    private VerseDisplay _verseDisplay;
    public Display()
    {
        HandleInput();
        _verseDisplay= new VerseDisplay(_scripture);
    }
    public void ShowDisplay()
    {
        
        while (_verseDisplay.GetUnhiddenWords()!=-1)
        {
            string displayString=_verseDisplay.GetDisplayString();
            Console.WriteLine(displayString);
            Console.ReadLine();
            TestVerse();
            _verseDisplay.HideRandomWord();

        }

    }
    private void HandleInput()
    {
        Console.Write("Please input scripture in this format: Book Chapter#:Verses Verse Text: ");
        string userInput=Console.ReadLine();
        List <string> userInputList=userInput.Split(":").ToList();
        List <string> bookAndChapterList=userInputList[0].Split(" ").ToList();
        string book;
        string chapter;
        if (bookAndChapterList.Count>=3)
        {
             book="";
            for (int i=0; i<=bookAndChapterList.Count-2; i++)
            {
                book+=$"{bookAndChapterList[i]} ";
            }
            chapter=bookAndChapterList[bookAndChapterList.Count-1];
        }
        else
        {
             book=bookAndChapterList[0];
             chapter=bookAndChapterList[1];
        }
        List<string> verseNumberAndContentList= userInputList[1].Split(" ").ToList();
        string verseNumber=verseNumberAndContentList[0];
        string verseContent="";
        for (int i=1; i<verseNumberAndContentList.Count; i++)
        {
            verseContent+=$"{verseNumberAndContentList[i]} ";
        }
        Reference reference= new Reference(book, chapter, verseNumber);
        _scripture=new Scripture(reference, verseContent);


    }
    private void TestVerse()
    {
        List <char> chars= new List<char>();
        List<ConsoleColor> colors= new List<ConsoleColor>();
        List<List<int>> cursorList= new List<List<int>>();

    
        string DisplayString=_verseDisplay.GetDisplayStringForTest().Trim();
        foreach (char character in DisplayString)
        {
            chars.Add(character);
            colors.Add(ConsoleColor.White);
        }
        bool testing=true;
        int i=0;
        int j=0;
        Console.Clear();
            Console.WriteLine(_verseDisplay.GetReferenceDisplay());
            foreach (char character in chars)
            {
                int left= Console.CursorLeft;
                int top= Console.CursorTop;
                ConsoleColor consoleColor= colors[j];
                Console.ForegroundColor=consoleColor;
                Console.Write(character);
                List<int> location= new List<int>();
                location.Add(left);
                location.Add(top);
                cursorList.Add(location);
                j++;
                Console.ResetColor();
            }
        while (testing)
        {
            Console.CursorVisible=false;
            
            

            ConsoleKeyInfo keyInfo= Console.ReadKey(intercept:true);
            char pressedCharacter=keyInfo.KeyChar;
            
            if (_verseDisplay.TestCharacter(pressedCharacter,i))
            {
                Console.SetCursorPosition(cursorList[i][0],cursorList[i][1]);
                Console.ForegroundColor=ConsoleColor.Green;
                Console.Write(pressedCharacter);
                i++;
                if (i>=chars.Count)
                {
                    testing=false;
                }
            }
            else
            {
                Console.SetCursorPosition(cursorList[i][0],cursorList[i][1]);
                Console.ForegroundColor=ConsoleColor.Red;
                Console.Write(chars[i]);
            }


        }
        Console.CursorVisible=true;
        Console.ResetColor();
    }
}