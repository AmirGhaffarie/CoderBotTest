using UnityEngine;

public class BlockSelectPopulator : MonoBehaviour
{
    [SerializeField] private BlockSelectItem blockSelectItemPrefab;
    private void OnEnable()
    {
        GameEvents.LevelSelected += PopulateBlocks;
    }

    private void PopulateBlocks(LevelData data)
    {
        transform.DeleteChilds();

        foreach (var block in data.availableBlocks)
        {
            Instantiate(blockSelectItemPrefab, transform).SetBlock(block);
        }

    }

    private void OnDisable()
    {
        GameEvents.LevelSelected -= PopulateBlocks;
    }
}
