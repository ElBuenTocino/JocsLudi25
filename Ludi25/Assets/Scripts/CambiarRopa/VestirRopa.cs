using UnityEngine;

public class VestirRopa : MonoBehaviour
{
    bool select;

    private void Update()
    {
        select = PlayerPrefs.GetInt("Select") == 1 ? true : false;
        transform.GetChild(0).gameObject.SetActive(select);
    }
}
