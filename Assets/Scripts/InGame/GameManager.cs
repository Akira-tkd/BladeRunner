using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float Duration;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }  
    }

    void Start()
    {
        Duration = 0f;
    }

    void Update()
    {
        Duration += Time.deltaTime;
        if(Duration > 90 || ScoreManager.Instance.HitNum >= 3)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
