using UnityEngine;

public class GameManager : MonoBehaviour
{
    public readonly int MAX_LEVEL = 2;
    public static GameManager Instance { get; private set; }
    public int currentLevel { get; private set; } = 0;
    public int timer { get; set; } = 0;
    private int timerLevel = 0;
    public BestTimeManager bestTimeManager { get; private set; }

    private bool levelMode;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        bestTimeManager = new BestTimeManager();
        bestTimeManager.LoadBestTime();
    }

    public void FinishLevel()
    {
        bestTimeManager.AddTime(currentLevel, timerLevel);
        timerLevel = 0;

        if(levelMode)
        {
            currentLevel = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
            return;
        }

        if (currentLevel == MAX_LEVEL)
        {
            currentLevel = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
            bestTimeManager.AddTime(-1, timer);
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

    public void LoadGame()
    {
        levelMode = false;
        Init(1);
    }
    public void TimePlus()
    {
        timer++;
        timerLevel++;
    }

    public void LoadLevel(int levelIndex)
    {
        levelMode = true;
        Init(levelIndex);
    }

    private void Init(int levelIndex)
    {
        timer = 0;
        timerLevel = 0;
        currentLevel = levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
    }
}
