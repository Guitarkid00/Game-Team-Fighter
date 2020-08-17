using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitObject : ScriptableObject
{
    //Atk short for Attack

    public string unitName { get { return unitName; } }
    public Sprite artwork { get { return artwork; } }
    public int unitLevel { get { return unitLevel; } }
    public int baseHP { get { return baseHP; } }
    public int baseAtk { get { return baseAtk; } }
    public int perLevelHP { get { return perLevelHP; } }
    public int perLevelAtk { get { return perLevelAtk; } }
    public int maxHP { get { return maxHP; } }
    public int currentHP { get { return currentHP; } }
    public int currentAtk { get { return currentAtk; } }
}
