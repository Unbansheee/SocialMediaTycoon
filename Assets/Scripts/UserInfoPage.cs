using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class UserInfoPage : MonoBehaviour
{
    public User userData;
    public NFTGenerator originalIcon;
    
    public NFTGenerator pageIcon;
    public TextMeshProUGUI name;

    public GameObject BuyButton;
    public GameObject ServeAdButton;
    public GameObject SaveButton;
    
    public NFTGenerator AdPanelIcon;
    public TextMeshProUGUI AdPanelName;
    public TextMeshProUGUI BuyDataCostText;
    
    
    public List<TextMeshProUGUI> dataTexts;

    public float DataBuyCostMultiplier = 1.5f;
    public int DataBuyBaseCost = 1000;
    
    struct DataElement
    {
        public DataElement(string value, bool discovered)
        {
            this.discovered = discovered;
            this.value = value;
        }
        public string value;
        public bool discovered;
    }

    static float DataFieldValue = 0.5f;

    Dictionary<string, DataElement> Info = new Dictionary<string, DataElement>();

    // Start is called before the first frame update
    void Start()
    {
        //Open (userData, originalIcon);
        Close();
    }

    void Close()
    {
        gameObject.SetActive(false);
        
    }

    public void Open(User user, NFTGenerator icon)
    {
        userData = user;
        originalIcon = icon;

        AdPanelIcon.Set(icon);
        AdPanelName.text = userData.name;

        pageIcon.Set(originalIcon);
        name.text = userData.name;
        
        Info.Clear();
        
        Info.Add(userData.name, new DataElement(userData.name, true));
        Info.Add("Age", new DataElement(userData.age.ToString(), true));
        Info.Add("Identity", new DataElement(userData.genderIdentity.ToString(), true));
        Info.Add("Email", new DataElement(userData.email, true));
        Info.Add("Phone", new DataElement(userData.phoneNumber, true));
        Info.Add("Marriage", new DataElement(userData.marriageStatus.ToString(), false));
        Info.Add("Children", new DataElement(userData.children.ToString(), false));
        Info.Add("Education", new DataElement(userData.education.ToString(), false));
        Info.Add("Occupation", new DataElement(userData.occupation.ToString(), false));
        Info.Add("Years", new DataElement(userData.experience.ToString(), false));
        Info.Add("Salary", new DataElement(userData.salary.ToString(), false));
        Info.Add("Savings", new DataElement(userData.savings.ToString(), false));
        Info.Add("Debt", new DataElement(userData.debt.ToString(), false));
        Info.Add("Credit", new DataElement(userData.creditScore.ToString(), false));

        RefreshFields();
        
        gameObject.SetActive(true);
    }
    
    int GetDiscoveredDataCount()
    {
        int count = 0;
        foreach (var data in Info)
        {
            if (data.Value.discovered)
            {
                count++;
            }
        }

        return count;
    }
    
    int CalculateDataValue()
    {
        var playerData = FindObjectOfType<PlayerData>();
        return (int)(GetDiscoveredDataCount() * DataFieldValue * playerData.DataPerFieldMultiplier);
    }
    
    public void UnlockRandomData()
    {
        List<string> undiscovered = new List<string>();
        foreach (var entry in Info)
        {
            if (!entry.Value.discovered)
            {
                undiscovered.Add(entry.Key);
            }
        }
        
        if (undiscovered.Count > 0)
        {
            int index = Random.Range(0, undiscovered.Count);
            string key = undiscovered[index];
            Info[key] = new DataElement(Info[key].value, true);
            Debug.Log("Unlocked " + key);

        }
        
        RefreshFields();
    }
    
    public int GetFieldUnlockCost()
    {
        int cost = DataBuyBaseCost;
        int discovered = GetDiscoveredDataCount();
        for (int i = 0; i < discovered; i++)
        {
            cost = (int)(cost * DataBuyCostMultiplier);
        }
        return cost;
    }
    
    public void BuyData()
    {

        int cost = GetFieldUnlockCost();
        
        PlayerData playerData = FindObjectOfType<PlayerData>();
        if (playerData.Money >= cost)
        {
            playerData.Money -= cost;
            UnlockRandomData();
        }

    }

    public void RefreshFields()
    {
        foreach (var entry in dataTexts)
        {
            string key = entry.gameObject.name;
            if (Info.ContainsKey(key))
            {
                entry.text = Info[key].discovered ? Info[key].value : "???";
                entry.color = Info[key].discovered ? Color.white : Color.gray;
            }
            else
            {

                entry.text = "???";
                entry.color = Color.gray;
            }
            
            BuyDataCostText.text = "$" + GetFieldUnlockCost();
        }
        
        int value = CalculateDataValue();
        //get child of savedata button named DataAmount
        GameObject textComp = SaveButton.transform.Find("DataAmount").gameObject;
        TextMeshProUGUI text = textComp.GetComponent<TextMeshProUGUI>();
        string dataMagnitude = "MB";
        //format GB and TB
        if (value > 1000)
        {
            value = value / 1000;
            dataMagnitude = "GB";
        }
        if (value > 1000)
        {
            value = value / 1000;
            dataMagnitude = "TB";
        }
        text.text = value.ToString() + " " + dataMagnitude;
    }

    public void SaveData()
    {
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.DataMB += CalculateDataValue();
        Destroy(userData.transform.parent.gameObject);
        Close();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
