using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    public TextMeshProUGUI textComponent;
    public RectTransform bounds;

    public float ScreenTopPadding = 100.0f;
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
        transform.position = Input.mousePosition + new Vector3(0, 0, 0);
        
        // prevent tooltip from going off screen
        
        if (transform.position.x + bounds.rect.width * 0.25f > Screen.width)
        {
            transform.position = new Vector3(Screen.width - bounds.rect.width * 0.26f, transform.position.y, transform.position.z);
        }
        if (transform.position.x - bounds.rect.width * 0.25f < 0)
        {
            transform.position = new Vector3(bounds.rect.width * 0.26f, transform.position.y, transform.position.z);
        }
        if (transform.position.y + bounds.rect.height * 0.5f + ScreenTopPadding > Screen.height)
        {
            transform.position = new Vector3(transform.position.x, Screen.height - bounds.rect.height * 0.5f - ScreenTopPadding, transform.position.z);
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
