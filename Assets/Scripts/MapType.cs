using System;
using UnityEngine;

[Serializable]
public struct MapType {
    [Range(0, 1)]
    public float height;
    public Texture2D texture;
    public Vector2 tiling;
}