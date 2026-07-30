using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int KillNum;
    public int JuelNum;
    public int HitNum;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        KillNum = 0;
        JuelNum = 0;
        HitNum = 0;

        DontDestroyOnLoad(this.gameObject);
    }
}
