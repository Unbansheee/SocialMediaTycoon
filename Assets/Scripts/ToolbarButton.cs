using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolbarButton : MonoBehaviour
{
    [SerializeField]
    GameObject Notification;

    [SerializeField]
    TextMeshProUGUI NotificationText;

    private int count = 0;

    void Awake()
    {
        Notification.SetActive(false);
    }

    public void AddNotification(int num)
    {
        if (count == 0)
        {
            Notification.SetActive(true);
        }
        count += num;
        NotificationText.text = count.ToString();
    }

    public void ClearNotifications()
    {
        count = 0;
        Notification.SetActive(false);
    }

}
