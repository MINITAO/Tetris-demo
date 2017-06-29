using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    private static Transform borderLeft;
    private static Transform borderRight;

    void Start()
    {
        GameObject border = GameObject.FindGameObjectWithTag("Border");
        borderLeft = border.transform.Find("borderLeft") as Transform;
        borderRight = border.transform.Find("borderRight") as Transform;
    }

    /// <summary>
    /// 对传入的Vector2四舍五入int的坐标值
    /// </summary>
    /// <param name="v"></param>
    /// <returns>对x,y四舍五入后的新Vector2</returns>
    static Vector2 Vector2Round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    /// <summary>
    /// 做有效的移动
    /// </summary>
    /// <param name="group"></param>
    /// <param name="nextPosition"></param>
    /// <returns>若能够成功则返回true, 不能则返回false</returns>
    public static bool MakeEffectiveMove(Transform group, Vector3 offset)
    {
        Vector3 nowPos = group.position;
        Vector3 nextPos = Vector2Round(group.position + offset);
        if (IsValidMove(group, offset))
        {
            UpdateGridByOffset(group, offset);
            group.position = nextPos;
            return true;
        }
        else
        {
            group.position = nowPos;
            return false;
        }
    }

    /// <summary>
    /// 做有效旋转
    /// </summary>
    /// <param name="group"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public static bool MakeEfffectiveRotation(Transform group, Vector3 rotation)
    {
        if (IsValidRotate(group, rotation))
        {
            UpdateGridByRotate(group, rotation);
            group.Rotate(rotation);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 通过位移来更新网格数据
    /// </summary>
    /// <param name="now"></param>
    /// <param name="offset"></param>
    public static void UpdateGridByOffset(Transform group, Vector3 offset)
    {
        foreach(Transform child in group)
        {
            grid[(int) child.position.x, (int) child.position.y] = null;
        }
        foreach(Transform child in group)
        {
            Vector3 pos = child.position + offset;
            if((int)pos.y > height)
            {
                continue;
            }
            else
            {
                grid[(int)pos.x, (int)pos.y] = child;
            }
            
        }
    }

    /// <summary>
    /// 通过选择来更新网格数据
    /// </summary>
    /// <param name="group"></param>
    /// <param name="rotation"></param>
    static void UpdateGridByRotate(Transform group, Vector3 rotation)
    {
        foreach (Transform child in group)
        {
            grid[(int)child.position.x, (int)child.position.y] = null;
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(grid[x, y])
                    Debug.Log("( " + x + ", " + y + ")" + grid[x, y]);
            }

        }
        group.Rotate(rotation);
        foreach(Transform child in group)
        {
            grid[(int)child.position.x, (int)child.position.y] = child;
        }
        group.Rotate(-rotation);


    }

    /// <summary>
    /// 判断是否是有效位移
    /// </summary>
    /// <param name="group"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    static bool IsValidMove(Transform group, Vector3 offset)
    {
        return InBorderAfterMove(group, offset) && IsEffectiveGridAfterMove(group, offset);
    }

    /// <summary>
    /// 判断是否是有效旋转
    /// </summary>
    /// <param name="group"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    static bool IsValidRotate(Transform group, Vector3 rotation)
    {
        return InBorderAfterRotate(group, rotation) && IsEffectiveGridAfterRotate(group, rotation);
    }

    /// <summary>
    /// 判断边界的通用逻辑
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    static bool IsInBorder(Vector3 pos)
    {
        bool isIn = (pos.x >= borderLeft.position.x &&
                     pos.x <= borderRight.position.x &&
                     pos.y >= 0) ? true: false;
        return isIn;
    }

    /// <summary>
    /// 判断下一步位移后, 所有的方格是否都在边界内
    /// </summary>
    /// <param name="group"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    static bool InBorderAfterMove(Transform group, Vector3 offset)
    {
        foreach (Transform child in group)
        {
            Vector3 nextPos = child.position + offset;
            if (!IsInBorder(nextPos))
                return false;
        }
        return true;
    }

    /// <summary>
    /// 判断下一步旋转后, 所有的方格是否都在边界内
    /// </summary>
    /// <param name="now"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    static bool InBorderAfterRotate(Transform now, Vector3 rotation)
    {
        bool isIn = true;
        now.Rotate(rotation);
        foreach(Transform child in now)
        {
            if (!IsInBorder(child.position))
            {
                isIn = false;
                break;
            }
        }
        now.Rotate(-rotation);
        return isIn;
    }

    /// <summary>
    /// 判断下一步位移后, 所有的方格是否在有效网格中
    /// </summary>
    /// <param name="group"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    static bool IsEffectiveGridAfterMove(Transform group, Vector3 offset)
    {
        bool isEffective = true;
        List<string> pos = new List<string>();
        //先储存当前所以方格的位置, 这些位置在下一移动后都作为有效位置看待
        foreach (Transform child in group)
        {
            pos.Add(string.Format("({0}, {1})", (int)child.position.x, (int)child.position.y));
        }

        foreach (Transform child in group)    
        {
            Vector3 nextPos = child.position + offset;
            if (nextPos.y > height)
                continue;
            int x = (int)nextPos.x;
            int y = (int)nextPos.y;
            //在下一步中, 排除当前位置的数据后, 网格的相应位置为空
            if (grid[x, y] == null || pos.Contains(string.Format("({0}, {1})", x, y)))
            {
                continue;
            }
            else
            {
                isEffective = false;
                break;
            }
        } 
        return isEffective;
    }

    /// <summary>
    /// 判断下一步旋转后, 所有的方格是否在有效网格中
    /// </summary>
    /// <param name="group"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    static bool IsEffectiveGridAfterRotate(Transform group, Vector3 rotation)
    {
        bool isEffective = true;
        List<string> pos = new List<string>();
        //先储存当前所以方格的位置, 这些位置在下一移动后都作为有效位置看待
        foreach (Transform child in group)
        {
            pos.Add(string.Format("({0}, {1})", (int)child.position.x, (int)child.position.y));
        }
        group.Rotate(rotation);
        foreach (Transform child in group)
        {
            if (child.position.y > height)
                continue;
            int x = (int)child.position.x;
            int y = (int)child.position.y;
            //在下一步中, 排除当前位置的数据后, 网格的相应位置为空
            if (grid[x, y] == null || pos.Contains(string.Format("({0}, {1})", x, y)))
            {
                continue;
            }
            else
            {
                isEffective = false;
                break;
            }
        }
        group.Rotate(-rotation);
        return isEffective;
    }
}
