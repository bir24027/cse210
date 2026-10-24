using System.Collections.Specialized;

public class VerseDisplay
{
    private List <Word> _words= new List<Word>();
    private List<Word> _hiddenWords= new List<Word>();
    private int _unhiddenWords;
    private Reference _reference;
    public VerseDisplay(Scripture scripture)
    {
       _reference=scripture.GetReference();
       string verseText=scripture.GetVerse();
        List <string> words=scripture.GetWordList();
        foreach (string stringWord in words)
        {
            Word word= new Word(stringWord);
            _words.Add(word);
        }
        _unhiddenWords=_words.Count-1;
    }
    public void HideRandomWord()
    {
        int numberOfWords= _words.Count;
        Random random= new Random();
        Word word;
        do
        {
            int randomNumber=random.Next(0,numberOfWords-1);
            word= _words[randomNumber];
        }while (_hiddenWords.Contains(word));
        _hiddenWords.Add(word);
        word.HideWord();
        _unhiddenWords--;

    }
    public string GetDisplayString()
    {
        string DisplayString=$"{_reference.GetDisplayString()}\n";
        foreach (Word word in _words)
        {
            DisplayString+=$"{word.GetDisplayWord()} ";   
        }
        return DisplayString;
    }
    public string GetDisplayStringForTest()
    {
        string DisplayString="";
        foreach (Word word in _words)
        {
            DisplayString+=$"{word.GetDisplayWord()} ";   
        }
        return DisplayString;
    }
    private string GetString()
    {
        string DisplayString=$"";
        foreach (Word word in _words)
        {
            DisplayString+=$"{word.GetWord()} ";   
        }
        return DisplayString;
    }
    public bool TestCharacter(char letter, int i)
    {
        char correctLetter=GetString()[i];
        return letter==correctLetter;
    }
    public int GetUnhiddenWords()
    {
        return _unhiddenWords;
    }
    public void SetUnhiddenWords(int unhiddenWords)
    {
        _unhiddenWords=unhiddenWords;   
    }
    public string GetReferenceDisplay()
    {
        return _reference.GetDisplayString();    
        }

}