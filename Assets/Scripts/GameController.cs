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

    public static GameState gamestate = GameState.start;

	// Use this for initialization
	void Start () {
        gamestate = GameState.running;
        FindObjectOfType<Createor>().SpawnNext();
	}

    public static void SpawnNext()
    {
        FindObjectOfType<Createor>().SpawnNext();
    }
	
    public static void GameOver()
    {
        gamestate = GameState.end;
        Debug.Log("GameOver");
    }
}
