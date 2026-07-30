using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;

    private int _preHeart = 10000;

    void Update()
    {
        if(_preHeart < 999 && _preHeart != ScoreManager.Instance.HitNum)
        {
            switch (ScoreManager.Instance.HitNum)
            {
                case 0:
                    Heart1.SetActive(false);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                    break;
                case 1:
                    Heart1.SetActive(true);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                    break;
                case 2:
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(false);
                    break;
                case 3:
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(true);
                    break;
                default:
                    Debug.LogWarning("ハートエラー");
                    break;
            }
        }

        _preHeart = ScoreManager.Instance.HitNum;
    }
}
