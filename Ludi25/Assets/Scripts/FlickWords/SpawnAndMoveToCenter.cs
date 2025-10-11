using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class SpawnAndMoveToCenter : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject objectPrefab;
    public float spawnRadius;
    public float spawnInterval;
    public bool spawnOnEdge = true;

    [Header("Movement Settings")]
    public float moveSpeed;  // now public so it can be adjusted in inspector
    public List<WordData> possibleWords;


    private Coroutine spawnCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
        if (objectPrefab == null) return;

        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float radius = spawnOnEdge ? spawnRadius : Random.Range(0f, spawnRadius);
        Vector3 spawnPos = transform.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

        GameObject spawned = Instantiate(objectPrefab, spawnPos, Quaternion.identity);

        // Pick a random word
        WordData wordData = possibleWords[Random.Range(0, possibleWords.Count)];

        CenterObject centerObj = spawned.GetComponent<CenterObject>();
        centerObj.SetWord(wordData);

        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = spawned.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.linearDamping = 0.5f;
        }

        if (spawned.GetComponent<Collider2D>() == null)
            spawned.AddComponent<CircleCollider2D>();

        // MoveToCenter
        MoveToCenter mover = spawned.GetComponent<MoveToCenter>();
        if (mover == null) mover = spawned.AddComponent<MoveToCenter>();
        mover.target = transform;
        mover.speed = moveSpeed;



        // Flickable
        Flickable flick = spawned.GetComponent<Flickable>();
        if (flick == null) flick = spawned.AddComponent<Flickable>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
