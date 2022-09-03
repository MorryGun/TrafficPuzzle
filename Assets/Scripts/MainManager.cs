using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string PlayerName;
    private int levelCount = 10;
    public int[] bestScores;

    private const string filepath = "/settings.json";

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
            PlayerName = PlayerName,
            BestScores = bestScores
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

            PlayerName = data.PlayerName;
            bestScores = data.BestScores;
        }
        else 
        {
            PlayerName = "Player";
            bestScores = new int[levelCount];
        }
    }

    private string GetSettingsPath()
    {
       return Application.persistentDataPath + filepath;
    }

    [SerializeField]
    public class Settings
    {
        public string PlayerName;
        public int[] BestScores;
    }
}
