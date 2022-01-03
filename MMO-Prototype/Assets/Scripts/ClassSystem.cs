using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSystem : MonoBehaviour
{
    public static int str { get; set; }
    public static int hp { get; set; }
    public static int dex { get; set; }
    public static int mp { get; set; }
    public static int @int { get; set; }
    public int fire { get; }
    public int ice { get; }
    public int lightning { get; }
    public int magic { get; }
    public int dark { get; }
    public int poison { get; }

    public static int baseAttack, baseDefence, baseMaxHp, baseMaxMp;

    public ClassSystem()
    {
        switch (CharacterInfo.className)
        {
            case Classes.Warrior:
                baseAttack = 100;
                baseDefence = 100;
                baseMaxHp = 100;
                baseMaxMp = 100;
                str = 75;
                hp = 65;
                dex = 60;
                mp = 50;
                @int = 50;
                break;
            case Classes.Rogue:
                baseAttack = 80;
                baseDefence = 80;
                baseMaxHp = 80;
                baseMaxMp = 80;
                str = 60;
                hp = 60;
                dex = 80;
                mp = 50;
                @int = 50;
                break;
            case Classes.Magician:
                baseAttack = 50;
                baseDefence = 50;
                baseMaxHp = 60;
                baseMaxMp = 150;
                str = 50;
                hp = 50;
                dex = 50;
                mp = 80;
                @int = 70;
                break;
            case Classes.Priest:
                baseAttack = 60;
                baseDefence = 60;
                baseMaxHp = 70;
                baseMaxMp = 120;
                str = 60;
                hp = 60;
                dex = 60;
                mp = 50;
                @int = 70;
                break;
            default:
                break;
        }
    }

    public enum Classes
    {
        Warrior, Rogue, Magician, Priest
    }

    
    //public void Test()
    //{
    //    if (@class == Classes.Warrior)
    //    {
    //        baseAttack = Mathf.RoundToInt(baseAttack + (baseAttack * (str/100)));
    //    }
    //    else if (@class == Classes.Rogue)
    //    {

    //    }
    //    else if (@class == Classes.Magician)
    //    {

    //    }
    //    else if (@class == Classes.Priest)
    //    {

    //    }
    //}
}
