using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string Name;
    public GameObject[] Prefabs;

    [Range(1, 100)]
    public int density;

    public GameObject GetRandomObject()
    {
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
    
    public bool CanPlace()
    {
        if(Random.Range(0, 100) < density)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
