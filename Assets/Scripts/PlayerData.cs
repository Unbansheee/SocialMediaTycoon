using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GainSource
{
    AD,
    UPGRADE,
    DATASCRAPE,
    FLAT
}

public class PlayerData : MonoBehaviour
{
    
    public int SiteUsers = 1;
    public int SiteUsersPerSecond = 0;
    public int DataMB = 0;
    public int DataMBPerSecond = 0;
    public int Money = 200;
    public int MoneyPerSecond = 0;
    public int Reputation = 0;
    
    public float MoneyPerAdMultiplier = 1;
    public float CostPerUpgradeMultiplier = 1;
    public float MoneyPerDataScrapeMultiplier = 1;
    

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
    
    public void ApplySkill(SkillTree.SkillID id)
    {
        switch (id)
        {
            case SkillTree.SkillID.None:
                break;
            case SkillTree.SkillID.Targeted_Advertising:
                MoneyPerAdMultiplier *= 1.5f;
                break;
            case SkillTree.SkillID.AI_Assisted_Advertising:
                MoneyPerSecond += 5;
                break;
            case SkillTree.SkillID.Automated_Advertising:
                MoneyPerSecond *= 3;
                break;
            case SkillTree.SkillID.User_Tagging:
                break;
            case SkillTree.SkillID.Facial_Recognition:
                break;
            case SkillTree.SkillID.Addictive_UX:
                break;
            case SkillTree.SkillID.Data_Scraping:
                break;
            case SkillTree.SkillID.Anonymized_Data:
                break;
            case SkillTree.SkillID.Data_Broker:
                break;
            case SkillTree.SkillID.Research_Device_Vulnerabilities:
                break;
            case SkillTree.SkillID.Expand_App_Permissions:
                break;
            case SkillTree.SkillID.Deanonymization_Research:
                break;
            case SkillTree.SkillID.Lobbying:
                break;
            case SkillTree.SkillID.Sign_In_With_SM_Tycoon:
                break;
            case SkillTree.SkillID.Add_Backdoor:
                break;
            case SkillTree.SkillID.Ban_Encryption:
                break;
            case SkillTree.SkillID.Prohibitive_Regulation:
                break;
            case SkillTree.SkillID.Acquire_Competition:
                break;
            case SkillTree.SkillID.Minimum_10000_Users:
                break;
            case SkillTree.SkillID.Minimum_1000000_Money:
                break;
            case SkillTree.SkillID.Minimum_1000_Data:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }
        
    }
}
