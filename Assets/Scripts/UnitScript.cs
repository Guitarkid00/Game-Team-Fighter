using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    //Following script based on Brackeys "Turn-Based Combat in Unity" video

    public string unitName;
    public int unitLevel;

    public int attack; //Originally damage in video

    public int maxHP;
    public int currentHP;

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
}
