using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int TerrainSize;
    public float TerrainScale;
    public float HeightMultiplier;

    public ForestGenerator Forest;

    private float[,] _heightMap;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        material = new Material(Shader.Find("Standard"));
        if(TerrainSize < Forest.ForestSize)
        {
            TerrainSize = Forest.ForestSize;
        }
        _heightMap = new float[TerrainSize, TerrainSize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
