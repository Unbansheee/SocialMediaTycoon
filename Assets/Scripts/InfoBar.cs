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
        UserCount.text = playerData.SiteUsers.ToString();
        string money = playerData.Money.ToString();
        
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
        long data = playerData.DataMB;
        //format GB and TB
        if (data > 1000)
        {
            data = data / 1000;
            dataMagnitude = "GB";
        }
        if (data > 1000)
        {
            data = data / 1000;
            dataMagnitude = "TB";
        }
        Data.text = data.ToString() + " " + dataMagnitude;
        
    }
}
