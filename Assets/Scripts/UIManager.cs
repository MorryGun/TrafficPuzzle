#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
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
        SceneManager.LoadScene(0); // Loads Main Menu Scene
    }
}
