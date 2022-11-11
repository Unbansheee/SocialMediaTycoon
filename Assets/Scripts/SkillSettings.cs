using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSettings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string skillDescription;
    public Color unlocked, unlockable, locked;
    public bool skill_unlocked, skill_unlockable, prerequisites_met, has_enough_currency;

    void SetUnlocked()
    {
        Image bg = gameObject.transform.Find("BG").GetComponent<Image>();
        bg.color = unlocked;
    }

    void SetUnlockable()
    {
        Image bg = gameObject.transform.Find("BG").GetComponent<Image>();
        bg.color = unlockable;
    }

    void SetLocked()
    {
        Image bg = gameObject.transform.Find("BG").GetComponent<Image>();
        bg.color = locked;
    }

    void UpdateSkill()
    {
        if (skill_unlocked)
        {
            SetUnlocked();
        }
        else if (skill_unlockable)
        {
            SetUnlockable();
        }
        else
        {
            SetLocked();
        }
    }

    void Update()
    {
        UpdateSkill();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager._instance.SetAndShowToolTip(skillDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideToolTip();
    }
}
