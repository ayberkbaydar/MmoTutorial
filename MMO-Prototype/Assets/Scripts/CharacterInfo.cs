using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public string playerName { get; }
    [Header("FIELD 1")]
    public string @class;
    public int level;
    public int str, hp, dex, mp, @int;
    public int statPoint;
    public static ClassSystem.Classes className;


    [Header("FIELD 2")]
    public int currentHp;
    public int currentMp;
    public int maxHp;
    public int maxMp;
    public int attack;
    public int defence;

    [Header("FIELD 3")]
    public int currentExp;
    public int nextLevelExp;

    void Start()
    {
        SetClass();
        SetInfo();
        @class = className.ToString();
    }

    public CharacterInfo()
    {
        SetClass();
    }
    // Update is called once per frame
    void Update()
    {
        SetInfo();
    }

    public void SetClass()
    {
        className = ClassSystem.Classes.Warrior;
    }

    public void SetInfo()
    {
        str = ClassSystem.str;
        hp = ClassSystem.hp;
        dex = ClassSystem.dex;
        mp = ClassSystem.mp;
        @int = ClassSystem.@int;
        level = LevelSystem.playerLevel;
        statPoint = LevelSystem.statPoint;
        currentHp = LevelSystem.currentHp;
        currentMp = LevelSystem.currentMp;
        maxHp = LevelSystem.maxHp;
        maxMp = LevelSystem.maxMp;
        attack = LevelSystem.attack;
        defence = LevelSystem.defence;
        currentExp = LevelSystem.currentExp;
        nextLevelExp = LevelSystem.nextLevelExp;
    }
}
