using UnityEngine;
using System.Collections;

public class BunnyBehaviour : RegularAnimalBehaviour
{
    [Header("Bunny Hop Settings")]
    public float hopHeight = 2f;        // How high the bunny hops
    public float hopDuration = 0.6f;    // How long one hop lasts (up + down)
    public float hopPause = 0.2f;       // Optional pause between hops

    private bool isHopping = false;
    private float hopTimer = 0f;
    private Vector3 basePosition;

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        if (!isHopping)
            StartCoroutine(HopOnce());
    }

    private IEnumerator HopOnce()
    {
        isHopping = true;
        hopTimer = 0f;
        basePosition = transform.position;

        // Determine horizontal direction from speed sign
        float direction = Mathf.Sign(speed);

        // Target X position (move horizontally during the hop)
        float targetX = basePosition.x + (speed * hopDuration * direction);

        // Flip sprite if needed
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.flipX = direction < 0;

        while (hopTimer < hopDuration)
        {
            hopTimer += Time.deltaTime;
            float t = hopTimer / hopDuration;

            // Parabolic hop motion (smooth up and down)
            float yOffset = 4 * hopHeight * t * (1 - t);
            float newX = Mathf.Lerp(basePosition.x, targetX, t);

            transform.position = new Vector3(newX, basePosition.y + yOffset, basePosition.z);
            yield return null;
        }

        transform.position = new Vector3(targetX, basePosition.y, basePosition.z);
        isHopping = false;

        // Small pause between hops for natural timing
        yield return new WaitForSeconds(hopPause);
    }
}
