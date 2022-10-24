using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandListItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    BlockList list;
    int index;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.RemoveBlock?.Invoke(list, index);
    }

    public void Set(BlockList list, int index)
    {
        this.list = list;
        this.index = index;

        image.sprite = list.Get(index).Icon;
    }
}
