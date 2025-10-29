using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {
    AudioManager audioManager;
    public SceneHandler sceneHandler;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();
    }

    public void playButton()
    {
        audioManager.PlaySFX(audioManager.button);
        StartCoroutine(WaitForSoundToEnd(audioManager.button.length));
    }

    private IEnumerator WaitForSoundToEnd(float clipLength)
    {
        // Esperar hasta que el clip termine de reproducirse
        yield return new WaitForSeconds(clipLength);

        // Cambiar de escena después de que termine el sonido
        if (sceneHandler != null)
        {
            sceneHandler.ChangeScene();
        }
        else
        {
            Debug.LogError("SceneHandler no está asignado en el inspector");
        }
    }
    public void playWrong()
    {
        audioManager.PlaySFX(audioManager.wrong);
    }
}