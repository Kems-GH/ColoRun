using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ColorPick color { get; private set; } = ColorPick.White;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(ColorPick color)
    {
        this.color = color;
        spriteRenderer.color = ColorPickExtensions.ToColor(color);
    }

}
