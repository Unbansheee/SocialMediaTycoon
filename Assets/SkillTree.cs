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
        Influence
    }
  
    [System.Serializable]
    public class Skill
    {
        public bool skillUnlocked;

        [field: SerializeField]
        public SkillType skill;

        public Sprite skillIcon;
        public Color skillColor;

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
        Image icon = go.GetComponentInChildren<Image>();
        icon.color = skillData.skillColor;

        return go;
    }

    public GameObject SkillButtonPrefab;
    public GameObject panelUI;
    public Vector2 originPosition;
    public Vector2 buttonMargin;

    public List<GameObject> skillButtons;

    [LabeledArray(new string[] { "Skill Tier 1", "Skill Tier 2", "Skill Tier 3", "Skill Tier 4", "Skill Tier 5", "Skill Tier 6", "Skill Tier 7", "Skill Tier 8", "Skill Tier 9", "Skill Tier 10" })]
    public List<SkillTier> skillTree;

    // Runs once at the beginning
    void Start()
    {
        RectTransform rt = (RectTransform)SkillButtonPrefab.transform;
        float button_width = rt.rect.width;
        float button_height = rt.rect.height;
        float y_pos_change = 0;

        int tier_counter = 1;
        foreach (SkillTier tier in skillTree)
        {
            int skill_count = tier.skills.Count;
            float x_pos_change = 0;

            GameObject tierGo = new();
            tierGo.name = "Tier_" + tier_counter;
            tierGo.transform.SetParent(this.transform);

            foreach (Skill skill in tier.skills)
            {
                skillButtons.Add(CreateSkillButton(skill, SkillButtonPrefab, tierGo, new Vector3(originPosition.x + x_pos_change, originPosition.y + y_pos_change, 0)));
                x_pos_change += button_width + buttonMargin.x;
            }

            y_pos_change += button_height + buttonMargin.y;
            tier_counter += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}