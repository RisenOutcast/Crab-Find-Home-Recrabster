using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace RO.Menus
{
    public class SettingsMenu : MonoBehaviour
    {

        public AudioMixer audioMixer;

        public TMP_Dropdown resolutionDropdown;
        public TMP_InputField playerNameField;

        public Slider masterSlider;
        public Slider musicSlider;
        public Slider effectsSlider;

        Resolution[] resolutions;

        string option;
        void Start()
        {
            if (PlayerPrefs.GetFloat("masterVolume") == 0)
                normalize();
            else
                setSliders();
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                if (option != resolutions[i].width + " x " + resolutions[i].height)
                {
                    option = resolutions[i].width + " x " + resolutions[i].height;
                }
                  
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            if (PlayerPrefs.GetInt("fullscreen") == 1)
                SetFullscreen(true);
            else
                SetFullscreen(false);

        }

        void normalize()
        {
            //playerNameField.text = "";
            float defaultAudioValue = 0.75f;
            masterSlider.value = defaultAudioValue;
            musicSlider.value = defaultAudioValue;
            effectsSlider.value = defaultAudioValue;
            audioMixer.SetFloat("Master", Mathf.Log(defaultAudioValue) * 20);
            audioMixer.SetFloat("Music", Mathf.Log(defaultAudioValue) * 20);
            audioMixer.SetFloat("Effects", Mathf.Log(defaultAudioValue) * 20);
            playerNameField.text = RO.Crab.Master.instance.playerName;
        }

        void setSliders()
        {
            masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume");
            playerNameField.text = PlayerPrefs.GetString("playerName");
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetVolumeMaster(float volume)
        {
            audioMixer.SetFloat("Master", Mathf.Log(volume) * 20); //NOTE: Slider needs to be set from 0.001 to 1.5
        }

        public void SetVolumeMusic(float volume)
        {
            audioMixer.SetFloat("Music", Mathf.Log(volume) * 20); //NOTE: Slider needs to be set from 0.001 to 1.5
        }

        public void SetVolumeEffects(float volume)
        {
            audioMixer.SetFloat("Effects", Mathf.Log(volume) * 20); //NOTE: Slider needs to be set from 0.001 to 1.5
        }

        public void SetVolumeVoice(float volume)
        {
            audioMixer.SetFloat("Voice", Mathf.Log(volume) * 20); //NOTE: Slider needs to be set from 0.001 to 1.5
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void saveValues()
        {
            PlayerPrefs.SetFloat("masterVolume", masterSlider.value);
            PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
            PlayerPrefs.SetFloat("effectsVolume", effectsSlider.value);
            PlayerPrefs.SetString("playerName", playerNameField.text);
            RO.Crab.Master.instance.playerName = playerNameField.text;
            PlayerPrefs.Save();
        }

        public void deleteValues()
        {
            PlayerPrefs.DeleteAll();
        }

        public void resetAll()
        {
            deleteValues();
            normalize();
        }
    }
}