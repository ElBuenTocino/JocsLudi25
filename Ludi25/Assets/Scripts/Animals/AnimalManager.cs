using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class AnimalManager : MonoBehaviour
{
    public float timeToSpawn = 2f;
    public GameObject animalPrefab;
    public Transform ySpawn, minX, maxX;

    public int score = 0, maxScore;
    public TextMeshProUGUI scoreText;

    private float timer = 0f;

    void Update()
    {
        SpawnAnimal();
        SetScore();
    }

    void SetScore()
    {
        scoreText.text = ($"Punts: {score}/{maxScore}");
        if (score >= maxScore)
        {
            Win();
        }
    }

    void SpawnAnimal()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0f;
            float x = Random.Range(minX.position.x, maxX.position.x);
            float y = ySpawn.position.y;
            GameObject newAnimal = Instantiate(animalPrefab, new Vector2(x, y), Quaternion.identity);
            newAnimal.GetComponent<AnimalBehaviour>().manager = this;
        }
    }

    void Win()
    {
        Debug.Log("Won!");
    }
}
