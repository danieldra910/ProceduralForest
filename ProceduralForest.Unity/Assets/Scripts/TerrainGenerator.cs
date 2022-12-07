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

        GenerateHeightMap();
        Generate();
        Forest.GenerateForest(_heightMap);
    }

    float GetHeight(Vector3 position)
    {
        return Mathf.PerlinNoise((position.x + 0.1f) / TerrainSize * TerrainScale, (position.z + 0.1f) / TerrainSize * TerrainScale) * HeightMultiplier;
    }

    void GenerateHeightMap()
    {
        for(int x=0 ;x<TerrainSize;x++)
        {
            for(int z=0 ;z<TerrainSize;z++)
            {
                _heightMap[x, z] = GetHeight(new Vector3(x, 0f, z));
            }
        }
    }

    void Generate()
    {
        Vector3[] vertices = new Vector3[TerrainSize*TerrainSize];
        int[] triangles = new int[(TerrainSize-1) * (TerrainSize-1) *6];
        Vector2[] uvs=new Vector2 [TerrainSize*TerrainSize];

        int verticesIndex = 0;
        int trianglesIndex = 0;

        for(int x=0;x<TerrainSize;x++)
        {
            for(int z = 0 ;z<TerrainSize;z++)
            {
                vertices[verticesIndex] = new Vector3(x, _heightMap[x,z], z);
                uvs[verticesIndex] = new Vector2((float)(x / TerrainSize), (float)(z / TerrainSize));

                if(x < TerrainSize-1 && z < TerrainSize-1)
                {
                    triangles[trianglesIndex] = verticesIndex;
                    triangles[trianglesIndex+1] = verticesIndex+TerrainSize+1;
                    triangles[trianglesIndex+2] = verticesIndex + TerrainSize;
                    triangles[trianglesIndex+3] = verticesIndex+TerrainSize+1;
                    triangles[trianglesIndex+4] = verticesIndex;
                    triangles[trianglesIndex+5] = verticesIndex + 1;

                    trianglesIndex += 6;
                }
                verticesIndex++;
            }
        }
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.green);
        texture.Apply();
        material.mainTexture = texture;
        meshRenderer.material = material;
    }
}
