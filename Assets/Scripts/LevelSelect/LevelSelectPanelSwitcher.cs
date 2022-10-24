using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPanelSwitcher : MonoBehaviour
{
    //reference
    [SerializeField] GameObject levelSelectPanel;

    private void OnEnable()
    {
        GameEvents.LevelSelected += Hide;
    }
    private void OnDisable()
    {
        GameEvents.LevelSelected -= Hide;
    }

    private void Hide(LevelData obj)
    {
        levelSelectPanel.SetActive(false);
    }
}
