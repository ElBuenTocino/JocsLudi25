using TMPro;
using UnityEngine;

public class PuntuacionNums : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textUI;  // referencia al texto encima de la bola
    public int objectiu;
    public int number;
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (textUI != null)
        {
            textUI.text = number+"/"+objectiu;
        }
    }
}
