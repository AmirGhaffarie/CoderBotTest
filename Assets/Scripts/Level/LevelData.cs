using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/LevelData")]
public class LevelData : ScriptableObject
{
    public int2 playerStartingPoint;
    public Direction playerDirection;
    public List<LevelTileData> tiles;
    public List<Block> availableBlocks;
}