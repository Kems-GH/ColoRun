using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestTimeManager
{    
    private BestScoreList bestScores;

    [System.Serializable]
    class Time
    {
        public int level;
        public int score;
    }

    [System.Serializable]
    class BestScoreList
    {
        public List<Time> bestScores = new List<Time>();
    }

    public void SaveBestTime()
    {
        string json = JsonUtility.ToJson(bestScores);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }
    public void LoadBestTime()
    {
        string path = Application.persistentDataPath + "/bestScore.json";

        if (!File.Exists(path))
        {
            bestScores = new BestScoreList();
            return;
        }
        string json = File.ReadAllText(path);
        bestScores = JsonUtility.FromJson<BestScoreList>(json);
    }

    public void AddTime(int level, int score)
    {
        Time time = GetTimeVar(level);
        if(time != null)
        {
            if (time.score < score) return;
            bestScores.bestScores.Remove(time);
        }

        time = new Time();
        time.level = level;
        time.score = score;

        bestScores.bestScores.Add(time);
        SaveBestTime();
    }

    private Time GetTimeVar(int level)
    {
        foreach (Time bestScore in bestScores.bestScores)
        {
            if (bestScore.level == level)
            {
                return bestScore;
            }
        }
        return null;
    }

    public int GetTime(int level)
    {
        Time bestScore = GetTimeVar(level);
        if (bestScore == null) return 0;
        return bestScore.score;
    }

    public int GetTotalTime()
    {
        return GetTime(-1);
    }
}
