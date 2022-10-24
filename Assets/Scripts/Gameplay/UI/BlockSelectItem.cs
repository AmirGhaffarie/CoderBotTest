using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSelectItem : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] Image image;
    Block currentBlock;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.AddBlock?.Invoke(currentBlock);
    }

    public void SetBlock(Block block)
    {
        currentBlock = block;
        image.sprite = currentBlock.Icon;
    }
}
