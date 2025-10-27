using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] animalPrefabs;
    public Transform[] spawnPoints;

    public int score = 0, foodLeft;
    public TextMeshProUGUI scoreText;
    public Slider foodSlider;

    private float timer = 0f;

    public bool correct, gotToGoal;

    private void Start()
    {
        foodSlider.value = foodSlider.maxValue;
        foodLeft = (int)foodSlider.maxValue;
    }

    void Update()
    {
        if (foodLeft > foodSlider.maxValue)
        {
            foodLeft = (int)foodSlider.maxValue;
        }
        foodLeft = (int)foodSlider.value;
        SpawnAnimal();
        SetScore();
    }

    void SetScore()
    {
        scoreText.text = ($"Punts: {score}");
        if (foodSlider.value == 0)
        {
            End();
        }
    }

    void SpawnAnimal()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0f;
            AdjustDifficulty();
            GameObject newAnimal = Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            newAnimal.GetComponent<RegularAnimalBehaviour>().manager = this;
            if (gotToGoal) // Ajustar velocitat amb dificultat
            {
                newAnimal.GetComponent<RegularAnimalBehaviour>().speed -= 1f;
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

    void End()
    {
        PlayerPrefs.SetInt("AnimalScore", score);
        if (score > PlayerPrefs.GetInt("AnimalHighScore"))
        {
            PlayerPrefs.SetInt("AnimalHighScore", score);
        }
        GetComponent<SceneHandler>().ChangeScene();
        Debug.Log("Won!");
    }
}
