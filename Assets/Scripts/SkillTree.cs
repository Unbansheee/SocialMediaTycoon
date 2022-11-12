using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class SkillTree : MonoBehaviour, IPointerClickHandler
{

    public enum CurrencyType
    {
        Users,
        Money,
        Data,
        Favours,
    }

    public enum SkillID
    {
        None,

        // User interaction
        Targeted_Advertising,
        AI_Assisted_Advertising,
        Automated_Advertising,
        User_Tagging,
        Facial_Recognition,
        Addictive_UX,

        // Data harvesting and trading
        Data_Scraping,
        Anonymized_Data,        // Allows selling to data brokers (req min users)
        Data_Broker,
        Research_Device_Vulnerabilities,
        Expand_App_Permissions,         // ++ fines, ++ data -users
        Deanonymization_Research,

        // Outreach
        Lobbying,               // 
        Sign_In_With_SM_Tycoon,// 
        Add_Backdoor,           // 
        Ban_Encryption,         // ++ data
        Prohibitive_Regulation, // ++users
        Acquire_Competition,
    }

    [System.Serializable]
    public class Skill
    {
        public bool skillUnlocked = false;

        [HideInInspector]
        public SkillSettings settings;

        [SerializeField]
        SkillID skillID;

        [field: SerializeField]
        public string skill;

        public string skillDescription;

        public Sprite skillIcon;

        [LabeledArray(new string[] { "Prerequisite 1", "Prerequisite 2", "Prerequisite 3", "Prerequisite 4", "Prerequisite 5", "Prerequisite 6", "Prerequisite 7", "Prerequisite 8", "Prerequisite 9", "Prerequisite 10" })]
        public List<string> prerequisiteSkills;

        public CurrencyType currency;

        [Min(0)]
        public int cost;

        public void PrintSkill()
        {
            Debug.Log("name: " + skill.ToString() + '\n' + "cost: "+ currency.ToString() + " " + cost.ToString() + '\n' + "unlocked: " + skillUnlocked);
        }

        public string SkillName()
        {
            return skillID.ToString().Replace('_', ' ');
        }
    }

    [System.Serializable]
    public class SkillTier
    {
        [LabeledArray(new string[] { "Skill 1", "Skill 2", "Skill 3", "Skill 4", "Skill 5", "Skill 6", "Skill 7", "Skill 8", "Skill 9", "Skill 10" })]
        public List<Skill> skills;
    }

    public Color lockedColor;
    public Color unlockableColor;
    public Color unlockedColor;

    public GameObject SkillButtonPrefab;

    public Vector2 buttonSize;
    public Vector2 buttonMarginPercentage;

    [HideInInspector]
    public List<GameObject> skillButtons;
    [HideInInspector]
    public List<GameObject> tierObjects;

    [LabeledArray(new string[] { "Skill Tier 1", "Skill Tier 2", "Skill Tier 3", "Skill Tier 4", "Skill Tier 5", "Skill Tier 6", "Skill Tier 7", "Skill Tier 8", "Skill Tier 9", "Skill Tier 10" })]
    public List<SkillTier> skillTree;

    public GameObject tooltipBoxPrefab;
    private GameObject instantiatedTooltipBox;

    public Transform tooltipParent;

    PlayerData playerData;

    void Awake()
    {
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerData>();
    }

    // Runs once at the beginning
    void Start()
    {
        InstantiateSkillTree(skillButtons, tierObjects, skillTree, buttonMarginPercentage);
        InstantiateTooltipBox(tooltipBoxPrefab);
        UpdateSkills();
    }


    void Update()
    {
        //UpdateSkills();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        GameObject selectedGameObject = eventData.pointerCurrentRaycast.gameObject;

        Skill selectedSkill;
        SkillSettings settings;
        GameObject selectedSkillButton;

        foreach (var skillTier in skillTree)
        {
            IEnumerable<Skill>  selectedSkills = skillTier.skills.Where(a => a.skill.ToString() == selectedGameObject.name);
            IEnumerable<GameObject> skillButtons = this.skillButtons.Where(a => a == selectedGameObject.transform.parent.gameObject);

            if (selectedSkills.Count() > 0)
            {
                selectedSkill = selectedSkills.ElementAt(0);
                settings = selectedSkill.settings;
                selectedSkillButton = skillButtons.ElementAt(0);

                UpdateSkillButton(selectedSkill, settings, true);

                //Debug.Log("preqs met: " + settings.prerequisites_met + ", has enough money: " + settings.has_enough_currency + ", is unlockable: " + settings.skill_unlockable + ", is unlocked: " + settings.skill_unlocked);
                
                break;
            }
        }
        UpdateSkills();
    }


    GameObject CreateSkillButton(Skill skillData, GameObject prefab, GameObject parent, Vector3 position)
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.name = skillData.skill.ToString();
        go.transform.SetParent(parent.transform);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.sizeDelta = buttonSize;

        // set skill setings (this will update automatically from now)
        SkillSettings skillSettings = go.transform.gameObject.GetComponent<SkillSettings>();
        skillSettings.unlockable = unlockableColor;
        skillSettings.unlocked = unlockedColor;
        skillSettings.locked = lockedColor;
        skillSettings.skill_unlocked = skillData.skillUnlocked;
        string preq = skillData.prerequisiteSkills.Count > 0 ? "\n<b>Prerequisites</b>: " + string.Join(", ", skillData.prerequisiteSkills) : "";
        skillSettings.skillDescription = "<b>" + skillData.skill.ToString() + "</b>\n\n" + skillData.skillDescription + "\n\n<b>Cost</b>: " + skillData.currency.ToString() + " " + skillData.cost + preq; 

        //Image bg = go.transform.Find("BG").GetComponent<Image>();
        //bg.color = lockedColor;

        Image icon = go.transform.Find("ICON").GetComponent<Image>();
        icon.sprite = skillData.skillIcon;
        go.transform.Find("ICON").name = go.name;

        skillData.settings = skillSettings;

        return go;
    }

    // very convoluted, no need to change things here unless you hate yourself
    void InstantiateSkillTree(List<GameObject> skillButtons, List<GameObject> tierObjects, List<SkillTier> skillTree, Vector2 buttonMarginPercentage)
    {
        RectTransform st = (RectTransform)this.transform;
        st.Rotate(0, 0, 90); // Hack to draw tree horizontally
        float button_width = buttonSize.x;
        float button_height = buttonSize.y;

        float tier_count = skillTree.Count;
        float full_tier_height = tier_count - 1 >= 0 ? (tier_count * button_height) + ((tier_count - 1) * (button_height * buttonMarginPercentage.y)) - button_height : ((tier_count - 1) * button_height) - button_height;
        float start_y = st.position.y - (full_tier_height / 2);

        float y_pos_change = 0;
        int tier_counter = 1;

        foreach (SkillTier tier in skillTree)
        {
            float skill_count = tier.skills.Count;
            float full_tier_width = skill_count - 1 >= 0 ? (skill_count * button_width) + ((skill_count - 1) * (button_width * buttonMarginPercentage.x) - button_width) : ((skill_count - 1) * button_width) - button_width;
            float start_x = st.position.x - (full_tier_width / 2);

            float x_pos_change = 0;

            GameObject tierGo = new("Tier " + tier_counter);
            tierGo.transform.SetParent(this.transform);
            tierObjects.Add(tierGo);

            foreach (Skill skill in tier.skills)
            {
                skillButtons.Add(CreateSkillButton(skill, SkillButtonPrefab, tierGo, new Vector3(x_pos_change, 0, 0)));
                x_pos_change += button_width + (button_width * buttonMarginPercentage.x);
                skillButtons[skillButtons.Count - 1].transform.Rotate(0, 0, 90); // Hack to draw tree horizontally (rotate the icons back)
            }

            tierGo.transform.position = tierGo.transform.position + new Vector3(start_x, start_y + y_pos_change, tierGo.transform.position.z);

            y_pos_change += button_height + (button_height * buttonMarginPercentage.y);
            tier_counter += 1;
        }

        GameObject parent = new("Tiers", typeof(RectTransform));
        parent.transform.SetParent(this.transform);

        foreach (GameObject tierGo in tierObjects)
        {
            tierGo.transform.SetParent(parent.transform);
        }
        st.Rotate(0, 0, -90); // Hack to draw tree horizontally (rotate parent back, tree now horizonal)
    }

    // this is the information box
    public void InstantiateTooltipBox(GameObject tooltipBoxPrefab)
    {
        instantiatedTooltipBox = Instantiate(tooltipBoxPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        instantiatedTooltipBox.name = "TooltipBox";
        instantiatedTooltipBox.transform.SetParent(tooltipParent == null ? transform.parent : tooltipParent);
    }

    // updates if a skill is unlockable, unlocked or locked
    public void UpdateSkillButton(Skill selectedSkill, SkillSettings settings, bool selected_for_purchase = false)
    {

        // count the number of prerequites that have been unlocked
        List<string> unlocked_prerequisites = new();

        foreach (var preq in selectedSkill.prerequisiteSkills)
        {
            foreach (var skillTier in skillTree)
            {
                // select prerequisite skills in this tier
                var prerequisite = skillTier.skills.Where(a => a.skill == preq).Select(a => a);
                // select unlocked prerequisites
                var unlocked_prerequisite = prerequisite.Where(a => a.skillUnlocked == true).Select(a => a.skill);
                // add to list of unlocked prerequisites
                unlocked_prerequisites.AddRange(unlocked_prerequisite);
            }
        }


        // have the prerequisite skills been unlocked?
        if (selectedSkill.prerequisiteSkills.Count > 0)
        {
            selectedSkill.prerequisiteSkills.Sort();
            unlocked_prerequisites.Sort();
            settings.prerequisites_met = unlocked_prerequisites.Count == selectedSkill.prerequisiteSkills.Count;
        }
        else
        {
            settings.prerequisites_met = true;
        }


        // do they have enough of the right currency?
        if (selectedSkill.currency == CurrencyType.Money && playerData.Money >= selectedSkill.cost)
        {
            settings.has_enough_currency = true;
        }
        else if (selectedSkill.currency == CurrencyType.Data && playerData.DataMB >= selectedSkill.cost)
        {
            settings.has_enough_currency = true;
        }
        else if (selectedSkill.currency == CurrencyType.Users && playerData.SiteUsers >= selectedSkill.cost)
        {
            settings.has_enough_currency = true;
        }
        else
        {
            settings.has_enough_currency = false;
        }


        // if you have enough currency and the prerequisites are unlocked = skill is unlockable
        if (settings.prerequisites_met && settings.has_enough_currency)
        {
            settings.skill_unlockable = true;
        }


        // if skill unlockable and the user clicked on the skill in order to buy it
        if (settings.skill_unlockable && selected_for_purchase)
        {
            if (selectedSkill.currency == CurrencyType.Money)
            {
                settings.has_enough_currency = true;
                playerData.Money -= selectedSkill.cost;
            }
            else if (selectedSkill.currency == CurrencyType.Money && playerData.DataMB >= selectedSkill.cost)
            {
                settings.has_enough_currency = true;
                //playerData.DataMB -= selectedSkill.cost;
            }
            else if (selectedSkill.currency == CurrencyType.Money && playerData.SiteUsers >= selectedSkill.cost)
            {
                settings.has_enough_currency = true;
                //playerData.SiteUsers -= selectedSkill.cost;
            }

            settings.skill_unlocked = true;
        }

        // update skill object in skill tree
        selectedSkill.skillUnlocked = settings.skill_unlocked;

    }

    // updates status for all skill buttons
    public void UpdateSkills()
    {
        foreach (SkillTier skillTier in skillTree)
        {
            foreach (Skill skill in skillTier.skills)
            {
                // foreach skill update their current UI settings
                GameObject skillButton = GameObject.Find(skill.skill.ToString());
                SkillSettings settings = skill.settings;
                UpdateSkillButton(skill, settings);
            }
        }
    }
}