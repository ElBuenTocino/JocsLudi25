using UnityEngine;

public class Snap : MonoBehaviour
{
    public BodyType.TypeBody BodySnap;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Algo");
        if(collision.GetComponent<BodyType>().BodyPart == BodySnap)
        {
            Debug.Log("funciona");
            collision.transform.position = transform.position;
        }
    }
}
