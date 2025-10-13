using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class OperationsManager : MonoBehaviour
{
    public List<Operations> allOperations;
    public Operations chosenOperation;
    public List<OperationsPiece> pieces;
    public List<OperationsPiece> answers;
    public OperationsPiece sign;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChooseOperation();
        SetUp();
    }

    // Update is called once per frame                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          // type shit
    void Update()
    {
        CheckWin();
    }

    void ChooseOperation()
    {
        if (chosenOperation == null)
        {
            chosenOperation = allOperations[Random.Range(0, allOperations.Count)];
        }
    }

    void SetUp()
    {
        SetUpNumbers();
        SetUpSign();
        SetUpAnswers();
    }
    void SetUpNumbers()
    {
        int chance = Random.Range(0, 2);
        if (chance == 1)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].type == OperationsPiece.Type.num1)
                {
                    pieces[i].value = chosenOperation.number1;
                }
                else if (pieces[i].type == OperationsPiece.Type.num2)
                {
                    pieces[i].value = chosenOperation.number2;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].type == OperationsPiece.Type.num1)
                {
                    pieces[i].value = chosenOperation.number2;
                }
                else if (pieces[i].type == OperationsPiece.Type.num2)
                {
                    pieces[i].value = chosenOperation.number1;
                }
            }
        }
    }

    void SetUpSign()
    {
        switch (chosenOperation.sign)
        {
            case Operations.Sign.Suma:
                sign.number.text = "+";
                break;
            case Operations.Sign.Resta:
                sign.number.text = "-";
                break;
            case Operations.Sign.Multi:
                sign.number.text = "*";
                break;
            case Operations.Sign.Divi:
                sign.number.text = "+";
                break;
            case Operations.Sign.None:
                sign.number.text = "?";
                break;
        }
    }

    void SetUpAnswers()
    {
        List<int> chosenFalseAnswers = new List<int>();
        int trueAnswer = Random.Range(0, answers.Count);
        for (int i = 0; i < answers.Count; i++)
        {
            if (i != trueAnswer)
            {
                while (true)
                {
                    answers[i].value = chosenOperation.falseAnswers[Random.Range(0, chosenOperation.falseAnswers.Count)];
                    if (!chosenFalseAnswers.Contains(answers[i].value))
                    {
                        break;
                    }
                }
                Debug.Log("Has broken");
                chosenFalseAnswers.Add(answers[i].value);                
            }
            else
            {
                answers[i].value = chosenOperation.trueAnswer;
            }
        }
    }

        void CheckWin()
        {

        }

        void Win()
        {

        }
    
}
