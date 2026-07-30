using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmp;
    [SerializeField] int _killRate;
    [SerializeField] int _juelRate;
    [SerializeField] int _hitRate;

    void Start()
    {
        var sm = ScoreManager.Instance;
        var text = _tmp.text;

        var score = sm.KillNum * _killRate + sm.JuelNum * _juelRate - sm.HitNum * _hitRate;

        text = "撃破数：" + sm.KillNum.ToString() + "\n";
        text += "宝石獲得数：" + sm.JuelNum.ToString() + "\n";
        text += "被攻撃回数：" + sm.HitNum.ToString() + "\n\n";
        text += "総合スコア：" + score.ToString();

    }
}
