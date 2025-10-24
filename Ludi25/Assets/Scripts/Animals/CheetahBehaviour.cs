using UnityEngine;

public class CheetahBehaviour : RegularAnimalBehaviour
{
    public float acceleration = 0.1f;
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
        speed += acceleration * Time.deltaTime;

        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );
    }
}
