using UnityEngine;

public class CheetahBehaviour : RegularAnimalBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    override public void Movement()
    {
        speed += 0.2f;
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
}
