using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;

    [HideInInspector] public bool isRunning = false;

    void Update()
    {
        text.text = "Time : " + GameManager.Instance.timer.ToString();
    }

    public void StartTimer()
    {
        isRunning = true;
        InvokeRepeating("IncrementTimer", 1f, 1f);
    }

    public void StopTimer()
    {
        CancelInvoke("IncrementTimer");
    }

    private void IncrementTimer()
    {
        GameManager.Instance.TimePlus();
    }
}
