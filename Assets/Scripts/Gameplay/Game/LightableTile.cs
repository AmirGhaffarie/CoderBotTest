using System;
using Unity.Mathematics;
using UnityEngine;

public class LightableTile : MonoBehaviour
{
    //state
    private bool isLightened = false;
    private int2 position;

    //reference
    private MeshRenderer meshRenderer;
    
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnEnable()
    {
        UpdateVisual();
        GameEvents.Lightened += Lightened;
        GameEvents.LevelReset += OnReset;
    }

    private void OnReset()
    {
        isLightened = false;
        UpdateVisual();
    }

    private void OnDisable()
    {
        GameEvents.Lightened += Lightened;
        GameEvents.LevelReset -= OnReset;
    }

    private void Lightened(int2 targetPos)
    {
        GameData.LightTile(targetPos);
        if(!isLightened && position.Equals(targetPos))
        {
            isLightened = true;
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        meshRenderer.material.color = isLightened ? Color.yellow : Color.cyan;
    }

    public void SetPosition(int2 position)
    {
        this.position = position;
    }
}
