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
    
    public double MoneyPerAdMultiplier = 1; // Affects the amount of money you get from serving an ad
    public double CostPerUpgradeMultiplier = 1; // Not used
    public double MoneyPerDataScrapeMultiplier = 1; // Not used
    public double DataPerFieldMultiplier = 1;  // Affects the amount of money you get from each data field when Saving data
    

    public bool SaveAndLoad = true;



    void Save()
    {
        /*
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
        */
        
        
    }
    
    void Load()
    {
        /*
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
        */
        
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
                MoneyPerAdMultiplier *= 2.0f;
                SiteUsersPerSecond *= 2.0f;
                break;
            case SkillTree.SkillID.AI_Assisted_Advertising:
                MoneyPerSecond += 5;
                DataMBPerSecond = 1;
                DataPerFieldMultiplier = 2;
                break;
            case SkillTree.SkillID.Automated_Advertising:
                MoneyPerSecond *= 3;
                DataMBPerSecond += 0.5;
                DataPerFieldMultiplier *= 1.5;
                break;
            case SkillTree.SkillID.User_Tagging:
                DataPerFieldMultiplier *= 2.0f;
                SiteUsersPerSecond *= 2.0f;
                break;
            case SkillTree.SkillID.Facial_Recognition:
                DataMBPerSecond += 2;
                break;
            case SkillTree.SkillID.Addictive_UX:
                DataMBPerSecond += 5;
                MoneyPerSecond += 5;
                SiteUsersPerSecond *= 3.0f;
                break;
            case SkillTree.SkillID.Data_Scraping:
                DataPerFieldMultiplier *= 1.5f;
                break;
            case SkillTree.SkillID.Anonymized_Data:
                DataPerFieldMultiplier *= 3.0f;
                break;
            case SkillTree.SkillID.Data_Broker:
                MoneyPerSecond += 10;
                DataPerFieldMultiplier *= 1.5f;
                DataMBPerSecond += 5;
                break;
            case SkillTree.SkillID.Research_Device_Vulnerabilities:
                DataPerFieldMultiplier *= 2.0f;
                DataMBPerSecond += 5;
                break;
            case SkillTree.SkillID.Expand_App_Permissions:
                DataPerFieldMultiplier *= 2.0f;
                DataMBPerSecond += 5;
                break;
            case SkillTree.SkillID.Deanonymization_Research:
                DataMBPerSecond += 10;
                DataPerFieldMultiplier *= 2.0f;
                break;
            case SkillTree.SkillID.Lobbying:
                SiteUsersPerSecond *= 4;
                break;
            case SkillTree.SkillID.Sign_In_With_SM_Tycoon:
                SiteUsersPerSecond *= 2;
                break;
            case SkillTree.SkillID.Add_Backdoor:
                MoneyPerSecond *= 30;
                break;
            case SkillTree.SkillID.Ban_Encryption:
                DataMBPerSecond *= 5;
                break;
            case SkillTree.SkillID.Prohibitive_Regulation:
                SiteUsersPerSecond *= 5;
                break;
            case SkillTree.SkillID.Acquire_Competition:
                SiteUsersPerSecond *= 2;
                DataMBPerSecond *= 2;
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
