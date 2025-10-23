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
        speed = Mathf.Pow(speed, 2) + 0.1f * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
}
