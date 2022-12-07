using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public int ForestSize = 25;
    public int ItemSpacing = 3;


    public Item[] Items;
    
    public void GenerateForest(float[,] heightMap)
    {
        for (int x = 0; x<ForestSize; x+= ItemSpacing)
        {
            for(int z =0; z<ForestSize;z+= ItemSpacing)
            {
                for(int i = 0; i<Items.Length; i++)
                {
                    Item item = Items[i];
                    if (item.CanPlace())
                    {
                        Vector3 itemPos = new Vector3(x, heightMap[x,z], z);

                        Vector3 offsetPos = new Vector3(Random.Range(-0.75f, 0.75f), 0, Random.Range(-0.75f, 0.75f));
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        GameObject newItem = Instantiate(item.GetRandomObject());
                        newItem.transform.position = itemPos + offsetPos;
                        newItem.transform.SetParent(transform);
                        newItem.transform.eulerAngles = rotation;
                        newItem.transform.localScale = scale;
                        break;
                    }
                }
            }
        }
    }
}
