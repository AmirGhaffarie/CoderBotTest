using UnityEngine;

public class InGamePlayButton : MonoBehaviour
{
    public void OnClick()
    {
        GameEvents.PlayClicked?.Invoke();
    }
}
