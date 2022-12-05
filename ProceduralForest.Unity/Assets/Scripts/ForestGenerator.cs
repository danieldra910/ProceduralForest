using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public int ForestSize = 25;
    public int ItemSpacing = 3;

    public float Offset = 1f;

    public float Scale = 1f;

    public Item[] Items;
    // Start is called before the first frame update
    void Start()
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
                        Vector3 itemPos = new Vector3(x, 0f, z);

                        Vector3 offsetPos = new Vector3(Random.Range(-Offset, Offset), 0, Random.Range(-Offset, Offset));
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(Offset, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(Scale * 0.75f, Scale * 1.25f);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
