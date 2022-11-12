using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    
    public int SiteUsers = 1;
    public int SiteUsersPerSecond = 0;
    public int DataMB = 0;
    public int DataMBPerSecond = 0;
    public int Money = 200;
    public int MoneyPerSecond = 0;
    public int Reputation = 0;
    
    public bool SaveAndLoad = true;
    
    void Save()
    {
        PlayerPrefs.SetInt("SiteUsers", SiteUsers);
        PlayerPrefs.SetInt("SiteUsersPerSecond", SiteUsersPerSecond);
        PlayerPrefs.SetInt("DataMB", DataMB);
        PlayerPrefs.SetInt("DataMBPerSecond", DataMBPerSecond);
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("MoneyPerSecond", MoneyPerSecond);
        PlayerPrefs.SetInt("Reputation", Reputation);
    }
    
    void Load()
    {
        SiteUsers = PlayerPrefs.GetInt("SiteUsers");
        SiteUsersPerSecond = PlayerPrefs.GetInt("SiteUsersPerSecond");
        DataMB = PlayerPrefs.GetInt("DataMB");
        DataMBPerSecond = PlayerPrefs.GetInt("DataMBPerSecond");
        Money = PlayerPrefs.GetInt("Money");
        MoneyPerSecond = PlayerPrefs.GetInt("MoneyPerSecond");
        Reputation = PlayerPrefs.GetInt("Reputation");
    }

    public void Reset()
    {
        SiteUsers = 1;
        SiteUsersPerSecond = 0;
        DataMB = 0;
        DataMBPerSecond = 0;
        Money = 200;
        MoneyPerSecond = 0;
        Reputation = 0;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SaveAndLoad) Load();
    }
    
    // on end play
    void OnApplicationQuit()
    {
        if (SaveAndLoad) Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
