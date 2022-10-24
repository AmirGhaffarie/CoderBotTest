using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandList : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private bool isMainCommandList;
    [SerializeField] private BlockList list;

    [Header("References")]
    [SerializeField] Transform itemsParent;
    [SerializeField] CommandListItem commandListItemPrefab;
    [Space]
    [SerializeField] Image bgImage;
    [SerializeField] TextMeshProUGUI titleTextmesh;

    bool isActive = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.CommandListSelected?.Invoke();
        isActive = true;
        UpdateSelectionVisual();
    }

    private void OnEnable()
    {
        if (isMainCommandList)
        {
            isActive = true;
            UpdateTitle();
        }
        
        UpdateSelectionVisual();

        GameEvents.LevelSelected += ResetList;
        GameEvents.CommandListSelected += ListSelected;
        GameEvents.AddBlock += AddBlock;
        GameEvents.RemoveBlock += RemoveBlock;
    }

    private void ResetList(LevelData obj)
    {
        list.Reset();
        RepopulateList();
    }

    private void OnDisable()
    {
        GameEvents.LevelSelected -= ResetList;
        GameEvents.CommandListSelected -= ListSelected;
        GameEvents.AddBlock -= AddBlock;
        GameEvents.RemoveBlock -= RemoveBlock;
    }

    private void RemoveBlock(BlockList list, int index)
    {
        if (this.list != list)
            return;

        list.RemoveAtIndex(index);
        RepopulateList();
    }

    private void AddBlock(Block block)
    {
        if (!isActive)
            return;

        list.Add(block);
        RepopulateList();
    }

    private void ListSelected()
    {
        isActive = false;
        UpdateSelectionVisual();
    }

    private void UpdateSelectionVisual()
    {
        bgImage.color = isActive ? Color.yellow : Color.white;
    }

    private void RepopulateList()
    {
        itemsParent.DeleteChilds();

        for (int i = 0; i < list.Count; i++)
        {
            Instantiate(commandListItemPrefab, itemsParent).Set(list, i);
        }
    }

    private void UpdateTitle()
    {
        titleTextmesh.text = list.name;
    }
    public void SetList(BlockList list)
    {
        this.list = list;
        UpdateTitle();
    }

}
