using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Operation", menuName = "Scriptable Objects/Create Operation")]
public class Operations : ScriptableObject
{
    public int number1;

    public enum Sign
    {
        None,
        Suma,
        Resta,
        Multi,
        Divi
    }

    public Sign sign;

    public int number2;
    public int trueAnswer;
    public List<int> falseAnswers;
}
