using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameData
{
    //private static readonly string saveName = "/save.dat";

    public static void SaveData(GameData gameData, string saveName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + saveName;
        Debug.Log(savePath);

        FileStream stream = null;
        try
        {
            stream = new FileStream(savePath, FileMode.Create);
            binaryFormatter.Serialize(stream, gameData);
        } finally
        {
            stream.Close();
        }
        
        
    }

    public static GameData LoadData(string saveName)
    {
        string savePath = Application.persistentDataPath + saveName;
        
        if (File.Exists(savePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = null;
            GameData gameData = null;
            try
            {
                stream = new FileStream(savePath, FileMode.Open);
                gameData = binaryFormatter.Deserialize(stream) as GameData;
            }
            finally
            {
                stream.Close();
            }
            return gameData;
        }
        else
        {
            Debug.Log(savePath + " does not exist");
            return null;
        }

    }

    public static void DeleteSave(string saveName)
    {
        string savePath = Application.persistentDataPath + saveName;

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
        else { Debug.Log(savePath + " is already deleted"); }
    }

}
