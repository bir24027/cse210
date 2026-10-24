public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    public Reference(string book, string chapter, string verse)
    {
        _book=book;
        _chapter=chapter;
        _verse=verse;
    }
    public string GetChapter()
    {
        return _chapter;
    }
    public void SetChapter(string chapter)
    {
        _chapter=chapter;
    }
    public string GetBook()
    {
        return _book;
    }
    public void SetBook(string book)
    {
        _book=book;
    }
    public string GetVerse()
    {
        return _verse;
    }
    public void SetVerse(string verse)
    {
        _verse=verse;
    }
    public string GetDisplayString()
    {
        string displayString=$"{_book} {_chapter}:{_verse}";
        return displayString;
    }
}