using UnityEngine;

public class TurtleBehaviour : RegularAnimalBehaviour
{
    public float shieldCooldown;
    float timer = 0;
    bool shielding = false;
    public GameObject shield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer >= shieldCooldown)
        {
            shielding = !shielding;
            timer = 0;
        }
        if (shielding)
        {
            shield.SetActive(true);
        }
        else 
        { 
            shield.SetActive(false);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ProjectileH") //Get Shot by plant
        {
            if (isHerbivore && !shielding)
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a herbivore");
                Destroy(gameObject);
            }
            else if (!isHerbivore) //Carnivore
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a carnivore");
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ProjectileC") //Get Shot by meat
        {
            if (isHerbivore && !shielding)
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a herbivore");
            }
            else if (!isHerbivore) //Carnivore
            {
                manager.score++;
                manager.correct = true;
                Debug.Log("Correctly Hit a carnivore");
                Destroy(gameObject);
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
}
