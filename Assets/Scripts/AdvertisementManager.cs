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

    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerData>();
        //RefreshAds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshAds()
    {
        if (advertismenetData.Count == 0)
        {
            Debug.LogError("Tried to generate ad but no input data.");
            return;
        }
        foreach (Advertisement ad in Advertisements)
        { 
            int index = Random.Range(0, advertismenetData.Count - 1);
            if (index >= 0)
                ad.GenerateRandom(advertismenetData[index]);
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
