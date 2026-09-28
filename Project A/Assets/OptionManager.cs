using UnityEngine;
using UnityEngine.UI;
using FirstPersonCamera;

public class OptionsManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mainMenuPanel; // new field

    public Slider sensitivitySlider;
    public Slider volumeSlider;

    public FirstPersonCameraScript cameraScript;

    void Start()
    {
        float savedSensitivity = PlayerPrefs.GetFloat("Sensitivity", 2f);
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);

        sensitivitySlider.value = savedSensitivity;
        volumeSlider.value = savedVolume;

        ApplySensitivity(savedSensitivity);
        ApplyVolume(savedVolume);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }

    public void OnSensitivityChanged(float value)
    {
        ApplySensitivity(value);
        PlayerPrefs.SetFloat("Sensitivity", value);
    }

    public void OnVolumeChanged(float value)
    {
        ApplyVolume(value);
        PlayerPrefs.SetFloat("Volume", value);
    }

    void ApplySensitivity(float value)
    {
        if (cameraScript != null)
        {
            cameraScript.SetMouseSensitivity(value, value);
        }
    }

    void ApplyVolume(float value)
    {
        AudioListener.volume = value;
    }
}