using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    private int levelCount = 1;
    public List<Score> bestScores;

    private const string filepath = "/settings.json";
    private const string defaultPlayer = "Player";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Load();
        }
    }

    public void Save()
    {
        var data = new Settings()
        {
            PlayerName = playerName,
            Scores = bestScores
        };

        var jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(GetSettingsPath(), jsonData);
    }

    public void Load()
    {
        var path = GetSettingsPath();

        if (File.Exists(path))
        {
            var jsonData = File.ReadAllText(path);
            var data = JsonUtility.FromJson<Settings>(jsonData);

            playerName = data.PlayerName;
            bestScores = data.Scores;
        }
        else
        {
            playerName = defaultPlayer;

            CreateDefaultBestScores();
        }
    }

    public void Delete()
    {
        var path = GetSettingsPath();

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    private string GetSettingsPath()
    {
        return Application.persistentDataPath + filepath;
    }

    private void CreateDefaultBestScores()
    {
        bestScores = new List<Score>();

        for (int i = 0; i < levelCount; i++)
        {
            bestScores.Add(new Score()
            {
                PlayerName = defaultPlayer,
                BestScore = 200
            });

            Debug.Log($"Score for {defaultPlayer} is added. Current score count is {bestScores.Count}");
        }
    }

    [System.Serializable]
    public class Settings
    {
        public string PlayerName;
        public List<Score> Scores;
    }

    [System.Serializable]
    public class Score
    {
        public string PlayerName = defaultPlayer;
        public int BestScore;
    }
}
