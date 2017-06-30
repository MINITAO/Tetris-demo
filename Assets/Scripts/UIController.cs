using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text m_Timer;
    public Text m_Score;
    public Text m_GameOver;

    void Start()
    {
        m_Score.text = "0";
    }


    public void Timing()
    {
        int second = (int)(Time.time % 60);
        int minute = (int)(Time.time / 60);
        m_Timer.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void AddSore(int score)
    {
        int nowScore = int.Parse(m_Score.text);
        nowScore += score;
        m_Score.text = nowScore.ToString();
    }

    public void ShowGameOver(bool IsShow)
    {
        m_GameOver.gameObject.SetActive(IsShow);
    }

}
