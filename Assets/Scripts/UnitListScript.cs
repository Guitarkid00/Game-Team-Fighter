using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitListScript : MonoBehaviour
{
    [SerializeField]
    public List<UnitScript> UnitList = new List<UnitScript>();

    
    private void Start()
    {

        Debug.Log("UnitList Started");
        AddUnitToList();
    }

    private void AddUnitToList()
    {
        Debug.Log("Accessing AddUnits");

        foreach (UnitScript unitObj in Resources.LoadAll("Assets/Prefabs"))
        {
            if(unitObj.tag != "Unit")
            {
                Debug.Log("Non Unit Found");
            }
            else if (unitObj.tag == "Unit")
            {
                Debug.Log("Found" + unitObj.unitName);
                UnitList.Add(unitObj);
            }

        }
    }
}
