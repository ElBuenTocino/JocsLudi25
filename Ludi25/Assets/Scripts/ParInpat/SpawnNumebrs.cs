using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnRangeX = 8f;
    [SerializeField] private float spawnHeight = 6f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBall), 0f, spawnInterval);
    }

    void SpawnBall()
    {
        Vector3 position = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, 0f);
        Instantiate(ballPrefab, position, Quaternion.identity);
    }
    
}