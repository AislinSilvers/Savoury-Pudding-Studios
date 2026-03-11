using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundFXSlider;

    /*private void Start()
    {
        SetMusicVolume();    
        SetSFXVolume();
    }*/

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    public void SetSFXVolume()
    {
        float volume = soundFXSlider.value;
        mainMixer.SetFloat("SoundFX", Mathf.Log10(volume) * 20);
    }

}
