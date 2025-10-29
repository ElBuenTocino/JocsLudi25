using UnityEngine;
using TMPro;

public class CenterZone : MonoBehaviour
{
    public int points, goal;
    public TextMeshProUGUI scoreText;
    bool win;


    private void Update()
    {
        scoreText.text = ($"{points}/{goal}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CenterObject obj = other.GetComponent<CenterObject>();
        if (obj != null)
        {
            if (obj.isFlickable)
            {
                GetComponent<SpawnAndMoveToCenter>().correct = false;
                Debug.Log("Missed! Player should have flicked this.");
            }
            else
            {
                Debug.Log("Correct! Player left this alone.");
                GetComponent<SpawnAndMoveToCenter>().correct = true;
                points++;
                if (points >= goal)
                {
                    Win();
                }
                // TODO: apply reward
            }

            Destroy(other.gameObject);
        }
    }

    void Win()
    {
        GetComponent<SceneHandler>().ChangeScene();
        Debug.Log("Won!");
        win = true;
        PlayerPrefs.SetInt("WinWords", win ? 1 : 0);
        PlayerPrefs.Save();
    }
}

