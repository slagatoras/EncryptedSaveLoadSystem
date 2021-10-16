using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;

[Serializable]
public class Info
{
    public int exp = 0;
    public int coins = 0;
    public int level = 0;
}


public static class DataHandler
{
    #region Data System
    private static Info info;
    public static Info Info { get => info; }

    public static int exp;
    public static int coins;
    public static int level;

    public static void CreateData()
    {
        MemoryStream ms = new MemoryStream();

        Info inf = new Info
        {
            coins = 0,
            exp = 0,
            level = 0
        };

        using (BsonWriter writer = new BsonWriter(ms))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, inf);
        }

        string data = Convert.ToBase64String(ms.ToArray());

        if (!File.Exists(data))
        {
            File.WriteAllText(Application.persistentDataPath + "/Data.json", data);
            Debug.Log("Create Data");
        }
        else
        {
            Debug.Log("Data exist");
        }

    }

    public static void Save()
    {
        MemoryStream ms = new MemoryStream();

        Info newInfo = new Info
        {
            coins = coins,
            exp = exp,
            level = level
        };

        using (BsonWriter writer = new BsonWriter(ms))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, newInfo);
        }

        string data = Convert.ToBase64String(ms.ToArray());

        try
        {
            File.WriteAllText(Application.persistentDataPath + "/Data.json", data);
            Debug.Log("Data Saved");
            Debug.Log(data);

        }
        catch (Exception e)
        {
            Debug.Log("Error Saving Data:" + e);
            throw;
        }
    }

    public static void Load()
    {
        try
        {
            string userString = File.ReadAllText(Application.persistentDataPath + "/Data.json");

            byte[] data = Convert.FromBase64String(userString);

            MemoryStream ms = new MemoryStream(data);
            using (BsonReader reader = new BsonReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();

                Info e = serializer.Deserialize<Info>(reader);

                exp = e.exp;
                coins = e.coins;
                level = e.level;
            }
            Debug.Log("Data Loaded");
        }
        catch (Exception e)
        {
            Debug.Log("Error Loading Data:" + e);
            throw;
        }
    }

    public static void Clear()
    {
        Debug.Log("Data Cleared");
        exp = 0;
        coins = 0;
        level = 0;
    }
    #endregion

}// class

