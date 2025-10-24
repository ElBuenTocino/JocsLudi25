using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;    // The prefab to spawn
    public Transform[] spawnPoints;     // Array of possible spawn locations

    public float spawnDelay = 1f;       // Optional: delay between spawns
    public bool spawnOnStart = true;    // Whether to spawn automatically

    void Start()
    {
        StartCoroutine(SpawnRepeatedly());
        if (spawnOnStart)
            SpawnRandomObject();
    }

    public void SpawnRandomObject()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned!");
            return;
        }

        // Pick a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenPoint = spawnPoints[randomIndex];

        // Spawn the object at that position and rotation
        var a = Instantiate(objectToSpawn, chosenPoint.position, chosenPoint.rotation);
        a.GetComponent<FoodPack>().animalM = GetComponentInParent<AnimalManager>();
        Debug.Log("Spawn food");
    }

    // Optional: spawn repeatedly
    IEnumerator SpawnRepeatedly()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
