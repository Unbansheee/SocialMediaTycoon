using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(RunOncePerSecond), 0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        playerData.SiteUsers += playerData.SiteUsersPerSecond * Time.deltaTime;
        playerData.DataMB += playerData.DataMBPerSecond * playerData.SiteUsers * Time.deltaTime;
        playerData.Money += playerData.MoneyPerSecond * playerData.SiteUsers * Time.deltaTime;
    }
    
    void RunOncePerSecond()
    {
        

    }
}
