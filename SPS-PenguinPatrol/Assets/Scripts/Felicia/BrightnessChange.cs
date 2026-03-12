using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessChange : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public Light sceneLight;

    void Start()
    {
        
    }
    void Update()
    {
        sceneLight.intensity = slider.value * 2;
    }
}
