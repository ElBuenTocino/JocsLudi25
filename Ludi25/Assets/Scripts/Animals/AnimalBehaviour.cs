using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public bool isHerbivore;
    public Sprite[] herbivoreSprites, carnivoreSprites;
    public int speed;
    public AnimalManager manager;

    private void Start()
    {
        gameObject.tag = "Animal";
        int chance = Random.Range(0, 3);
        if (chance == 0)
        {
            isHerbivore = true;
            GetComponent<SpriteRenderer>().sprite = herbivoreSprites[Random.Range(0, herbivoreSprites.Length)];
        }
        else
        {
            isHerbivore = false;
            GetComponent<SpriteRenderer>().sprite = carnivoreSprites[Random.Range(0, carnivoreSprites.Length)];
        }
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile") //Get Shot
        {
            if (isHerbivore)
            {
                if (manager.score > 0)
                {
                    manager.score--;
                }

                Debug.Log("Hit a herbivore");
            }
            else //Carnivore
            {
                //manager.score++;
                Debug.Log("Hit a carnivore");
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Goal") //Get to goal
        {
            Debug.Log("Animal Touched goal");
            if (isHerbivore)
            {
                manager.score++;
            }
            else //Carnivore
            {
                if (manager.score > 0)
                {
                    manager.score--;
                }
            }
            Destroy(gameObject);
        }
    }
}
