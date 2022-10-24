using UnityEngine;

public class WinPanelController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private LevelList levelList;

    private void OnEnable()
    {
        GameEvents.LevelWon += ShowPanel;
    }
    private void OnDisable()
    {
        GameEvents.LevelWon -= ShowPanel;
    }

    private void ShowPanel()
    {
        winPanel.SetActive(true);
    }

    private void HidePanel()
    {
        winPanel.SetActive(false);
    }

    public void NextClicked()
    {
        HidePanel();

        GameEvents.LevelSelected?.Invoke(levelList.NextLevel());
    }

}
