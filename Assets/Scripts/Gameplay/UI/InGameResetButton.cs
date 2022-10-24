using UnityEngine;

public class InGameResetButton : MonoBehaviour
{
    public void OnClick()
    {
        GameEvents.LevelReset?.Invoke();
    }
}
