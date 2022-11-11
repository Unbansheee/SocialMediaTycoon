using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    public TextMeshProUGUI textComponent;

    // make sure there is only ever one tooltip manager instance
    private void Awake()
    {
        if(_instance != null && _instance!= this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = Input.mousePosition + new Vector3(-(3), (transform.GetComponent<RectTransform>().rect.height/2) + 3, 0);
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
