using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Blocks/Move")]
public class MoveBlock : Block
{
    public override bool CheckPossiblity()
    {
        
        if(GameData.TryGetTileDataInFrontOfPlayer(out LevelTileData frontTile))
        {
            if (frontTile.Height == GameData.PlayerCurrentHeight())
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
