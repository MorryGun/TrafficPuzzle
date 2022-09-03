using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public int score;
    public GameObject gameOverScreen;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    [SerializeField] int level = 0;

    private void Awake()
    {
        isGameActive = true;
    }

    void Start()
    {
        scoreText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        score = 0;
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";

        if (MainManager.Instance != null)
        {
            var currentPlayer = MainManager.Instance.playerName;
            var bestScore = MainManager.Instance.bestScores[level];

            if (score > bestScore.BestScore)
            {
                MainManager.Instance.bestScores[level] = new MainManager.Score() 
                { 
                    PlayerName = currentPlayer,
                    BestScore = score
                };
            }

            bestScoreText.text = $"Best Score: {bestScore.BestScore} ({bestScore.PlayerName})";
        }
    }
}
