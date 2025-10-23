using UnityEngine;

public class RegularAnimalBehaviour : MonoBehaviour
{
    public bool isHerbivore;
    public Sprite animalSprite;
    public float speed;
    public AnimalManager manager;

    public void Start()
    {
        speed = Random.Range(speed - 0.5f, speed + 0.5f);
        gameObject.tag = "Animal";
        GetComponent<SpriteRenderer>().sprite = animalSprite;
    }

    public void Update()
    {
        Movement();
    }

    virtual public void Movement()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ProjectileH") //Get Shot by plant
        {
            if (isHerbivore)
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a herbivore");
            }
            else //Carnivore
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a carnivore");
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ProjectileC") //Get Shot by meat
        {
            if (isHerbivore)
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a herbivore");
            }
            else //Carnivore
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a carnivore");
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Goal") //Got to goal
        {
            Debug.Log("Animal Touched goal");
            manager.gotToGoal = true;
            Destroy(gameObject);
        }
    }
}
