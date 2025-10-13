using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool collided;
    public float lifetime = 5f;
    public Transform slingshotCenter;
    public float maxDistanceFromSlingshot;


    public void Release()
    {
        PathPoint.instance.Clear();
        StartCoroutine(CreatePathPoints());
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (collided)
                break;

            if (Vector3.Distance(transform.position, slingshotCenter.position) > maxDistanceFromSlingshot)
            {
                Destroy(gameObject);
                yield break;
            }

            PathPoint.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoint.instance.timeInterval);
        }
    }


    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }
}
