using System.Runtime.CompilerServices;

public class Word
{
    private string _word;
    private bool _hidden;
    public Word(string word)
    {
        _word=word;
    }
    public void SetWord(string word)
    {
        _word=word;
    }
    public string GetDisplayWord()
    {
        string displayString="";
        if (_hidden)
        {
            foreach (char letter in _word)
            {
                displayString=displayString+"_";
            }
        }
        else
        {
            displayString=_word;
        }
        return displayString;
    }
    public string GetWord()
    {
        return _word;
    }
    public void HideWord()
    {
        _hidden=true;
    }
    public bool isHidden()
    {
        return _hidden;
    }
}