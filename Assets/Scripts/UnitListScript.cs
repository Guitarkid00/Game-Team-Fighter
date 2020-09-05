using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitListScript : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> UnitList = new List<GameObject>();
    [SerializeField]
    public GameObject[] folderObjects;
    
    private void Start()
    {

        Debug.Log("UnitList Started");
        AddUnitToList();
    }

    private void AddUnitToList()
    {
        Debug.Log("Accessing AddUnits");

        folderObjects = Resources.LoadAll<GameObject>("Prefabs"); //Adds all GameObjects in the Prefabs folder to an array

        

        foreach (GameObject i in folderObjects) //foreach loop that adds the prefabs in the array to the list instead
        {
            Debug.Log(i.name);
            UnitList.Add(i);
        }

        if (UnitList.Count > 0) //Sorts the list into order based on unitID
        {
            UnitList.Sort(delegate (GameObject a, GameObject b)
            {
                return (a.GetComponent<UnitScript>().unitID).CompareTo(b.GetComponent<UnitScript>().unitID);
            });
        }

        Debug.Log("Finished");

    }
}
