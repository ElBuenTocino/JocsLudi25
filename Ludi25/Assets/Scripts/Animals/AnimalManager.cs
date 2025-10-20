using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class AnimalManager : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject animalPrefab;
    public Transform[] spawnPoints;

    public int score = 0, maxScore;
    public TextMeshProUGUI scoreText;

    private float timer = 0f;

    public bool correct, gotToGoal;

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
            AdjustDifficulty();
            GameObject newAnimal = Instantiate(animalPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            newAnimal.GetComponent<AnimalBehaviour>().manager = this;
            if (gotToGoal) // Ajustar velocitat amb dificultat
            {
                newAnimal.GetComponent<AnimalBehaviour>().speed -= 1f;
            }
            if (newAnimal.transform.position.x > 0)
            {
                newAnimal.GetComponent<AnimalBehaviour>().speed *= -1;
            }
            gotToGoal = false;
        }
    }

    void AdjustDifficulty()
    {
        if (correct && timeToSpawn > 2)
        {
            timeToSpawn -= 0.5f;
        }
        if (!correct && timeToSpawn < 7)
        {
            timeToSpawn += 0.5f;
        }
    }

    void Win()
    {
        GetComponent<SceneHandler>().ChangeScene();
        Debug.Log("Won!");
    }
}
