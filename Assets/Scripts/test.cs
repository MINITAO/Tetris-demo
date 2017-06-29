using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public void PrintGrid()
    {
        Debug.Log("----------");
        for (int x = 0; x < GridController.width; x++)
        {
            for(int y = 0; y < GridController.height; y++)
            {
                Debug.Log("(" + x + "," + y + " ) " + GridController.grid[x, y]);
            }
        }
        Debug.Log("----------");
    }

}
