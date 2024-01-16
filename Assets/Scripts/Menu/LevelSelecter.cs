using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelecter : MonoBehaviour
{
    [SerializeField] private int levelIndex;

    private void Start()
    {
        TMPro.TextMeshProUGUI textTime = GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1];
        textTime.text = GameManager.Instance.bestTimeManager.GetTime(levelIndex).ToString();
    }

    public void SelectLevel()
    {
        GameManager.Instance.LoadLevel(levelIndex);
    }
}
