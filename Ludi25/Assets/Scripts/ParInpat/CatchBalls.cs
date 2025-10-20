using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class CatchBalls : MonoBehaviour
{
    BallNumber ball;
    public bool parell;
    public PuntuacionNums puntuacionNums;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("Entra");
            ball = collision.GetComponent<BallNumber>();
            if(ball.number % 2 == 0 && parell || ball.number % 2 == 1 && !parell)
            {
                Debug.Log("Nice - "+ ball.number);
                puntuacionNums.number++;
            }
            else
            {
                Debug.Log("mal" + ball.number);
            }
            Destroy(collision.gameObject);
            if(puntuacionNums.number >= puntuacionNums.objectiu)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
