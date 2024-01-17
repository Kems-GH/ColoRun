using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.pause)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.pause = true;

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.pause = false;
    }

    public void Restart()
    {
        Resume();
        GameManager.Instance.Restart();
    }

    public void BackToMenu()
    {
        Resume();
        GameManager.Instance.LoadMainMenu();
    }
}
