using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
public static void SaveProgress(SaveLoad saveLoad)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.progress";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerProgress data = new PlayerProgress(saveLoad);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerProgress LoadProgress()
    {
        string path = Application.persistentDataPath + "/player.progress";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerProgress data = formatter.Deserialize(stream) as PlayerProgress;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Load error");
            return null;
        }
    }
}
