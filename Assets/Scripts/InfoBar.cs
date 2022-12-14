using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBar : MonoBehaviour
{
    PlayerData playerData;
    public TextMeshProUGUI UserCount;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI Data;
    public TextMeshProUGUI PageNameText;
    public Toolbar Toolbar;
    
    void Awake()
    {
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerData>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UserCount.text = ((int)Math.Floor(playerData.SiteUsers)).ToString();
        string money = ((int)Math.Floor(playerData.Money)).ToString();
        
        //format money with commas
        int count = 0;
        for (int i = money.Length - 1; i >= 0; i--)
        {
            if (count == 3)
            {
                money = money.Insert(i + 1, ",");
                count = 0;
            }
            count++;
        }
        Money.text = "$" + money;

        string dataMagnitude = "MB";
        double data = playerData.DataMB;
        //format GB and TB with 2 decimal places
        if (data >= 1000)
        {
            data /= 1000;
            dataMagnitude = "GB";
            if (data >= 1000)
            {
                data /= 1000;
                dataMagnitude = "TB";
            }
        }
        else
        {
            data = Math.Floor(data);
        }
        //filter data to 2 deimal places
        data = Math.Round(data, 2);
        
        Data.text = data + " " + dataMagnitude;


        switch (Toolbar.CurrentPage)
        {
            case PageID.News:
                PageNameText.text = "NEWS";
                break;
            case PageID.Profiles:
                PageNameText.text = "USERS";
                break;
            case PageID.Upgrades:
                PageNameText.text = "UPGRADES";
                break;
            case PageID.Settings:
                PageNameText.text = "INSTRUCTIONS";
                break;
            default:
                PageNameText.text = "???";
                break;
        }
    }
}
