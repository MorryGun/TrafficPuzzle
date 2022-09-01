using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public int score;
    public GameObject gameOverScreen;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject titleScreen;

    public void StartGame()
    {
        isGameActive = true;
        scoreText.gameObject.SetActive(true);
        score = 0;
        titleScreen.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";
    }
}
