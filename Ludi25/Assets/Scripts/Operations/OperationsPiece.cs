using UnityEngine;
using TMPro;

public class OperationsPiece : MonoBehaviour
{
    public int value;
    public TMP_Text number;
    public enum Type
    {
        num1, num2, sign, answer
    }
    public Type type;
    void Start()
    {
        number = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type != Type.sign)
        {
            number.text = value.ToString();
        }   
    }
}
