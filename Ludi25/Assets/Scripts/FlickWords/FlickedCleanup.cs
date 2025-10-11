using UnityEngine;

public class FlickedCleanup : MonoBehaviour
{
    public float maxDistance = 30f; // distance from spawn point to destroy
    private Vector3 origin;

    private void Start()
    {
        origin = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(origin, transform.position) > maxDistance)
            Destroy(gameObject);
    }
}
