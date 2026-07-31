using UnityEngine;

public class GemStone : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Hand"))
        {
            ScoreManager.Instance.JuelNum++;
            gameObject.SetActive(false);
        }
    }
}
