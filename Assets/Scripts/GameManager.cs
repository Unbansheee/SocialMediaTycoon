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

        playerData.SiteUsers += (int)(playerData.SiteUsersPerSecond * Time.deltaTime);
        playerData.DataMB += (int)(playerData.DataMBPerSecond * Time.deltaTime);
        playerData.Money += (int)(playerData.MoneyPerSecond * Time.deltaTime);
    }
    
    void RunOncePerSecond()
    {
        

    }
}
