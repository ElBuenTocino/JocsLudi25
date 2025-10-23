using UnityEngine;

public class SnakeBehaviour : RegularAnimalBehaviour
{
    [Header("Snake Movement Settings")]
    public float waveAmplitude = 0.5f;     // Height of the zigzag wave
    public float waveFrequency = 3f;       // How fast the snake wiggles
    public float directionChangeDelay = 0f; // Optional delay before reversing speed (if you want boundaries)

    private float timeOffset;              // To make each snake’s wave unique
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        timeOffset = Random.Range(0f, Mathf.PI * 2f); // Random start phase for variety
    }

    public override void Movement()
    {
        // Move horizontally like the base class, but add a wavy vertical offset
        float xMove = speed * Time.deltaTime;
        float yOffset = Mathf.Sin((Time.time + timeOffset) * waveFrequency) * waveAmplitude;

        // Apply the motion
        transform.position += new Vector3(xMove, yOffset * Time.deltaTime, 0f);

        // Flip sprite based on direction
        if (sr != null)
            sr.flipX = speed < 0;
    }
}
