using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Blocks/Procedure")]

public class ProcedureBlock : Block, INestedBlock
{
    [SerializeField] BlockList list;
    public override bool CheckPossiblity()
    {
        return true;
    }

    public BlockList GetBlockList()
    {
        return list;
    }

    public override IEnumerator SuccessAction()
    {
        for (int i = 0; i < list.Count; i++)
        {
            var block = list.Get(i);

            if (block.CheckPossiblity())
            {
                yield return block.SuccessAction();
            }
            else
            {
                yield return block.FailAction();
            }
        }
    }
}
