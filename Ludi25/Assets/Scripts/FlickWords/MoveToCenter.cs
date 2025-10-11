using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public float speed = 50f; // public now for tweaking

    private Rigidbody2D rb;
    private bool isFlicked = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target == null || rb == null || isFlicked) return;

        Vector2 dir = (target.position - transform.position).normalized;
        rb.AddForce(dir * speed, ForceMode2D.Force);

        if (Vector2.Distance(transform.position, target.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Flicked()
    {
        isFlicked = true;
    }
}
