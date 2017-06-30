using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    start,
    running,
    end
}

public class GameController : MonoBehaviour {

    public static GameState gamestate;
    public int m_Score = 100;

    private UIController m_UIController;

	// Use this for initialization
	void Start () {
        m_UIController = FindObjectOfType<UIController>();
        gamestate = GameState.start;
        StartGame();
	}

    void Update()
    {
        if (gamestate == GameState.running)
        {
            m_UIController.Timing();
        }
    }


    public void StartGame()
    {
        gamestate = GameState.running;
        FindObjectOfType<Createor>().SpawnNext();
        m_UIController.ShowGameOver(false);
    }

    public void SpawnNext()
    {
        FindObjectOfType<Createor>().SpawnNext();
    }
	
    public void GameOver()
    {
        gamestate = GameState.end;
        m_UIController.ShowGameOver(true);
    }

    public void AddSorce()
    {
        m_UIController.AddSore(m_Score);
    }

}
