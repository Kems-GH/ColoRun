using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject bestScore;
    void Start()
    {
        if(GameManager.Instance.timer != 0)
        {
            bestScore.SetActive(true);
            bestScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Best Score : " + GameManager.Instance.timer;
        }
    }
}
