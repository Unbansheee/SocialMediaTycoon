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
    public TextMeshProUGUI data;
    
    // Start is called before the first frame update
    void Start()
    {
        Open (userData, originalIcon);
    }

    void Close()
    {
        gameObject.SetActive(false);
        
    }


    public void Open(User user, NFTGenerator icon)
    {
        userData = user;
        originalIcon = icon;
        data.text = "";

        pageIcon.Set(originalIcon);
        
        name.text = userData.name;

        
        data.text += "Email: " + userData.email + "\n";
        data.text += "Phone: " + userData.phoneNumber + "\n";
        data.text += "Age: " + userData.age + " years \n";
        
        data.text += "Identity: " + userData.genderIdentity + "\n";
        
        data.text += "Education: " + userData.education + "\n";
        data.text += "Occupation: " + userData.occupation + "\n";
        data.text += "Years of Experience: " + userData.experience + " years \n";
        data.text += "Salary: " + userData.salary + " USD \n";
        
        
        
        
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
