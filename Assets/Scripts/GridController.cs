using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    public static int leftBorder = 0;
    public static int rightBorder = 9;

    /// <summary>
    /// 对传入的Vector2四舍五入int的坐标值
    /// </summary>
    /// <param name="v"></param>
    /// <returns>对x,y四舍五入后的新Vector2</returns>
    public static Vector2 Vector2Round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    /// <summary>
    /// 清除未移动前的数据
    /// </summary>
    /// <param name="group"></param>
    static void ClearOldDate(Transform group)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y] && grid[x, y].parent == group)
                {
                    grid[x, y] = null;
                }
            }
        }
    }

    /// <summary>
    /// 更新网格数据
    /// </summary>
    /// <param name="group"></param>
    public static void UpdateGrid(Transform group)
    {
        ClearOldDate(group);
        foreach(Transform child in group)
        {
            grid[(int)child.position.x, (int)child.position.y] = child;
        }
    }

    /// <summary>
    /// 判断是否是有效位置
    /// </summary>
    /// <param name="group"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static bool IsValid(Transform group)
    {
        return IsInBorder(group) && IsEffectiveGrid(group);
    }

    /// <summary>
    /// 判断所有的方格是否在边界中
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    static bool IsInBorder(Transform group)
    {
        foreach(Transform child in group)
        {
            if (!((int)child.position.x >= leftBorder && 
                  (int)child.position.x <= rightBorder && 
                  (int)child.position.y >= 0))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 判断所有的方格是否在有效网格中
    /// </summary>
    /// <param name="group"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    static bool IsEffectiveGrid(Transform group)
    {
        foreach(Transform child in group)
        {
            int x = (int)child.position.x;
            int y = (int)child.position.y;
            if (!(grid[x, y] == null || grid[x, y].parent == group))
            {
                return false;
            }
        }
        return true;
    }

 
}
