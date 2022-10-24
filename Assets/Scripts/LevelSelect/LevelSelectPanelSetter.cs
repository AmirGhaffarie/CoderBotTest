using UnityEngine;

public class LevelSelectPanelSetter : MonoBehaviour
{
    [SerializeField] private LevelList levelList;

    [Header("References")]
    [SerializeField] private LevelSelectSingleLevel singleLevelPrefab;
    [SerializeField] private Transform contentParentTransform;

    //State
    bool initialized = false;

    private void OnEnable()
    {
        if (!initialized)
            Initialize();
    }

    private void Initialize()
    {
        foreach (var level in levelList.Levels)
        {
            var item = Instantiate(singleLevelPrefab, contentParentTransform);
            item.SetLevel(level);
        }
        initialized = true;
    }
}
