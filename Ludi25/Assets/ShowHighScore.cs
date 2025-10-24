using TMPro;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var text = GetComponent<TextMeshProUGUI>();
        text.text = ($"Has fet {PlayerPrefs.GetInt("AnimalScore")} punts!\nLa m�xima puntuaci� es de {PlayerPrefs.GetInt("AnimalHighScore")} punts!");
    }
}
