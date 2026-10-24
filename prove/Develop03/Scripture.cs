public class Scripture
{
    private Reference _reference;
    private string _verse;
    public Scripture(Reference reference, string verse)
    {
        _reference=reference;
        _verse=verse;
    }
    public string GetVerse()
    {
        return _verse;
    }
    public Reference GetReference()
    {
        return _reference;
    }
    public void SetVerse(string verse)
    {
        _verse=verse;
    }
    public void SetReference(Reference reference)
    {
        _reference=reference;
    }
    public List<string> GetWordList()
    {
        List<string> wordList=_verse.Split(" ").ToList();
        return wordList;
    }

}