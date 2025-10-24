using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float minPullDistance = 0.5f;

    Rigidbody2D projectile;
    Collider2D projectileCollider;

    public float force;
    public Slider foodSlider;

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

            Vector3 pullDir = (currentPosition - center.position).normalized;
            bool wouldShootDown = (-pullDir.y < 0);

            Color lineColor = wouldShootDown ? Color.red : Color.white;
            lineRenderers[0].startColor = lineColor;
            lineRenderers[0].endColor = lineColor;
            lineRenderers[1].startColor = lineColor;
            lineRenderers[1].endColor = lineColor;

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
        float pullDistance = Vector3.Distance(currentPosition, center.position);
        if (pullDistance < minPullDistance)
        {
            ResetStrips();
            projectile.transform.position = idlePosition.position;
            projectile.isKinematic = true;
            projectileCollider.enabled = false;
            return;
        }
        Vector3 pullDirection = (currentPosition - center.position).normalized;
        if (-pullDirection.y < 0)
        {
            ResetStrips();
            projectile.transform.position = idlePosition.position;
            projectile.isKinematic = true;
            projectileCollider.enabled = false;
            return;
        }
        projectile.isKinematic = false;
        Vector3 projectileForce = (currentPosition - center.position) * force * -1;
        projectile.linearVelocity = projectileForce;

        projectile.GetComponent<Projectile>().Release();

        projectile = null;
        projectileCollider = null;
        foodSlider.value--;
        Invoke("CreateProjectile", 0.5f);
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