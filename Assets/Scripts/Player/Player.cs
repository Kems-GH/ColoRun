using UnityEngine;

public class Player : MonoBehaviour
{
    public ColorPick color { get; private set; } = ColorPick.White;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private new ParticleSystem particleSystem;
    ParticleSystem.MainModule particleSystemMain;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystemMain = particleSystem.main;
    }

    public void SetColor(ColorPick color)
    {
        this.color = color;
        spriteRenderer.color = ColorPickExtensions.ToColor(color);

        particleSystemMain.startColor = ColorPickExtensions.ToColor(color);
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }

}
