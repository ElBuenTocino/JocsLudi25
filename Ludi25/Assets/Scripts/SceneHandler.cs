using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public string sceneToChange;
    [SerializeField]
    public string scenePath;
    AudioManager audioManager;

    public void ChangeScene()
    {
        Time.timeScale = 1;
        Debug.Log($"Change Scene to {scenePath}");
        SceneManager.LoadScene(scenePath);
    }
}
