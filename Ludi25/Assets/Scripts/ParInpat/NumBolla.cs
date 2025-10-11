using UnityEngine;
using TMPro;

public class BallNumber : MonoBehaviour {
    [SerializeField] private TextMeshPro textMesh;  // referencia al texto encima de la bola
    public int number;            // el n�mero de la bola (visible en el inspector para depuraci�n)

    private float timer;

    void Start()
    {
        GenerateRandomNumber();
    }

    void GenerateRandomNumber()
    {
        number = Random.Range(1, 51); // Genera n�mero aleatorio entre 1 y 50
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 20)
        {
            Destroy(this.gameObject);
        }
    }
}
