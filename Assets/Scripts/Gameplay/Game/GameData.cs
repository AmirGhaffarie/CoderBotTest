using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

public static class GameData
{
    public static LevelData currentSelectedLevel;
    public static int2 currentPlayerPosition;
    public static Direction currentPlayerDirection;
    public static Dictionary<int2, bool> lightedTiles = new();


    private static readonly Dictionary<Direction, int2> directionToForwardVector = new()
    {
        { Direction.Up, new int2(0, 1) },
        { Direction.Down, new int2(0, -1) },
        { Direction.Left, new int2(-1, 0) },
        { Direction.Right, new int2(1, 0) }
    };

    public static int PlayerCurrentHeight()
    {
        return currentSelectedLevel.tiles.Find((data) => data.Position.Equals(currentPlayerPosition)).Height;
    }

    public static void MovePlayerForward()
    {
        currentPlayerPosition += directionToForwardVector[currentPlayerDirection];
    }

    public static void LightTile(int2 targetPos)
    {
        if (lightedTiles.ContainsKey(targetPos))
            lightedTiles[targetPos] = true;

        CheckForWin();
    }

    private static void CheckForWin()
    {
        if (lightedTiles.Values.All(val => val == true))
            GameEvents.LevelWon?.Invoke();
    }

    public static bool TryGetTileDataInFrontOfPlayer(out LevelTileData tileData)
    {
        tileData = new LevelTileData();

        var targetTilePosition = currentPlayerPosition + directionToForwardVector[currentPlayerDirection];

        var tileIndex = currentSelectedLevel.tiles.FindIndex((data)=> data.Position.Equals(targetTilePosition));

        if (tileIndex >= 0)
        {
            tileData = currentSelectedLevel.tiles[tileIndex];
            return true;
        }
        return false;
    }
}
