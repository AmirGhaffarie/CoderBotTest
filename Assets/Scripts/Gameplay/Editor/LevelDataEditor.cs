using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    Dictionary<Direction, Vector3> directionLookup = new() {
        { Direction.Up, Vector3.forward },
        { Direction.Down, Vector3.back },
        { Direction.Left, Vector3.left },
        { Direction.Right, Vector3.right }
    };
    private void OnEnable()
    {
        SceneView.duringSceneGui += SceneView_duringSceneGui;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= SceneView_duringSceneGui;
    }

    private void SceneView_duringSceneGui(SceneView obj)
    {
        LevelData levelData = (LevelData)target;

        var playerHeight = levelData.tiles.FirstOrDefault(tile => 
        tile.Position.x == levelData.playerStartingPoint.x &&
        tile.Position.y == levelData.playerStartingPoint.y).Height;

        Handles.color = Color.yellow;
        Handles.DrawWireDisc(new Vector3(levelData.playerStartingPoint.x, playerHeight, levelData.playerStartingPoint.y) + directionLookup[levelData.playerDirection] *.3f, Vector3.up, .5f);
        Handles.DrawWireDisc(new Vector3(levelData.playerStartingPoint.x, playerHeight, levelData.playerStartingPoint.y) + Vector3.up * .3f, Vector3.up,.5f);
        Handles.DrawWireDisc(new Vector3(levelData.playerStartingPoint.x, playerHeight, levelData.playerStartingPoint.y) - Vector3.up * .3f, Vector3.up,.5f);

        levelData.tiles.ForEach(
            (tile) =>
            {
                Handles.color = tile.CanBeLightedUp ? Color.blue : Color.red;
                for (int i = 0; i < tile.Height; i++)
                {
                    Handles.DrawWireCube(new Vector3(tile.Position.x,i,tile.Position.y), Vector3.one);
                }
            }
            );
    }

}