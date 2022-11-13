using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewsID
{
    None,
    Better_Ads,
}

[System.Serializable]
public struct NewsData
{
    public NewsID id;
    public string headline;
    public string blurb;
}

public class NewsManager : MonoBehaviour
{
    [SerializeField]
    GameObject newsItemPrefab;

    [SerializeField]
    Transform parentContainer;

    [SerializeField]
    Toolbar toolbar;

    [SerializeField]
    private List<NewsData> newsDatabase;

    [SerializeField]
    private List<NewsID> scheduledNews;

    // Start is called before the first frame update
    void Start()
    {
        // temporary testing, should have delay
        foreach (NewsID id in scheduledNews)
        {
            foreach (NewsData data in newsDatabase)
            {
                if (data.id == id)
                {
                    PostNewsStory(data);
                    break;
                }
            }
            
        }
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
        //scheduledNews.Add(id);

        // temp
        foreach (NewsData data in newsDatabase)
        {
            if (data.id == id)
            {
                PostNewsStory(data);
                break;
            }
        }

        //StartCoroutine(UpdateNewsFeed());
        toolbar.ScheduleNewsNotificaiton(UpdateNewsFeed());
        ToolbarButton button = toolbar.GetButtonFromPageID(PageID.News);
        button.AddNotification(1);
    }

    IEnumerator UpdateNewsFeed(float timeMult = 1.0f)
    {
        ToolbarButton button = toolbar.GetButtonFromPageID(PageID.News);
        while (scheduledNews.Count > 0)
        {
            float newsDelay = timeMult * 10.0f * (1.0f + Random.value);
            yield return new WaitForSeconds(newsDelay);
            NewsData data = GetNewsDataFromID(scheduledNews[0]);
            if (data.id != NewsID.None)
            {
                PostNewsStory(data);
                //if (!gameObject.activeInHierarchy)
                //{
                    button.AddNotification(1);
                //}
            }
            scheduledNews.RemoveAt(0);
        }
    }

    void PostNewsStory(NewsData data)
    {
        GameObject item = Instantiate(newsItemPrefab, Vector3.zero, Quaternion.identity);
        item.name = data.id.ToString();
        NewsItem newsItem = item.GetComponent<NewsItem>();
        newsItem.SetHeadline(data.headline);
        newsItem.SetBlurb(data.blurb);
        item.transform.SetParent(parentContainer);
    }
}
