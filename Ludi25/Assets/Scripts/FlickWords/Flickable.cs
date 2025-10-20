using UnityEngine;

public class Flickable : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastMousePos;
    private Vector3 mouseDelta;
    private bool dragging = false;

    [Header("Flick Settings")]
    public float flickForceMultiplier = 100f;
    public float minFlickForce = 25f;
    public float spinMultiplier = 500f; // max angular velocity for spin
    public SpawnAndMoveToCenter spawnAndMoveToCenter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        dragging = true;
        lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastMousePos.z = 0f;
    }

    private void OnMouseDrag()
    {
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePos.z = 0f;

        mouseDelta = currentMousePos - lastMousePos;
        lastMousePos = currentMousePos;
    }

    private void OnMouseUp()
    {
        if (!dragging) return;

        Vector2 flickVector = mouseDelta * flickForceMultiplier;

        if (flickVector.magnitude < minFlickForce)
            flickVector = flickVector.normalized * minFlickForce;

        rb.AddForce(flickVector, ForceMode2D.Impulse);

        MoveToCenter mover = GetComponent<MoveToCenter>();
        if (mover != null) mover.Flicked();

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Allow rotation and add strong spin
        rb.constraints = RigidbodyConstraints2D.None;

        // Spin magnitude 300–500, random direction
        float spinMag = Random.Range(300f, 500f);
        float spinSign = Random.value < 0.5f ? 1f : -1f;
        rb.angularVelocity = spinMag * spinSign;

        if (GetComponent<FlickedCleanup>() == null)
            gameObject.AddComponent<FlickedCleanup>();

        dragging = false;

        CenterObject obj = GetComponent<CenterObject>();
        if (obj != null)
        {
            if (obj.isFlickable)
            {
                // Correct flick
                spawnAndMoveToCenter.correct = true;
                Debug.Log("Correct Flick!");
            }
            else
            {
                // Wrong flick, penalty
                spawnAndMoveToCenter.correct = false;
                Debug.Log("Incorrect Flick..");
            }
        }
    }
}
