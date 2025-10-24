using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ElephantBehaviour : RegularAnimalBehaviour
{
    public int health, maxHealth;
    public TextMeshProUGUI text;
    public bool isOmnivore = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        text.text = ($"{health}/{maxHealth}");
    }

    void Hit()
    {
        health--;
        if (health < 0)
        {
            health = 0;
        }
        text.text = ($"{health}/{maxHealth}");
        if (health <= 0)
        {
            manager.correct = true;
            manager.score += 2;
            Destroy(gameObject);
        }
    }

    override public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Override");

        if (isOmnivore)
        {
            if (collision.gameObject.tag == "ProjectileH" || collision.gameObject.tag == "ProjectileC")
            {
                Hit();
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "ProjectileH" && !isOmnivore) //Get Shot by plant
        {
            if (isHerbivore)
            {
                Hit();
                Debug.Log("Correctly Hit a herbivore");
            }
            else //Carnivore
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a carnivore");
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ProjectileC" && !isOmnivore) //Get Shot by meat
        {
            if (isHerbivore)
            {
                manager.correct = false;
                Debug.Log("Incorrectly Hit a herbivore");
            }
            else //Carnivore
            {
                Hit();
                Debug.Log("Correctly Hit a carnivore");
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
