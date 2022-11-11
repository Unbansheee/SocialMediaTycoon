using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TermsAndCondiitions : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI termsText;

    const string copyText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateRandomText(int count = 100)
    {
        if (termsText == null)
            return;
        for (int i=0; i < count; ++i)
        {
            termsText.text += copyText;
            if (Random.Range(0, 3) == 0)
            {
                if (Random.Range(0, 2) == 0)
                    termsText.text += "\n";
                termsText.text += "\n\t";
            }
        }
    }
}
