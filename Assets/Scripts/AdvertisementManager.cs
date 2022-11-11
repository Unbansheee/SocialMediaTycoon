using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementManager : MonoBehaviour
{
    [SerializeField]
    List<Advertisement> Advertisements;

    PlayerData playerData;

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
        foreach (Advertisement ad in Advertisements)
        {
            ad.GenerateRandom();
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
