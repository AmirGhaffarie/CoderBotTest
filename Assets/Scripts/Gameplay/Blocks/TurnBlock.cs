using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Blocks/Turn")]
public class TurnBlock : Block
{
    [SerializeField] private int turnSteps;
    public override bool CheckPossiblity()
    {
        return true;
    }

    public override IEnumerator SuccessAction()
    {
        GameData.currentPlayerDirection = GameData.currentPlayerDirection.TurnClocwise(turnSteps);
        yield return new WaitForSeconds(.4f);
    }
}
