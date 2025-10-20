using UnityEngine;
using TMPro;

public class CenterObject : MonoBehaviour
{
    public Sprite word;
    public bool isFlickable; // true = must flick, false = must not flick

    public TextMeshProUGUI textMesh; // assign a TMP component on the object

    public void SetWord(WordData data)
    {
        word = data.word;
        GetComponent<SpriteRenderer>().sprite = word;
        isFlickable = data.isFlickable;
    }
}
