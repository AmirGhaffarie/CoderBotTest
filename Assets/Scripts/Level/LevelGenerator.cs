using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Player playerPrefab;

    private void OnEnable()
    {
        GameEvents.LevelSelected += OnLevelSelected;
        GameEvents.LevelReset += OnReset;
    }

    private void OnDisable()
    {
        GameEvents.LevelSelected -= OnLevelSelected;
        GameEvents.LevelReset -= OnReset;
    }
    private void OnLevelSelected(LevelData data)
    {
        InitializeGameData(data);
        GenerateLevel();
    }
    private void OnReset()
    {
        InitializeGameData(GameData.currentSelectedLevel);
    }

    private static void InitializeGameData(LevelData data)
    {
        GameData.currentSelectedLevel = data;
        GameData.currentPlayerDirection = data.playerDirection;
        GameData.currentPlayerPosition = data.playerStartingPoint;
        PopulateLightTilesData(data);
    }

    private static void PopulateLightTilesData(LevelData data)
    {
        GameData.lightedTiles = new();
        foreach (var tile in data.tiles)
        {
            if (tile.CanBeLightedUp)
                GameData.lightedTiles.Add(tile.Position, false);
        }
    }

    private void GenerateLevel()
    {
        transform.DeleteChilds();

        GenerateTiles();

        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Instantiate(playerPrefab, transform);
    }

    private void GenerateTiles()
    {
        var tiles = GameData.currentSelectedLevel.tiles;

        foreach(var tile in tiles)
        {
            for (int i = 0; i < tile.Height; i++)
            {
                Vector3 tilePosition = new(tile.Position.x, i , tile.Position.y);
                var newTile = Instantiate(tilePrefab,tilePosition , Quaternion.identity, transform);

                if ((i == tile.Height - 1) &&
                    tile.CanBeLightedUp)
                {
                    var lightableTile = newTile.AddComponent<LightableTile>();
                    lightableTile.SetPosition(tile.Position);
                }
            }
        }
    }
}
