using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public static int width;
    public static int height;

    [HideInInspector]
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
    /// 传入的Vector2的坐标值是否为合法的
    /// </summary>
    /// <param name="v"></param>
    /// <returns>bool</returns>
    public static bool IsVailid(Transform Group)
    {
        return IsInBorder(Group) && IsEffectiveGrid(Group);
    }

    public static bool IsVailid(Vector3 v)
    {
        return IsInBorder(v);
    }

    /// <summary>
    /// Group的所有小方格是否都在边界内
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    static bool IsInBorder(Transform Group)
    {
        foreach (Transform child in Group)
        {
            if (!IsInBorder(child.position))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Vector2的坐标是否在边界内
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    static bool IsInBorder(Vector2 v)
    {
        Vector2 pos = Vector2Round(v);
        if (pos.x >= borderLeft.position.x &&
            pos.x <= borderRight.position.x &&
            pos.y >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool IsEffectiveGrid(Transform Group)
    {
        return true;
    }
}
