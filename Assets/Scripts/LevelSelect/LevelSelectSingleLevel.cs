using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectSingleLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI levelTitleTextMesh;

    private LevelData levelData;

    public void SetLevel(LevelData level)
    {
        levelData = level;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        levelTitleTextMesh.text = levelData.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.LevelSelected?.Invoke(levelData);
    }
}