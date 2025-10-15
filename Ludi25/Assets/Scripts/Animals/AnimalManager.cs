using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class AnimalManager : MonoBehaviour
{
    public float timeToSpawn = 2f;
    public GameObject animalPrefab;
    public Transform minY, maxY, minX, maxX;

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
            float y = Random.Range(minY.position.y, maxY.position.y);
            float x = Random.Range(0, 2);
            if (x == 1) { x = minX.position.x; }
            else { x = maxX.position.x; }
            GameObject newAnimal = Instantiate(animalPrefab, new Vector2(x, y), Quaternion.identity);
            newAnimal.GetComponent<AnimalBehaviour>().manager = this;
            if (newAnimal.transform.position.x == maxX.position.x)
            {
                newAnimal.GetComponent<AnimalBehaviour>().speed *= -1;
            }
        }
    }

    void Win()
    {
        GetComponent<SceneHandler>().ChangeScene();
        Debug.Log("Won!");
    }
}
