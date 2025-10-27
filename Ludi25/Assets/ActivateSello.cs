using UnityEngine;

public class ActivateSello : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("WinMates") == 1 && PlayerPrefs.GetInt("WinWords") == 1 && PlayerPrefs.GetInt("WinMedi") == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
