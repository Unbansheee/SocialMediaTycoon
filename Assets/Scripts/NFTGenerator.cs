using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NFTGenerator : MonoBehaviour
{
    public GameObject body;
    public GameObject nose;
    public GameObject eyes;
    public GameObject mouth;
    public GameObject hair;
    public GameObject background;

    public Sprite[] bodySprites;
    public Sprite[] noseSprites;
    public Sprite[] eyesSprites;
    public Sprite[] mouthSprites;
    public Sprite[] hairSprites;
    public Sprite[] backgroundSprites;

    public bool lockBody = false;
    public bool lockNose = false;
    public bool lockEyes = false;
    public bool lockMouth = false;
    public bool lockHair = false;
    public bool lockBackground = false;
    
    
    public void GenerateAvatar()
    {
        if (!lockBody) body.GetComponent<Image>().sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        if (!lockNose) nose.GetComponent<Image>().sprite = noseSprites[Random.Range(0, noseSprites.Length)];
        if (!lockEyes) eyes.GetComponent<Image>().sprite = eyesSprites[Random.Range(0, eyesSprites.Length)];
        if (!lockMouth) mouth.GetComponent<Image>().sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
        if (!lockHair) hair.GetComponent<Image>().sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        if (!lockBackground) background.GetComponent<Image>().sprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];
        
        
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}


