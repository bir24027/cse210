using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.InteropServices;
public class Settings
{
    bool _autoSave=false;
    string _settingsSaveFile;
    private string _defaultSaveFile="";
    FileManager _settingsFileManager=new FileManager();
    Menu _menu;
    public Settings( Menu menu)
    {
        _menu=menu;
        try
        {
            _settingsSaveFile=$"{RuntimeInformation.OSDescription}-{Environment.MachineName}- {Environment.UserName}-settings.txt";
            string [] settings= File.ReadAllLines(_settingsSaveFile);
            foreach (string setting in settings)
            {
                string[] settingDetails=setting.Split("|");
                if(settingDetails[0]=="Autosave")
                {
                    _autoSave=bool.Parse(settingDetails[1]);
                }
                else if(settingDetails[0]=="Save Location")
                {
                    _defaultSaveFile=settingDetails[1];
                }
            }
            if (_autoSave)
            {
                _menu.Load(_settingsFileManager.Load(_defaultSaveFile));
            }
        }
        catch(FileNotFoundException)
        {
            Log.Write("No settings file found.",System.Diagnostics.Tracing.EventLevel.Informational);
        }
    }
    public void SaveSettings()
    {
        using (StreamWriter settingsFile= new StreamWriter(_settingsSaveFile))
        {
            settingsFile.WriteLine($"Autosave|{_autoSave}");
            settingsFile.WriteLine($"Save Location|{_defaultSaveFile}");
        }
        Console.WriteLine("Sucessfully saved.");
    }
    public void SettingsManager(GoalList _goalList)
    {
        if (_autoSave)
        {
            if (!(_goalList==_settingsFileManager.Load("Default")))
            {
                _settingsFileManager.Save(_goalList,_defaultSaveFile);

            }
        }
    }
    public void SettingsEditor()
    {
        Dictionary <string, Action> settingOptions=new Dictionary<string, Action> ();
        settingOptions.Add("Toggle Auto Save",SetAutoSave);
        settingOptions.Add("Choose default save location",SetDefaultFile);
        Menu.DisplayMenu(settingOptions,"Settings")();
        SaveSettings();

    }
    public void SetAutoSave()
    {
        _autoSave=!_autoSave;
        Console.WriteLine($"Auto Save is now set to {_autoSave}.");

    }
    public void SetDefaultFile()
    {
        try{
        _defaultSaveFile= FileManager.SaveDialog();
        }
        catch (Exception e)
        {
            if (FileManager.GetKnownExceptions().Contains(e))
            {
                
            }
            else
            {
                throw;
            }
        }
    }
    public string GetDefaultFile()
    {
        return _defaultSaveFile;
    }
}