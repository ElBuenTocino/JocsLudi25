using UnityEngine;

public class WinRestart : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("WinWords", 0);
        PlayerPrefs.SetInt("WinMates", 0);
        PlayerPrefs.SetInt("WinMedi", 0);
        PlayerPrefs.Save();
    }
}
