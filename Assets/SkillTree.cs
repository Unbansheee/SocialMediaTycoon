using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class SkillTree : MonoBehaviour
{

    // Input Setup 

    public enum SkillType
    {
        None,
        SkillA1,
        SkillA2,
        SkillA3,
        SkillB1,
        SkillB2,
        SkillB3,
        SkillC1,
        SkillC2,
        SkillC3,
        SkillD1,
        SkillD2,
        SkillD3
    }

    public enum Currency
    {
        Cash,
        Data,
        Influence
    }

    [System.Serializable]
    public class Col_1
    {
        public SkillType skill;
        public Sprite skillImage;
        public Color skillColor;
        public SkillType parentSkill1;
        public SkillType parentSkill2;
        public SkillType parentSkill3;
        public bool unlocked;
    }

    [System.Serializable]
    public class Col_2
    {
        public Currency currency;
        public int cost;
    }

    [System.Serializable]
    public class Skills : UDictionary<Col_1, Col_2> {}

    [UDictionary.Split(65, 35)]
    public Skills[] skillTree;


    // Runs once at the beginning
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}