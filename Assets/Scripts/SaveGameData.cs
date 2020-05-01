using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameData
{
    private static readonly string saveName = "/save.dat";

    public static void SaveData(GameData gameData)
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

}
