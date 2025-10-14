using UnityEngine;

public class Seleccionar : MonoBehaviour
{
    bool select = false;
    public void Start()
    {
        select = PlayerPrefs.GetInt("Select") == 1 ? true : false;
    }
    void SelectDeselect()
    {
        select = !select;
        PlayerPrefs.SetInt("Select", select ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        Debug.Log(select);
    }
}
