using UnityEngine;

public class Seleccionar : MonoBehaviour
{
    bool select = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();
    }
    public void Start()
    {
        select = PlayerPrefs.GetInt("Select") == 1 ? true : false;
    }
    void SelectDeselect()
    {
        audioManager.PlaySFX(audioManager.button2);
        select = !select;
        PlayerPrefs.SetInt("Select", select ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        Debug.Log(select);
    }
}
