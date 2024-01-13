using UnityEngine;

public class GameManager : MonoBehaviour
{
    public readonly int MAX_LEVEL = 2;
    public static GameManager Instance { get; private set; }
    public int currentLevel { get; private set; } = 0;
    public int timer { get; set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    public void FinishLevel()
    {
        if (currentLevel == MAX_LEVEL)
        {
            Debug.Log("You win!");
            currentLevel = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
            return;
        }
        currentLevel++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        currentLevel = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }

    public void StartGame()
    {
        timer = 0;
        currentLevel = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }

}
