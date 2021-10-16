using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    [SerializeField] private Info info; // so we can see our serialized class

    public Text text;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("GameInit"))
        {
            DataHandler.CreateData();
            PlayerPrefs.SetInt("GameInit", 1);
        }
        else
        {
            DataHandler.Load();
        }
    }

    private void Update()
    {
        UpdateVisual();
        ViewStats();
    }

    // for assinging the buttons
    public void AddValues(int _type)
    {
        switch (_type)
        {
            case 0:
                DataHandler.exp++;
                break;
            case 1:
                DataHandler.coins++;
                break;
            case 2:
                DataHandler.level++;
                break;
        }
       
    }

    public void SaveInfo()
    {
        DataHandler.Save();
    }

    public void LoadInfo()
    {
        DataHandler.Load();
    }

    public void Clear()
    {
        DataHandler.Clear();
    }

    void UpdateVisual()
    {
        text.text = "Exp" + " " + DataHandler.exp.ToString() + "\n" + "Coins" + " " + DataHandler.coins.ToString() + "\n" + "Level" + " " + DataHandler.level.ToString();
    }
    
    // for visual representation in the editor
    void ViewStats()
    {
        info.exp = DataHandler.exp;
        info.coins = DataHandler.coins;
        info.level = DataHandler.level;
    }
}
