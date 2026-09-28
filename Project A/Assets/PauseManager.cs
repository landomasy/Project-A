using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused = false;

    public MonoBehaviour playerControllerScript;
    public MonoBehaviour cameraScript;
    public MonoBehaviour shootingScript;

    void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.gameActive)
            return; // don't allow pausing once game over has triggered

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
{
    pausePanel.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    if (playerControllerScript != null) playerControllerScript.enabled = false;
    if (cameraScript != null) cameraScript.enabled = false;
    if (shootingScript != null) shootingScript.enabled = false;
}

public void Resume()
{
    pausePanel.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    if (playerControllerScript != null) playerControllerScript.enabled = true;
    if (cameraScript != null) cameraScript.enabled = true;
    if (shootingScript != null) shootingScript.enabled = true;
}

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}