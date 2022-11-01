using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{

    [System.Serializable]
    public enum SkillType
    {
        None,
        Bending,
        Air,
        Flight,
        AstralProjection,
        Water,
        Healing,
        Blood,
        Fire,
        Lightning,
        Combustion,
        Earth,
        Metal,
        Lava,
        Master
    }

    public enum Currency
    {
        Cash,  
        Data,
        Favors
    }

    [System.Serializable]
    public class Skill
    {
        public bool skillUnlocked;

        [field: SerializeField]
        public SkillType skill;

        public Sprite skillIcon;

        [LabeledArray(new string[] { "Prerequisite 1", "Prerequisite 2", "Prerequisite 3", "Prerequisite 4", "Prerequisite 5", "Prerequisite 6", "Prerequisite 7", "Prerequisite 8", "Prerequisite 9", "Prerequisite 10" })]
        public List<SkillType> prerequisiteSkills;

        public Currency currency;

        [Range(0,10)]
        public int cost;
    }

    [System.Serializable]
    public class SkillTier
    {
        public bool tierUnlocked;

        [LabeledArray(new string[] { "Skill 1", "Skill 2", "Skill 3", "Skill 4", "Skill 5", "Skill 6", "Skill 7", "Skill 8", "Skill 9", "Skill 10" })]
        public List<Skill> skills;
    }

    GameObject CreateSkillButton(Skill skillData, GameObject prefab, GameObject parent, Vector3 position)
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.name = skillData.skill.ToString();
        go.transform.SetParent(parent.transform);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.sizeDelta = buttonSize;

        Image bg = go.transform.Find("BG").GetComponent<Image>();
        bg.color = bg_color;

        Image icon = go.transform.Find("ICON").GetComponent<Image>();
        icon.sprite = skillData.skillIcon;

        return go;
    }

    void InstantiateSkillTree(GameObject buttonPrefab, List<GameObject> skillButtons, List<GameObject> tierObjects, List<SkillTier> skillTree, Vector2 buttonMarginPercentage)
    {
        RectTransform st = (RectTransform)this.transform;
        float button_width = buttonSize.x;
        float button_height = buttonSize.y;

        float tier_count = skillTree.Count;
        float full_tier_height = tier_count - 1 >= 0 ? (tier_count * button_height) + ((tier_count - 1) * (button_height * buttonMarginPercentage.y)) : (tier_count * button_height);
        float start_y = (st.position.y + ((st.rect.height) / 2)) - ((full_tier_height) / 2);

        float y_pos_change = 0;
        int tier_counter = 1;

        foreach (SkillTier tier in skillTree)
        {
            float skill_count = tier.skills.Count;
            float full_tier_width = skill_count - 1 >= 0 ? (skill_count * button_width) + ((skill_count - 1) * (button_width * buttonMarginPercentage.x)) : (skill_count * button_width);
            float start_x = (st.position.x + ((st.rect.width)/2)) - ((full_tier_width)/2);

            float x_pos_change = 0;

            GameObject tierGo = new("Tier " + tier_counter);
            tierGo.transform.SetParent(this.transform);
            tierObjects.Add(tierGo);

            foreach (Skill skill in tier.skills)
            {
                skillButtons.Add(CreateSkillButton(skill, SkillButtonPrefab, tierGo, new Vector3(x_pos_change, 0, 0)));
                x_pos_change += button_width + (button_width * buttonMarginPercentage.x);
            }

            //tierGo.transform.position = tierGo.transform.position + new Vector3(start_x, start_y + y_pos_change, tierGo.transform.position.z);
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

        Vector3[] v = new Vector3[4];
        this.transform.Find("Tiers").GetComponent<RectTransform>().GetWorldCorners(v);

    }

    [LabeledArray(new string[] { "Color 1", "Color 2", "Color 3", "Color 4", "Color 5", "Color 6", "Color 7", "Color 8", "Color 9", "Color 10" })]
    public Color bg_color;
    public GameObject SkillButtonPrefab;
    public Vector2 buttonSize;
    public Vector2 buttonMarginPercentage;

    [HideInInspector]
    public List<GameObject> skillButtons;
    [HideInInspector]
    public List<GameObject> tierObjects;

    [LabeledArray(new string[] { "Skill Tier 1", "Skill Tier 2", "Skill Tier 3", "Skill Tier 4", "Skill Tier 5", "Skill Tier 6", "Skill Tier 7", "Skill Tier 8", "Skill Tier 9", "Skill Tier 10" })]
    public List<SkillTier> skillTree;

    // Runs once at the beginning
    void Start()
    {
        InstantiateSkillTree(SkillButtonPrefab, skillButtons, tierObjects, skillTree, buttonMarginPercentage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}