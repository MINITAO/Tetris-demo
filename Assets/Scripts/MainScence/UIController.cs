using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text Timer;
    public Text Score;
    public Text GameOver;
    public Button RestartGame;
    public Button RollbakTitle;

    private float startTime;
    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // 适用于MonoBehavior的单例模式
        instance = this;
    }

    private void Start()
    {
        Score.text = "0";
        startTime = Time.time;
    }

    /// <summary>
    /// 控制UI计时
    /// </summary>
    public void Timing()
    {
        float nowTime = Time.time - startTime;
        int second = (int)(nowTime % 60);
        int minute = (int)(nowTime / 60);
        Timer.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="score"></param>
    public void AddSore(int score)
    {
        int nowScore = int.Parse(Score.text);
        nowScore += score;
        Score.text = nowScore.ToString();
    }

    /// <summary>
    /// 展示游戏结束UI
    /// </summary>
    /// <param name="IsShow"></param>
    public void ShowGameOver(bool IsShow)
    {
        GameOver.gameObject.SetActive(IsShow);
        RestartGame.gameObject.SetActive(IsShow);
        RollbakTitle.gameObject.SetActive(IsShow);
    }

    /// <summary>
    /// 重设UI
    /// </summary>
    public void ResetUI()
    {
        Score.text = "0";
        startTime = Time.time;
    }

}
