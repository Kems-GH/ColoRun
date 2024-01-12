using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private ColorPick color = ColorPick.White;

    private DoorManager doorManagerScript;

    public Collider2D collider2d { get; private set; }
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        doorManagerScript = GameObject.Find("Door Manager").GetComponent<DoorManager>();
        doorManagerScript.AddDoor(this);
        GetComponent<SpriteRenderer>().color = ColorPickExtensions.ToColor(color);
    }

    public ColorPick GetColor()
    {
        return color;
    }
}
