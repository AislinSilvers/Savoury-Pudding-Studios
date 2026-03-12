using UnityEngine;
using UnityEngine.UI;

public class BrightnessChange : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Light sceneLight;

    void OnSlider()
    {
        sceneLight.intensity = brightnessSlider.value;
    }
}
