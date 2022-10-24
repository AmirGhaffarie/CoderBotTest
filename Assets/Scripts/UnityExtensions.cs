using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensions
{
    public static void DeleteChilds(this Transform transform, bool immediate = false)
    {
        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            var child = transform.GetChild(i);
            child.SetParent(null);
            if (immediate)
                GameObject.DestroyImmediate(child.gameObject);
            else
                GameObject.Destroy(child.gameObject);
        }
    }

    // we assume that the directions are sorted clocwise in the enum
    public static Direction TurnClocwise(this Direction direction, int steps)
    {
        var totalDirections = System.Enum.GetValues(typeof(Direction)).Length;
        if (steps > totalDirections || steps < -totalDirections)
            steps %= totalDirections;
        int result = ((int)direction + steps + totalDirections) % totalDirections;
        return (Direction)result;
    }

}
