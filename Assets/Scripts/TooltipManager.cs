using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    public TextMeshProUGUI textComponent;
    public RectTransform bounds;

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
        // if RectTransform overlap the edge of the screen, move the tooltip
        if (transform.position.x + (bounds.rect.width * 0.5) > Screen.width)
        {
            transform.position = new Vector3(Screen.width - (bounds.rect.width * 0.5f), transform.position.y, transform.position.z);
        }
        else if (transform.position.x - (bounds.rect.width * 0.5) < 0)
        {
            transform.position = new Vector3((bounds.rect.width * 0.5f), transform.position.y, transform.position.z);
        }

        if (transform.position.y + bounds.rect.height > Screen.height + 32.0f)
        {
            transform.position = new Vector3(transform.position.x, Screen.height + 32.0f - bounds.rect.height, transform.position.z);
        }
        
        
        
        

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
