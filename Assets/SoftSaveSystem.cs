using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SoftSaveSystem
{
    public static void SaveGame(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/softSaveGameData.data";

        FileStream stream = new FileStream(path, FileMode.Create);

        SoftSaveGameData data = new SoftSaveGameData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SoftSaveGameData LoadData()
    {
        string path = Application.persistentDataPath + "/softSaveGameData.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SoftSaveGameData data = formatter.Deserialize(stream) as SoftSaveGameData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
