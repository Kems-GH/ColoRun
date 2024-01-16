using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;
    void Start()
    {
        TryGetComponent(out text);
        StartTimer();
    }

    void Update()
    {
        text.text = "Time : " + GameManager.Instance.timer.ToString();
    }

    public void StartTimer()
    {
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
