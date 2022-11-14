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
    
    public double SiteUsers = 1;
    public double SiteUsersPerSecond = 0.05;
    public double DataMB = 0;
    public double DataMBPerSecond = 0;
    public double Money = 200;
    public double MoneyPerSecond = 0;
    public double Reputation = 0;
    
    public double MoneyPerAdMultiplier = 1;
    public double CostPerUpgradeMultiplier = 1;
    public double MoneyPerDataScrapeMultiplier = 1;
    

    public bool SaveAndLoad = true;



    void Save()
    {
        PlayerPrefs.SetString("SiteUsers", SiteUsers.ToString());
        PlayerPrefs.SetString("SiteUsersPerSecond", SiteUsersPerSecond.ToString());
        PlayerPrefs.SetString("DataMB", DataMB.ToString());
        PlayerPrefs.SetString("DataMBPerSecond", DataMBPerSecond.ToString());
        PlayerPrefs.SetString("Money", Money.ToString());
        PlayerPrefs.SetString("MoneyPerSecond", MoneyPerSecond.ToString());
        PlayerPrefs.SetString("Reputation", Reputation.ToString());
        PlayerPrefs.SetString("MoneyPerAdMultiplier", MoneyPerAdMultiplier.ToString());
        PlayerPrefs.SetString("CostPerUpgradeMultiplier", CostPerUpgradeMultiplier.ToString());
        PlayerPrefs.SetString("MoneyPerDataScrapeMultiplier", MoneyPerDataScrapeMultiplier.ToString());
        
        
    }
    
    void Load()
    {
        SiteUsers = double.Parse(PlayerPrefs.GetString("SiteUsers", "1"));
        SiteUsersPerSecond = double.Parse(PlayerPrefs.GetString("SiteUsersPerSecond", "0.05"));
        DataMB = double.Parse(PlayerPrefs.GetString("DataMB", "0"));
        DataMBPerSecond = double.Parse(PlayerPrefs.GetString("DataMBPerSecond", "0"));
        Money = double.Parse(PlayerPrefs.GetString("Money", "200"));
        MoneyPerSecond = double.Parse(PlayerPrefs.GetString("MoneyPerSecond", "0"));
        Reputation = double.Parse(PlayerPrefs.GetString("Reputation", "0"));
        MoneyPerAdMultiplier = double.Parse(PlayerPrefs.GetString("MoneyPerAdMultiplier", "1"));
        CostPerUpgradeMultiplier = double.Parse(PlayerPrefs.GetString("CostPerUpgradeMultiplier", "1"));
        MoneyPerDataScrapeMultiplier = double.Parse(PlayerPrefs.GetString("MoneyPerDataScrapeMultiplier", "1"));
        
        
    }

    public void Reset()
    {
        SiteUsers = 1;
        SiteUsersPerSecond = 0.05;
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
