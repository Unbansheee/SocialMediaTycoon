using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PersonIcon : MonoBehaviour
{
    //textmeshpro component
    public TextMeshProUGUI Name;
    public User user;
    public NFTGenerator avatar;

    private void OnValidate()
    {
        
        GenerateWidget();
        
    }

    void GenerateWidget()
    {
        if (user != null)
        {
            user.GenerateUser();
            Name.text = user.name;
            
            if (avatar != null)
            {
                avatar.identity = user.genderIdentity;
                avatar.GenerateAvatar();
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
