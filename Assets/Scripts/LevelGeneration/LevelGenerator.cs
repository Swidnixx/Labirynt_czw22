using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D picture;
    public ColorMapping[] mappings;
    public float offset = 5;

    public void ClearLevel()
    {
        for(int i=transform.childCount-1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public void GenerateLevel()
    {
        for(int x=0; x<picture.width; x++)
        {
            for(int y=0; y<picture.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int z)
    {
        Color pixelColor = picture.GetPixel(x, z);
        foreach(var mapping in mappings)
        {
            if(mapping.color == pixelColor)
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(mapping.prefab, position, Quaternion.identity, transform);
            }
        }

    }
}
