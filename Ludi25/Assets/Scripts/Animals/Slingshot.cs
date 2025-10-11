using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;

    public GameObject projectilePrefab;

    public float projectilePositionOffset;

    Rigidbody2D projectile;
    Collider2D projectileCollider;

    public float force;

    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateProjectile();
    }

    void CreateProjectile()
    {
        projectile = Instantiate(projectilePrefab).GetComponent<Rigidbody2D>();
        projectileCollider = projectile.GetComponent<Collider2D>();
        projectileCollider.enabled = false;
        projectile.isKinematic = true;

        projectile.GetComponent<Projectile>().slingshotCenter = center;

        ResetStrips();
    }


    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (projectileCollider)
            {
                projectileCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        projectile.isKinematic = false;
        Vector3 projectileForce = (currentPosition - center.position) * force * -1;
        projectile.linearVelocity = projectileForce;

        projectile.GetComponent<Projectile>().Release();

        projectile = null;
        projectileCollider = null;
        Invoke("CreateProjectile", 2);
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (projectile)
        {
            Vector3 dir = position - center.position;
            projectile.transform.position = position + dir.normalized * projectilePositionOffset;
            projectile.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}