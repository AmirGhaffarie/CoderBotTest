using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Blocks/Jump")]
public class JumpBlock : Block
{
    public override bool CheckPossiblity()
    {
        if(GameData.TryGetTileDataInFrontOfPlayer(out LevelTileData frontTile))
        {
            if (Mathf.Abs(GameData.PlayerCurrentHeight() - frontTile.Height) == 1)
                return true;
        }

        return false;
    }


    public override IEnumerator SuccessAction()
    {
        GameData.MovePlayerForward();
        yield return new WaitForSeconds(.4f);
    }
}
