using UnityEngine;
using TMPro;

public class CenterObject : MonoBehaviour
{
    public string word;
    public bool isFlickable; // true = must flick, false = must not flick

    public TextMeshProUGUI textMesh; // assign a TMP component on the object

    public void SetWord(WordData data)
    {
        word = data.word;
        isFlickable = data.isFlickable;

        if (textMesh != null)
            textMesh.text = word;
    }
}
