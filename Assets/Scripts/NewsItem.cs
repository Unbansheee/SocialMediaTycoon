using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class NewsItem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI headline;

    [SerializeField]
    TextMeshProUGUI blurb;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void DesroyNewsItem()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetHeadline(string text)
    {
        if (headline != null)
        {
            headline.text = text;
        }
    }
    public void SetBlurb(string text)
    {
        if (blurb != null)
        {
            blurb.text = text;
        }
    }
}
