using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Advertisement : MonoBehaviour
{
    [SerializeField]
    RawImage background;
    [SerializeField]
    RawImage item;
    [SerializeField]
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandom(AdvertisementData data)
    {
        if (data.backgrounds.Count == 0 || data.items.Count == 0)
            return;
        if (data.backgrounds[0] == null || data.items[0] == null)
            return;
        int index = Random.Range(0, data.backgrounds.Count - 1);
        background.texture = data.backgrounds[index];

        index = Random.Range(0, data.items.Count - 1);
        item.texture = data.items[index];

        string desc = "";
        switch (Random.Range(0, 2))
        {
            case 0: desc = "Isn't it time you got a new "; break;
            case 1: desc = "You don't want to be seen with out the new "; break;
            case 2: desc = "You won't recognize yourself with the new "; break;
        }
        desc += data.items[index].name;
        text.text = desc;
    }
}
