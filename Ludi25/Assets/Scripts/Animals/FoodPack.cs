using UnityEngine;

public class FoodPack : MonoBehaviour
{
    public AnimalManager animalM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "ProjectileH" || collision.gameObject.tag == "ProjectileC")
        {
            animalM.foodLeft += 4;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
