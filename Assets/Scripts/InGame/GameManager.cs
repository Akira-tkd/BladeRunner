using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float Duration;
    public List<GemStone> GemList = new List<GemStone>();
    [SerializeField] List<GameObject> _objects;

    private bool _isRefreshing;
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

        if(GemList.Count == 0 && !_isRefreshing)
        {
            _isRefreshing = true;
            RefreshGem();
        }
    }

    async void RefreshGem()
    {
        await UniTask.Delay(60);
        foreach (var gem in _objects)
        {
            gem.SetActive(true);
        }
        _isRefreshing = false;
    }
}
