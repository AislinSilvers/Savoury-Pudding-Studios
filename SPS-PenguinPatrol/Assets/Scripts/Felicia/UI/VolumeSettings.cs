using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//code from tutorial https://www.youtube.com/watch?v=G-JUp8AMEx0

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundFXSlider;

    private void Start()
    {
        /*if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }*/
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = soundFXSlider.value;
        mainMixer.SetFloat("SoundFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("soundFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        soundFXSlider.value = PlayerPrefs.GetFloat("SoundFX");

        SetMusicVolume();
        SetSFXVolume();
    }
}
