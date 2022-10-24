using System;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct LevelTileData
{
    public int2 Position;
    [Range(1, 10)]
    public int Height;
    public bool CanBeLightedUp;
}