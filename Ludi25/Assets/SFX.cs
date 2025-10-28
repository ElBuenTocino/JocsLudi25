using UnityEngine;

public class SFX : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();
    }

    public void playButton()
    {
        audioManager.PlaySFX(audioManager.bite);
    }

    public void playBite()
    {
        audioManager.PlaySFX(audioManager.bite);
    }
}
