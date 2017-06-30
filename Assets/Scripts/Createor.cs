using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createor : MonoBehaviour {

    public Transform[] groups;

    public void SpawnNext()
    {
        if(GameController.gamestate != GameState.end)
        {
            Instantiate(groups[Random.Range(0, groups.Length)], transform.position, Quaternion.identity);
        }
    }
}
