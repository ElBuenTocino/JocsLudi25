using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public string sceneToChange;
    [SerializeField]
    public string scenePath;

    public void ChangeScene()
    {
        Time.timeScale = 1;
        Debug.Log($"Change Scene to {scenePath}");
        SceneManager.LoadScene(scenePath);
    }
}
