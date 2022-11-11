using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AdvertType
{
    Alcohol,
    Food,
    Vape,
    Vehicle
}

//[System.Serializable]
//public class ListWrapper<T>
//{
//    public List<T> list;
//}

[System.Serializable]
public struct AdvertisementData
{
    public AdvertType type;
    public List<Texture2D> items;
    public List<Texture2D> backgrounds;
}

public class AdvertisementManager : MonoBehaviour
{
    [SerializeField]
    List<Advertisement> Advertisements;

    [SerializeField]
    List<AdvertisementData> advertismenetData;

    List<AdvertisementData> advertismenetData2;

    PlayerData playerData;

    void Awake()
    {
        advertismenetData2 = new List<AdvertisementData>();
        foreach (AdvertisementData data in advertismenetData)
        {
            AdvertisementData copy;
            copy.type = data.type;
            copy.items = new List<Texture2D>();
            foreach (Texture2D img in data.items)
            {
                copy.items.Add(img);
            }
            copy.backgrounds = new List<Texture2D>();
            foreach (Texture2D img in data.backgrounds)
            {
                copy.backgrounds.Add(img);
            }
            advertismenetData2.Add(copy);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshAds()
    {
        if (advertismenetData2.Count == 0)
        {
            Debug.LogError("Tried to generate ad but no input data.");
            return;
        }
        foreach (Advertisement ad in Advertisements)
        { 
            int index = Random.Range(0, advertismenetData2.Count - 1);
            if (index >= 0)
                ad.GenerateRandom(advertismenetData2[index]);
        }
    }

    public void ServeAds()
    {
        RefreshAds();
    }

    public void SelectAd(int id)
    {
        RefreshAds();
        playerData.Money += Random.Range(100, 500);
    }
}
