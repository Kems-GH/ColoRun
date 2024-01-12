using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
