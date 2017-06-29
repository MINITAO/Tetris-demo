using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour {

    private float lastFallTime;
    private bool canMove = true;
    
    void Start()
    {
        if (GridController.MakeEffectiveMove(transform, Vector3.zero))
        {
            canMove = true;
        }
        else
        {
            FindObjectOfType<GameController>().GameOver();
            canMove = false;
        }
    }

    void Update ()
    {
        if (canMove)
        {
            InputControl();
            AutoFall();
        }
        else
        {
            FindObjectOfType<Createor>().SpawnNext();
            enabled = false;
        }
	}

    /// <summary>
    /// 玩家控制方块的方向和变形
    /// </summary>
    void InputControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GridController.MakeEffectiveMove(transform, new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GridController.MakeEffectiveMove(transform, new Vector3(1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GridController.MakeEffectiveMove(transform, new Vector3(0, -1, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GridController.MakeEfffectiveRotation(transform, new Vector3(0, 0, -90));
        }
    }

    /// <summary>
    /// 控制方块的自由掉落
    /// </summary>
    void AutoFall()
    {
        int time = (int)(Time.time - lastFallTime);
        if (time>=1)
        {
            if(GridController.MakeEffectiveMove(transform, new Vector3(0, -1, 0)))
            {
                lastFallTime = Time.time;
            }
            else
            {
                canMove = false;
            }
        }
    }

}
