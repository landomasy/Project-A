using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // replace with your actual scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}