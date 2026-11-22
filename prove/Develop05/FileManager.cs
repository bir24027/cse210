using System.Xml.Linq;
using NativeFileDialogNET;
public class FileManager
{
    private string _saveLocation;
    private static Exception _canceledException= new Exception("File Selection Canceled");
    private static Exception _errorException= new Exception("File Dialog Error");
    public FileManager(string saveLocation="savedata.txt")
    {
        _saveLocation=saveLocation;
    }
    public static string SaveDialog()
    {
            NativeFileDialog saveDialog= new NativeFileDialog();
            saveDialog.SaveFile();
            saveDialog.AddFilter("Text Files","txt");
            DialogResult result= saveDialog.Open(out string chosenFile);
            saveDialog.Dispose();
            if (result==DialogResult.Okay)
            {
                return chosenFile;
            }
            else if (result==DialogResult.Cancel)
            {
                Console.WriteLine("The user canceled the save operation.");
                throw _canceledException;
            }
            else if (result==DialogResult.Error)
            {
                Console.WriteLine("An error occured.");
                throw _errorException;
            }
            else if(chosenFile.Contains(".."))
            {
                throw new Exception();
            }
            else
            {
                return "";
            }
        
    }
    public static string LoadDialog()
    {
        NativeFileDialog loadDialog= new NativeFileDialog();
        loadDialog.SelectFile();
        loadDialog.AddFilter("Text Files",".txt");
        DialogResult result= loadDialog.Open(out string selectedFile);
        loadDialog.Dispose();
        if (result == DialogResult.Okay)
        {
            return selectedFile;
        }
        else if(result == DialogResult.Cancel)
        {
            Console.WriteLine("The user canceled the load operation.");
            throw _canceledException;

        }
        else if (result == DialogResult.Error)
        {
            Console.WriteLine("An unknown error occured.");
            throw _errorException;
        }
        else if(selectedFile.Contains(".."))
        {
            throw new Exception();
        }
        else
        {
            return "";
        }
    }
    public void Save(GoalList goalList, string savePath)
    {
        savePath=savePath.Trim();
        string chosenFile;
        if (savePath == "Default")
        {
            chosenFile = _saveLocation;
        }
        else if (savePath == "")
        {

                chosenFile=SaveDialog();
        }
        else
        {
             chosenFile=savePath;
        }
        string saveString=goalList.GetSaveInfo();
        using (StreamWriter saveFile= new StreamWriter(chosenFile))
        {
            saveFile.Write(saveString);
        }
    }
    public GoalList Load(string loadPath)
    {
        string selectedFile="";
        if (loadPath == "Default")
        {
            selectedFile = _saveLocation;
        }
         else if (loadPath=="")
        {
            selectedFile = LoadDialog();

        }
        else
        {
            selectedFile = loadPath;
        }
        try
        {
        string[] loadedData = File.ReadAllLines(selectedFile);
        GoalList loadedGoalList = new GoalList(loadedData);
        return loadedGoalList;
        }
        catch (FileNotFoundException)
        {
            Log.Write($"File {selectedFile} does not exist and cannot be loaded.",System.Diagnostics.Tracing.EventLevel.Error);
            return new GoalList();
        }
        catch(FileLoadException)
        {
            Log.Write($"Loading error.",System.Diagnostics.Tracing.EventLevel.Error);
            return new GoalList();
        }

    }
    public static List<Exception> GetKnownExceptions()
    {
        List<Exception> dialogExceptions = new List<Exception>();
        dialogExceptions.Add(_canceledException);
        dialogExceptions.Add(_errorException);
        return dialogExceptions;
    }
}