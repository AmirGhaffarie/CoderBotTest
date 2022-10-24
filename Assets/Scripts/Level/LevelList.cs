using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Level List")]
public class LevelList : ScriptableObject
{
    public List<LevelData> Levels;

    public LevelData NextLevel()
    {
        var currentLevelIndex = Levels.IndexOf(GameData.currentSelectedLevel);
        var nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex >= Levels.Count)
            nextLevelIndex = Levels.Count - 1;
        return Levels[nextLevelIndex];
    }
}
