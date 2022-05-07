using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color hasColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : hasColor;
    }

    public void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    public void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}