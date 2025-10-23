using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] animalPrefabs;
    public Transform[] spawnPoints;
    bool win;

    public int score = 0, foodLeft;
    public TextMeshProUGUI scoreText;
    public Slider foodSlider;

    private float timer = 0f;

    public bool correct, gotToGoal;

    private void Start()
    {
        foodSlider.value = foodSlider.maxValue;
    }

    void Update()
    {
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
            if (newAnimal.transform.position.x > 0)
            {
                newAnimal.GetComponent<RegularAnimalBehaviour>().speed *= -1;
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
        GetComponent<SceneHandler>().ChangeScene();
        Debug.Log("Won!");
        win = true;
        PlayerPrefs.SetInt("WinMedi", win ? 1 : 0);
        PlayerPrefs.Save();
    }
}
