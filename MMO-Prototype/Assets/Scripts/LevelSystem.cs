using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public GameObject player;

    public static int playerLevel;
    public int maxLevel = 45;
    public static int currentExp;
    public int[] nextLevelExpTable;
    public static int nextLevelExp;

    public static int currentHp, currentMp, maxHp, maxMp;
    public static int attack, defence;
    public static int statPoint;


    public LevelSystem()
    {
    }

    void Start()
    {
        playerLevel = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        attack = ClassSystem.baseAttack;
        defence = ClassSystem.baseDefence;
        maxHp = ClassSystem.baseMaxHp;
        maxMp = ClassSystem.baseMaxMp;
        currentHp = maxHp;
        currentMp = maxMp;
        statPoint = 0;
        nextLevelExpTable = new int[maxLevel + 1];
        nextLevelExp = nextLevelExpTable[1] = 1000;
        for (int i = 2; i < maxLevel; i++)
        {
            nextLevelExpTable[i] = Mathf.RoundToInt(nextLevelExpTable[i - 1] * 1.1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddExp(200);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddStat("str");
        }
    }
    public void AddExp(int experience)
    {
        currentExp += experience;
        if (currentExp >= nextLevelExpTable[playerLevel] && playerLevel < maxLevel)
        {
            LevelUp();
        }
        if (playerLevel >= maxLevel)
        {
            currentExp = 0;
        }
    }

    public void LevelUp()
    {
        currentExp -= nextLevelExpTable[playerLevel];
        playerLevel++;
        nextLevelExp = nextLevelExpTable[playerLevel];

        maxHp = Mathf.RoundToInt(maxHp * 1.2f);
        currentHp = maxHp;
        maxMp += 20;
        currentMp = maxMp;
        attack = attack + Mathf.CeilToInt(ClassSystem.baseAttack * 1.1f);
        defence = defence + Mathf.RoundToInt(ClassSystem.baseDefence * 1.05f);

        if (playerLevel <= 30)
        {
            statPoint = statPoint + 3;
        }
        else if (playerLevel > 30)
        {
            statPoint = statPoint + 5;
        }

    }

    public void AddStat(string statName)
    {
        if (statPoint >= 1 && statName == "str")
        {
            statPoint--;
            ClassSystem.str++;
        }
        else if (statPoint >= 1 && statName == "hp")
        {
            statPoint--;
            ClassSystem.hp++;
        }
        else if (statPoint >= 1 && statName == "dex")
        {
            statPoint--;
            ClassSystem.dex++;
        }
        else if (statPoint >= 1 && statName == "mp")
        {
            statPoint--;
            ClassSystem.mp++;
        }
        else if (statPoint >= 1 && statName == "int")
        {
            statPoint--;
            ClassSystem.@int++;
        }
    }
}
