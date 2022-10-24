using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Dictionary<Direction, Vector3> directionToRotation = new()
    {
        {Direction.Up, new Vector3(0, 0, 0) },
        {Direction.Down, new Vector3(0, 180, 0) },
        {Direction.Left, new Vector3(0, 270, 0) },
        {Direction.Right, new Vector3(0, 90, 0) }
    };
    private void Update()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        Vector3 position = new(GameData.currentPlayerPosition.x, GameData.PlayerCurrentHeight() , GameData.currentPlayerPosition.y);
        Quaternion rotation = Quaternion.Euler(directionToRotation[GameData.currentPlayerDirection]);
        transform.SetPositionAndRotation(position, rotation);
    }
}
