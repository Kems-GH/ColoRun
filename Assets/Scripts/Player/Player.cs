using UnityEngine;

public class Player : MonoBehaviour
{
    public ColorPick color { get; private set; } = ColorPick.White;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private ParticleSystem particleSystem;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(ColorPick color)
    {
        this.color = color;
        spriteRenderer.color = ColorPickExtensions.ToColor(color);

        particleSystem.startColor = ColorPickExtensions.ToColor(color);
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }

}
