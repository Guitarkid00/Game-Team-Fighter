using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string unitName; //Name for that specific unit
    public int unitLevel; //Current level of this unit

    public int unitID; //ID for unit, useds for index of a list of all units

    public int unitAttack; //Value used for damage calculations

    public int maxHP; //The max HP the unit has at its' current level
    public int currentHP; //The HP of the unit in battle, starts at same value as maxHP at the start of each battle

    public int baseHP; //Unit HP at level 0
    public int baseAttack; //Unit Attack at level 0
    public int PerLevelHP; //How much maxHP the unit gains for each level
    public int PerLevelAttack; //How much Attack the unit gains for each level

    public void CalcStats() //Used to set the units' stat based on its level, not currently called anywhere
    {
        maxHP = baseHP + (unitLevel * PerLevelHP);
        unitAttack = baseAttack + (unitLevel * PerLevelAttack);
        currentHP = maxHP;
    }

    
    public bool TakeDamage(int dmg) //Method for taking damage from an attack in battle
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount) //Method for restoring HP in battle, will eventually be moved once the ability system is made
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public UnitScript(string uName, int uLevel, int uAttack, int uMaxHP) //Constructor for class, might not be and is not currently used or required since units are made in prefabs, not in code
    {
        unitName = uName;
        unitLevel = uLevel;
        unitAttack = uAttack;
        maxHP = uMaxHP;
    }
}
