using UnityEngine;

public class ProcedureListController : MonoBehaviour
{
    [SerializeField] private CommandList procedureListItemPrefab;

    private void OnEnable()
    {
        GameEvents.LevelSelected += Initialize;
    }
    private void OnDisable()
    {
        GameEvents.LevelSelected -= Initialize;
    }

    private void Initialize(LevelData data)
    {
        transform.DeleteChilds();
        foreach(var block in data.availableBlocks)
        {
            if(block is INestedBlock)
            {
                var list = (block as INestedBlock).GetBlockList();
                Instantiate(procedureListItemPrefab, transform).SetList(list);
            }
        }
    }
}
