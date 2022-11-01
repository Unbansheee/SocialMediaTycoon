using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfoPage : MonoBehaviour
{
    public User userData;
    public NFTGenerator originalIcon;
    
    public NFTGenerator pageIcon;
    public TextMeshProUGUI name;
    
    // Start is called before the first frame update
    void Start()
    {
        Open (userData, originalIcon);
    }

    void Close()
    {
        gameObject.SetActive(false);
        
    }
    
    
    void Open(User user, NFTGenerator icon)
    {
        userData = user;
        originalIcon = icon;
        
        pageIcon.Set(originalIcon);
        name.text = userData.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
