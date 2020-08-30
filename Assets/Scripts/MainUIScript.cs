using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour
{
    public GameObject SettingsPanel;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider ButtonSlider;

    public void OpenSettings()
    {
        if(SettingsPanel != null)
        {
            SettingsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Game has been CLOSED");
        Application.Quit();
    }

    public void MuteAll() //Change this to mute mixer eventually instead of moving sliders
    {
        MasterSlider.value = -80;
        MusicSlider.value = -80;
        ButtonSlider.value = -80;
    }
}
