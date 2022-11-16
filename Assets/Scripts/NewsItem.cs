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

    [SerializeField]
    AudioSource closeSound;

    // Start is called before the first frame update
    void Start()
    {
        if (closeSound == null)
            closeSound = GameObject.Find("Audio_02").GetComponent<AudioSource>();
    }
    
    public void DesroyNewsItem()
    {
        Destroy(gameObject);
        if (closeSound != null)
            closeSound.Play();
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
