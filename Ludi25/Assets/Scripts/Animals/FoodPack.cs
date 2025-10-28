using UnityEngine;

public class FoodPack : MonoBehaviour
{
    public AnimalManager animalM;
    public float lifetime = 10f; // Time in seconds before this object destroys itself

    void Start()
    {
        // Schedule self-destruction after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("ProjectileH") || collision.gameObject.CompareTag("ProjectileC"))
        {
            animalM.foodSlider.value += 4;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
