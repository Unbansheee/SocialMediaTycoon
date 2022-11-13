using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PageID
{
    News,
    Profiles,
    Upgrades,
    Settings,
}

public class Toolbar : MonoBehaviour
{
    [SerializeField]
    GameObject Page_Settings;
    [SerializeField]
    GameObject Page_News;
    [SerializeField]
    GameObject Page_Profiles;
    //[SerializeField]
    //GameObject Page_Adverts;
    [SerializeField]
    GameObject Page_Upgrades;
    //[SerializeField]
    //GameObject Page_Outreach;

    [SerializeField]
    private List<ToolbarButton> buttons;

    [SerializeField]
    public PageID CurrentPage = PageID.News;

    List<GameObject> Pages;

    // Start is called before the first frame update
    void Awake()
    {

        Pages = new List<GameObject> { Page_News, Page_Profiles, Page_Upgrades, Page_Settings };
        ShowPage(CurrentPage);
    }

    public void ShowPage(PageID id)
    {
        CurrentPage = id;
        foreach (GameObject page in Pages)
        {
            page.SetActive(false);
        }
        Pages[(int)id].SetActive(true);
        buttons[(int)id].ClearNotifications();
    }

    public void ShowPage(int id)
    {
        if (id >= 0 && id < Pages.Count)
        {
            ShowPage((PageID)id);
        }
    }

    public ToolbarButton GetButtonFromPageID(PageID id)
    {
        return buttons[(int)id];
    }

    public void ScheduleNewsNotificaiton(IEnumerator func)
    {
        StartCoroutine(func);
    }

    //IEnumerator NotifyNews()
    //{
    //
    //}
}
