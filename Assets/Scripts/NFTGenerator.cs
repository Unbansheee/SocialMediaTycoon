using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NFTGenerator : MonoBehaviour
{
    public GenderIdentity identity = GenderIdentity.Other;
    
    public GameObject body;
    public GameObject nose;
    public GameObject eyes;
    public GameObject mouth;
    public GameObject hair;
    public GameObject background;

    public Sprite[] mBodySprites;
    public Sprite[] mNoseSprites;
    public Sprite[] mEyesSprites;
    public Sprite[] mMouthSprites;
    public Sprite[] mHairSprites;
    
    public Sprite[] fBodySprites;
    public Sprite[] fNoseSprites;
    public Sprite[] fEyesSprites;
    public Sprite[] fMouthSprites;
    public Sprite[] fHairSprites;
    
    
    public Sprite[] backgroundSprites;

    public bool lockBody = false;
    public bool lockNose = false;
    public bool lockEyes = false;
    public bool lockMouth = false;
    public bool lockHair = false;
    public bool lockBackground = false;
    
    public bool GenerateOnStart = true;

    public int Seed = -1;
    
    
    public void GenerateAvatar()
    {
        if (Seed == -1)
        {
            Seed = Random.Range(0, 100000);
        }
        Random.InitState(Seed);
        
        GenderIdentity id = identity;
        if (id == GenderIdentity.Other)
        {
            id = (GenderIdentity) Random.Range(0, 2);
        }
        if (identity == GenderIdentity.Male)
        {
            if (!lockBody) body.GetComponent<Image>().sprite = mBodySprites[Random.Range(0, mBodySprites.Length)];
            if (!lockNose) nose.GetComponent<Image>().sprite = mNoseSprites[Random.Range(0, mNoseSprites.Length)];
            if (!lockEyes) eyes.GetComponent<Image>().sprite = mEyesSprites[Random.Range(0, mEyesSprites.Length)];
            if (!lockMouth) mouth.GetComponent<Image>().sprite = mMouthSprites[Random.Range(0, mMouthSprites.Length)];
            if (!lockHair) hair.GetComponent<Image>().sprite = mHairSprites[Random.Range(0, mHairSprites.Length)];
        }
        else
        {
            if (!lockBody) body.GetComponent<Image>().sprite = fBodySprites[Random.Range(0, fBodySprites.Length)];
            if (!lockNose) nose.GetComponent<Image>().sprite = fNoseSprites[Random.Range(0, fNoseSprites.Length)];
            if (!lockEyes) eyes.GetComponent<Image>().sprite = fEyesSprites[Random.Range(0, fEyesSprites.Length)];
            if (!lockMouth) mouth.GetComponent<Image>().sprite = fMouthSprites[Random.Range(0, fMouthSprites.Length)];
            if (!lockHair) hair.GetComponent<Image>().sprite = fHairSprites[Random.Range(0, fHairSprites.Length)];
        }
        
        if (!lockBackground) background.GetComponent<Image>().sprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];
        

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (GenerateOnStart) GenerateAvatar();
    }
    
}


