using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataService : IDataService
{
    private ISerializer serializer;
    private string dataPath; //where the save file is located
    private string fileExtention; //we can define a custon extention if needed

    public FileDataService(ISerializer serializer)
    {
        this.serializer = serializer;
        dataPath = Application.persistentDataPath; // C:/Users/Ern/Appdata/LocalLow/DefaultCompany
        fileExtention = ".json";
    }

    //GetPathFile - To combine the dataPath, FileName and FileExtention
    private string GetPathFile(string fileName)
    {
        return Path.Combine(dataPath, string.Concat(fileName, fileExtention));
    }

    //Save
    public void Save(GameData data, bool overwrite = true)
    {
        string fileLocation = GetPathFile(data.fileName);
        if(!overwrite && File.Exists(fileLocation)) // if can't overwrite and the file exists
        {
            throw new IOException("The file already exists and can't be overwritten");
        }
        File.WriteAllText(fileLocation, serializer.Serialize(data));
    }

    //Load
    public GameData Load(string fileName)
    {
        string FileLocation = GetPathFile(fileName);
        if (!File.Exists(FileLocation))
        {
            throw new System.Exception("No persistent data found at " + FileLocation);
        }
        return serializer.Deserealize<GameData>(File.ReadAllText(FileLocation));
    }

    //Delete
    public void Delete(string fileName)
    {
        string fileLocation = GetPathFile(fileName);
        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
    }

    //ListAllSaves
    public IEnumerable<string> ListSaves()
    {
        foreach(string path in Directory.EnumerateFiles(dataPath))
        {
            if(Path.GetExtension(path) == fileExtention)
            {
                yield return Path.GetFileNameWithoutExtension(path); 
            }
        }
    }
}
