using UnityEngine;

public class RegularAnimalBehaviour : MonoBehaviour
{
    public bool isHerbivore;
    public Sprite animalSprite;
    public float speed;
    public AnimalManager manager;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioManager>();
    }

    public void Start()
    {
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

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ProjectileH") //Get Shot by plant
        {
            if (isHerbivore)
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a herbivore");
                OnHit(true);
            }
            else //Carnivore
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a carnivore");
                OnHit(false);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ProjectileC") //Get Shot by meat
        {
            if (isHerbivore)
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a herbivore");
                OnHit(false);
            }
            else //Carnivore
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a carnivore");
                OnHit(true);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Goal") //Got to goal
        {
            Debug.Log("Animal Touched goal");
            manager.gotToGoal = true;
            Destroy(gameObject);
        }
    }

    public virtual void OnHit(bool goodHit)
    {
        if (goodHit)
        {
            GetComponent<SpriteRenderer>().color = new Color(0,1,0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
        audioManager.PlaySFX(audioManager.bite);
        var sca = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(sca.x + 0.01f, sca.y + 0.01f, sca.z + 0.01f);
        Destroy(gameObject, 0.05f);
    }
}
