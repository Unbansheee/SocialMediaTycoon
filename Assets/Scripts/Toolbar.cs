using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    [SerializeField]
    GameObject Page_Settings;
    [SerializeField]
    GameObject Page_News;
    [SerializeField]
    GameObject Page_Profiles;
    [SerializeField]
    GameObject Page_Adverts;
    [SerializeField]
    GameObject Page_Upgrades;
    [SerializeField]
    GameObject Page_Outreach;

    [SerializeField]
    public int CurrentPage = 3;

    List<GameObject> Pages;

    // Start is called before the first frame update
    void Awake()
    {

        Pages = new List<GameObject> { Page_Settings, Page_News, Page_Profiles, Page_Upgrades , Page_Adverts, Page_Outreach };
        ShowPage(CurrentPage);
    }

    public void ShowPage(int id)
    {
        if (id < 0 || id >= Pages.Count)
            return;
        CurrentPage = id;
        foreach (GameObject page in Pages)
        {
            page.SetActive(false);
        }
        Pages[id].SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
