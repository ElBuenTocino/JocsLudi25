using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip bite;
    public AudioClip pop;
    


    private void Start()
    {
        musicSource.clip = background;
        musicSource.volume = 0.25f;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
}
