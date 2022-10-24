using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Blocks/Lighten")]
public class LightenBlock : Block
{
    public override bool CheckPossiblity()
    {
        return true;
    }

    public override IEnumerator SuccessAction()
    {
        GameEvents.Lightened?.Invoke(GameData.currentPlayerPosition);
        yield return new WaitForSeconds(.4f);
    }
}
