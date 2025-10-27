using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class CatchBalls : MonoBehaviour
{
    BallNumber ball;
    public bool parell, win;
    public PuntuacionNums puntuacionNums;
    public BallSpawner ballSpawner;
    public float spawnInt;
    private void Start()
    {
        win = PlayerPrefs.GetInt("WinMates") == 1 ? true : false;
        spawnInt = ballSpawner.spawnInterval;
    }
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
                indreaseDiff();
            }
            else
            {
                Debug.Log("mal" + ball.number);
                lowerDiff();
            }
            Destroy(collision.gameObject);
            if(puntuacionNums.number >= puntuacionNums.objectiu)
            {
                win = true;
                PlayerPrefs.SetInt("WinMates", win ? 1 : 0);
                PlayerPrefs.Save();
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void indreaseDiff()
    {
        ballSpawner.spawnInterval -= puntuacionNums.number/10*2;
    }
    private void lowerDiff()
    {
        ballSpawner.spawnInterval = spawnInt;
    }
}
