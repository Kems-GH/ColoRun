using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private DoorManager doorManagerScript;

    [SerializeField] private ColorPick color = ColorPick.White;
    void Start()
    {
        doorManagerScript = GameObject.Find("Door Manager").GetComponent<DoorManager>();
        GetComponent<SpriteRenderer>().color = ColorPickExtensions.ToColor(color);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Player>().color != color)
        {
            collision.gameObject.GetComponent<Player>().SetColor(color);
            doorManagerScript.ActivateColor(color);
        }
    }
}
