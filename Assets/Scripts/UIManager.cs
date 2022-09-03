#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] TextMeshProUGUI welcomeMessage;
    [SerializeField] Button deleteSettingsFileButton;

    private void Awake()
    {
        UpdateWelcomeMessage();

#if UNITY_EDITOR
        if (deleteSettingsFileButton != null)
            deleteSettingsFileButton.gameObject.SetActive(true);
#endif
    }

    public void Exit()
    {
        MainManager.Instance.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Play()
    {
        SceneManager.LoadScene(2); // Loads Level1 Scene
    }

    public void Settings()
    {
        SceneManager.LoadScene(1); // Loads Settings Scene
    }

    public void ReturnToMenu()
    {
        UpdateWelcomeMessage();
        SceneManager.LoadScene(0); // Loads Main Menu Scene
    }

    public void DeleteSettingsFile()
    {
        MainManager.Instance.Delete();
    }

    public void SaveSettings()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.playerName = playerNameInput.text;
        }
    }

    void UpdateWelcomeMessage()
    {
        if (MainManager.Instance != null && welcomeMessage != null)
        {
            welcomeMessage.text = $"Welcome, {MainManager.Instance.playerName}";
        }
    }
}
