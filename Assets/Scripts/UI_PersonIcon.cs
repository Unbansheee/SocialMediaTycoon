using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UI_PersonIcon : MonoBehaviour
{
    //textmeshpro component
    public TextMeshProUGUI Name;
    public User user;
    public NFTGenerator avatar;

    private int seed = 0;

    private void OnValidate()
    {
        GenerateWidget();
        
    }

    public void GenerateWidget()
    {
        //get a random seed
        seed = Random.Range(0, 1000000);
        Random.InitState(seed);
        if (user != null)
        {
            user.seed = seed;
            user.GenerateUser();
            Name.text = user.name;
            
            if (avatar != null)
            {
                
                avatar.Seed = seed;
                avatar.identity = user.genderIdentity;
                avatar.GenerateAvatar();
            }
        }
    }
    
    
    // Start is called before the first frame update
    void Awake()
    {
        GenerateWidget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
