using System;
using Unity.Mathematics;

public static class GameEvents
{
    public static Action PlayClicked;
    public static Action LevelWon;
    public static Action LevelReset;
    public static Action<int2> Lightened;
    public static Action<LevelData> LevelSelected;
    public static Action<Block> AddBlock;
    public static Action<BlockList,int> RemoveBlock;
    public static Action CommandListSelected;
}
