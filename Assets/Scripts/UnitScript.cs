using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    //Following script based on Brackeys "Turn-Based Combat in Unity" video

    public string unitName;
    public int unitLevel;

    public int unitID;

    public int unitAttack; //Originally damage in video

    public int maxHP;
    public int currentHP;

    public int baseHP;
    public int baseAttack;
    public int PerLevelHP;
    public int PerLevelAttack;

    public void CalcStats()
    {
        maxHP = baseHP + (unitLevel * PerLevelHP);
        unitAttack = baseAttack + (unitLevel * PerLevelAttack);
        currentHP = maxHP;
    }

    
    public bool TakeDamage(int dmg) //Method for taking damage from an attack
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public UnitScript(string uName, int uLevel, int uAttack, int uMaxHP) //Constructor for class
    {
        unitName = uName;
        unitLevel = uLevel;
        unitAttack = uAttack;
        maxHP = uMaxHP;
    }
}
