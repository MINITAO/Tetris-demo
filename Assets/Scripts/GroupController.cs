using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour {

    private float lastFallTime;
    private bool canMove;

    void Start()
    {
        canMove = GridController.IsVailid(transform);
        if (!canMove)
        {
            FindObjectOfType<GameController>().GameOver();
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
    /// 检测下一步是否是有效移动, 若是则进行移动, 不是则不移动
    /// </summary>
    /// <param name="nextPosition"></param>
    /// <returns>下一步是有效移动是返回true, 不是时返回false</returns>
    bool MakeEffectiveMove(Vector3 nextPosition)
    {
        if (GridController.IsVailid(nextPosition))
        {
            transform.position = nextPosition;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 检测下一步是否是有效移动, 若是则进行移动, 不是则不移动
    /// </summary>
    /// <param name="group"></param>
    /// <param name="nextPosition"></param>
    /// <returns>下一步是有效移动是返回true, 不是时返回false</returns>
    bool MakeEffectiveMove(Transform group, Vector3 nextPosition)
    {
        Vector3 nowPosition = group.position;
        group.position = nextPosition;
        if (!GridController.IsVailid(group))
        {
            group.position = nowPosition; // 回滚
            return false;
        }
        return true;
    }

    /// <summary>
    /// 玩家控制方块的方向和变形
    /// </summary>
    void InputControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 nextPosition = transform.position + new Vector3(-1, 0, 0);
            MakeEffectiveMove(transform, nextPosition);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 nextPosition = transform.position + new Vector3(1, 0, 0);
            MakeEffectiveMove(transform, nextPosition);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 nextPosition = transform.position + new Vector3(0, -1, 0);
            MakeEffectiveMove(transform, nextPosition);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Quaternion nowRotation = transform.rotation;
            transform.Rotate(new Vector3(0, 0, -90));
            if(!GridController.IsVailid(transform))
            {
                transform.rotation = nowRotation;   //回滚
            }
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
            Vector3 nextPosition = transform.position + new Vector3(0, -1, 0);
            if(MakeEffectiveMove(nextPosition))
            {
                lastFallTime = Time.time;
            }
        }
    }

}
