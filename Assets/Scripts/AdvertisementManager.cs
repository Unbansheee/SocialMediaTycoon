using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AdvertType
{
    Alcohol,
    Food,
    Vape,
    Vehicle,
    Tech,
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
    public UserInfoPage userInfoPage;
    public int MaxAdsToServe = 3;
    public GameObject MaxAdsPanel;

    void Awake()
    {

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
        if (advertismenetData.Count == 0)
        {
            Debug.LogError("Tried to generate ad but no input data.");
            return;
        }
        foreach (Advertisement ad in Advertisements)
        { 
            int index = Random.Range(0, advertismenetData.Count);
            if (index >= 0)
                ad.GenerateRandom(advertismenetData[index]);
        }
    }

    public void ServeAds()
    {
        RefreshAds();
        MaxAdsPanel.SetActive(false);
    }

    public void SelectAd(int id)
    {
        if (userInfoPage.userData.adsWatched < MaxAdsToServe)
        {
            RefreshAds();
            playerData.Money += Random.Range(1, 20) * playerData.MoneyPerAdMultiplier;
            playerData.DataMB += Random.Range(1, 3) * playerData.DataPerFieldMultiplier;
            userInfoPage.userData.adsWatched++;
            userInfoPage.UnlockRandomData();
            MaxAdsPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Max ads watched");
            MaxAdsPanel.SetActive(true);
        }
    }
}
