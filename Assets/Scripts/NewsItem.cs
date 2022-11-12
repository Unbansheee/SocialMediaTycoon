using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Update is called once per frame
    void Update()
    {
        
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
