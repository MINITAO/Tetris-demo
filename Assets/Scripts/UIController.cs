using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text m_Timer;
    public Text m_Score;
    public Text m_GameOver;
    public Button m_RestartGame;
    public Button m_RollbakTitle;

    private float m_StartTime;

    void Start()
    {
        m_Score.text = "0";
        m_StartTime = Time.time;
    }


    public void Timing()
    {
        float nowTime = Time.time - m_StartTime;
        int second = (int)(nowTime % 60);
        int minute = (int)(nowTime / 60);
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
        m_RestartGame.gameObject.SetActive(IsShow);
        m_RollbakTitle.gameObject.SetActive(IsShow);
    }

    public void ResetUI()
    {
        m_Score.text = "0";
        m_StartTime = Time.time;
    }

}
