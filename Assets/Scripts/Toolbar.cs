using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO move to a better locaiton
public enum GameState
{
    Playing,
    Ending,
}

public enum PageID
{
    News,
    Profiles,
    Upgrades,
    Settings,
}

public delegate bool NewsPost();

public class Toolbar : MonoBehaviour
{
    [SerializeField]
    GameObject Page_Settings;
    [SerializeField]
    GameObject Page_News;
    [SerializeField]
    GameObject Page_Profiles;
    [SerializeField]
    GameObject Page_Upgrades;

    [SerializeField]
    private List<ToolbarButton> buttons;

    [SerializeField]
    public PageID CurrentPage = PageID.News;

    List<GameObject> Pages;

    // TODO move to a better locaiton 
    private GameState state = GameState.Playing;

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

    // Used by OnClick gameobject components
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

    public void ScheduleNewsNotificaiton(NewsPost func, float delay = 10f)
    {
        StartCoroutine(NotifyNews(func, delay));
    }

    IEnumerator NotifyNews(NewsPost func, float delay = 10f)
    {
        bool active = true;
        do
        {
            float waitTime = (1f + Random.value) * delay;
            yield return new WaitForSeconds(delay);
            active = func();
        } while (active);

    }

    // Temp code to set game state until GS moved to a propper location
    public void SetGameState(GameState state)
    {
        this.state = state;
    }
    public GameState GetGameState()
    {
        return this.state;
    }
}
