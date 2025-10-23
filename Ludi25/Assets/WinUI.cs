using UnityEngine;

public class WinUI : MonoBehaviour
{
    bool win;
    public string materia;
    private void Update()
    {
        Win(materia);
    }
    public void Win(string materia)
    {
        win = PlayerPrefs.GetInt(materia) == 1 ? true : false;
        transform.GetChild(0).gameObject.SetActive(win);
    }
}
