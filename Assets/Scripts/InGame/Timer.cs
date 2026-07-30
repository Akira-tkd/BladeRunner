using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmp;

    void Update()
    {
        _tmp.text = (90.0f - GameManager.Instance.Duration).ToString("00.00");
    }
}
