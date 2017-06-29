using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
