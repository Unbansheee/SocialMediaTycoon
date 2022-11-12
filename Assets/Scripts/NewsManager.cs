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
    public static NewsManager instance;

    [SerializeField]
    GameObject newsItemPrefab;

    [SerializeField]
    Transform parentContainer;

    [SerializeField]
    private List<NewsData> newsDatabase;

    [SerializeField]
    private List<NewsID> scheduledNews;

    private void Awake()
    {
        instance = this;
    }

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

    // Update is called once per frame
    void Update()
    {
        
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
