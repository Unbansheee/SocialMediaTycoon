using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Advertisement : MonoBehaviour
{
    [SerializeField]
    List<Texture2D> backgrounds;
    [SerializeField]
    List<Texture2D> items;
    [SerializeField]
    RawImage background;
    [SerializeField]
    RawImage item;
    [SerializeField]
    TextMeshProUGUI text;

    //private void Awake()
    //{
    //    
    //}

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandom()
    {
        if (backgrounds.Count == 0 || items.Count == 0)
            return;
        if (backgrounds[0] == null || items[0] == null)
            return;
        int index = Random.Range(0, backgrounds.Count - 1);
        background.texture = backgrounds[index];

        index = Random.Range(0, items.Count - 1);
        item.texture = items[index];

        string desc = "";
        switch (Random.Range(0, 2))
        {
            case 0: desc = "Isn't it time you got a new "; break;
            case 1: desc = "You don't want to be seen with out the new "; break;
            case 2: desc = "You won't recognize yourself with the new "; break;
        }
        desc += items[index].name;
        text.text = desc;
    }
}
