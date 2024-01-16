using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField]
    private ColorPick color = ColorPick.White;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = ColorPickExtensions.ToColor(color);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Player>().color == color)
            GameManager.Instance.FinishLevel();
    }
}
