using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameManager gm;

    Resolution[] resolutions;
    public Dropdown ResolutionDropdown;
    bool ScreenshakeActive;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();


        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }

        }
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }





    public void SetScreenshake()
    {

        if (ScreenshakeActive == true)
        {
            ScreenshakeActive = false;
            gm.Screenshake = false;
        }
        else if (ScreenshakeActive == false)
        {
            ScreenshakeActive = true;
            gm.Screenshake = true;
        }

    }





    public void SetVolume(float volume)

    {

        audioMixer.SetFloat("volume", volume);
    }







    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
