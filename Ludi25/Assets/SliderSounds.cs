using UnityEngine;
using UnityEngine.UI;

public class SliderSounds : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;
    public bool isMusic;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(isMusic ? "MusicVolume" : "SFXVolume", 1f);
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        source.volume = value;
        PlayerPrefs.SetFloat(isMusic ? "MusicVolume" : "SFXVolume", value);
    }
}

