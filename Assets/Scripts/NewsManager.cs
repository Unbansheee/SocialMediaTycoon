using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewsID
{
    None,

    // Tree 1
    Better_Ads,
    Creepy_Ads,
    Better_Networks,
    Annonying_Ads,
    Easier_Picture_Tagging,
    Uneasy_Picture_Tagging,
    Social_Media_Additicion,

    // Tree 2
    Are_My_Messages_Private,
    Announcing_Anon_Data,
    Cloudmedia_Using_Bug,
    Targeted_Ads_Spreading,
    Incerased_Insurance,
    Unexpected_Ads_On_Platform,
    Most_Users_Dont_Check_Permissions,
    Location_Based_Ads,
    Targeted_Billboards,
    Always_On_Microphone,

    // Tree 3
    Law_Loose_Data_Privacy,
    Government_Caught_Surveiling_Minority,
    Protestors_Demand_Privacy_Laws,
    Hackers_Exploit_CM_Backdoor,
    CM_Unveils_Easy_Logins,
    CM_Logins_Expose_Users_To_Phishing,
    Banned_Encryption_Criminals,
    Banned_Encryption_Protests,
    Banned_Encryption_Data_Exposed,
    Govt_Passes_Contet_Regulation,
    Offer_Central_Service,
    CM_Used_For_Gov_ID,
    No_Choice_But_CM,
    Gov_Concerned_About_CM_Influence,

    // Misc added to various skills
    Privacy_Browsers,
    Privacy_Search_Engines,
    Using_VPNs,
    Users_Move_To_Privacy_Alternatives,

    // Endgame Images
    IMG_End_Monopoly,
}

[System.Serializable]
public struct NewsData
{
    public NewsID id;
    public string headline;
    [TextArea(3, 10)]
    public string blurb;
}

public class NewsManager : MonoBehaviour
{
    [SerializeField]
    GameObject newsItemPrefab;

    [SerializeField]
    GameObject newsImagePrefab;

    [SerializeField]
    Transform parentContainer;

    [SerializeField]
    Toolbar toolbar;

    [SerializeField]
    private List<NewsData> newsDatabase;

    [SerializeField]
    private List<NewsID> scheduledNews;

    private HashSet<NewsID> newsImageIDs;

    // Start is called before the first frame update
    void Start()
    {
        newsImageIDs = new() { NewsID.IMG_End_Monopoly };
        // Adding starting posts
        while (PostNextNewsStory());
    }


    NewsData GetNewsDataFromID(NewsID id)
    {
        foreach (NewsData data in newsDatabase)
        {
            if (data.id == id)
            {
                return data;
            }
        }
        return new();
    }

    public void ScheduleNewsFromID(NewsID id)
    {
        scheduledNews.Add(id);
        if (scheduledNews.Count == 1)
        {
            toolbar.ScheduleNewsNotificaiton(PostNextNewsStory, 10f);
        }
    }

    // Returns true if there are more scheduled stories
    public bool PostNextNewsStory()
    {
        if (scheduledNews.Count == 0)
            return false;
        NewsID id = scheduledNews[0];
        scheduledNews.RemoveAt(0);
        if (newsImageIDs.Contains(id))
        {
            PostNewsImage(id);
        }
        else
        {
            NewsData data = GetNewsDataFromID(id);
            if (data.id != NewsID.None)
            {
                PostNewsStory(data);
                ToolbarButton button = toolbar.GetButtonFromPageID(PageID.News);
                if (!this.isActiveAndEnabled)
                    button.AddNotification(1);
            }
        }
        return scheduledNews.Count > 0;
    }

    void PostNewsStory(NewsData data)
    {
        GameObject item = Instantiate(newsItemPrefab, Vector3.zero, Quaternion.identity);
        item.name = data.id.ToString();
        NewsItem newsItem = item.GetComponent<NewsItem>();
        newsItem.SetHeadline(data.headline);
        newsItem.SetBlurb(data.blurb);
        item.transform.SetParent(parentContainer);
        //get rect transform
        RectTransform rectTransform = item.GetComponent<RectTransform>();
        transform.localScale = new Vector3(1, 1, 1);

        rectTransform.sizeDelta = new Vector2(1125.863f, rectTransform.sizeDelta.y);
    }

    void PostNewsImage(NewsID id)
    {
        GameObject item = Instantiate(newsImagePrefab, Vector3.zero, Quaternion.identity);
        item.name = id.ToString();
        item.transform.SetParent(parentContainer);
        RectTransform rectTransform = item.GetComponent<RectTransform>();
        transform.localScale = new Vector3(1, 1, 1);
        rectTransform.sizeDelta = new Vector2(1125.863f, rectTransform.sizeDelta.y);
    }
}
