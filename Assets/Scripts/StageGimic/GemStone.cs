using UnityEngine;

public class GemStone : MonoBehaviour
{
    [SerializeField] GameObject _parent;
    void OnEnable()
    {
        GameManager.Instance.GemList.Add(this);
    }

    void OnDisable()
    {
        GameManager.Instance.GemList.Remove(this);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Hand"))
        {
            ScoreManager.Instance.JuelNum++;
            _parent.SetActive(false);
        }
    }
}
