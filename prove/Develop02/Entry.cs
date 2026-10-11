public class Entry
{
    public DateTime _date= DateTime.Now;
    public string _prompt;
    public string _response;
    public OperatingSystem _os;
    public Entry()
    {
        _os=Environment.OSVersion;
    }
    public Entry(string date, string prompt, string response,string OS)
    {
        string [] details= OS.Split("/");
        PlatformID platform=(PlatformID)Enum.Parse(typeof(PlatformID),details[0], ignoreCase:true);
        Version version= Version.Parse(details[1]);
        _date= DateTime.Parse(date);
        _prompt=prompt;
        _response=response;
        _os= new OperatingSystem(platform,version);
    }
    public void StorePrompt(string prompt)
    {
        _prompt=prompt;
    }
    public void StoreResponse(string response)
    {
        _response=response;
    }
    public string GetResponse()
    {
        return _response;
    }
    public string GetPrompt()
    {
        return _prompt;
    }
    public string GetDateString()
    {
        string dateString= _date.ToString();
        return dateString;
    }
    public DateTime GetDate()
    {
        return _date;
    }
    public TimeSpan GetTimePassed()
    {
        DateTime now= DateTime.Now;
        TimeSpan passedTime= now-_date;
        return passedTime;
    }
    public string GetOSSaveString()
    {
        string SaveString=$"{_os.Platform}/{_os.Version}";
        return SaveString;
    }
    public string GetOSString()
    {
        string OSString= _os.VersionString;
        return OSString;
    }
}