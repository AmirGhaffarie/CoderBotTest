using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Block List")]
public class BlockList : ScriptableObject
{
    [SerializeField] private int capacity;
    private readonly List<Block> list = new();

    public void Reset() => list.Clear();

    public int Add(Block block)
    {
        if (list.Count >= capacity)
            return -1;
        list.Add(block);
        return list.Count - 1;
    }

    public void RemoveAtIndex(int index)
    {
        if (index >= list.Count)
            return;
        list.RemoveAt(index);
    }

    public int Count => list.Count;

    public Block Get(int index)
    {
        return list[index];
    }
}
