using UnityEngine;

public class DragAllRestricted2 : MonoBehaviour {
    [SerializeField] private LayerMask movableLayers;
    [SerializeField] private bool isMoveRestrictedToScreen = false;

    private Transform dragging = null;
    private Vector3 offset;
    private Vector3 extents;
    private float fixedY; // Guardaremos la posición Y original

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast desde la cámara hacia el mouse
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero,
                float.PositiveInfinity,
                movableLayers
            );

            if (hit)
            {
                dragging = hit.transform;
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                extents = dragging.GetComponent<SpriteRenderer>().sprite.bounds.extents;

                // Guardar la Y original (para mantenerla fija)
                fixedY = dragging.position.y;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        if (dragging != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            // Mantener la Y (y Z si aplica) fijas
            pos.y = fixedY;
            pos.z = dragging.position.z;

            if (isMoveRestrictedToScreen)
            {
                Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
                Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
                pos.x = Mathf.Clamp(pos.x, bottomLeft.x + extents.x, topRight.x - extents.x);
            }

            dragging.position = pos;
        }
    }
}
