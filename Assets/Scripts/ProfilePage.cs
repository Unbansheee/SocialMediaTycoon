using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePage : MonoBehaviour
{
    public GameObject personGrid;
    public GameObject personPrefab;
    
    public UserInfoPage userInfoPage;
    public PlayerData playerData;
    
    public void Refresh()
    {
        
        var users = (int)Math.Floor(playerData.SiteUsers);
        int usersCount = Math.Clamp(users, 1, 30);

        while (personGrid.transform.childCount < usersCount)
        {
            var person = Instantiate(personPrefab, personGrid.transform);
            var personScript = person.GetComponent<UI_PersonIcon>();
            personScript.infoPageRef = userInfoPage;
            personScript.GenerateWidget();
        }
        
        if (personGrid.transform.childCount > usersCount)
        {
            for (int i = personGrid.transform.childCount - 1; i >= usersCount; i--)
            {
                Destroy(personGrid.transform.GetChild(i).gameObject);
            }
        }
        

    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in personGrid.transform)
        {
            Destroy(child.gameObject);
        }
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        //dont do this except i will do this because im a bad programmer :)
        Refresh();
    }
}
