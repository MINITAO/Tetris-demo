using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : InputController
{
    public override bool FastMoveDown()
    {
        Vector3 distance = GetStartToEndDistace();
        if(distance.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool MakeChange()
    {
        Vector3 distance = GetStartToEndDistace();
        if (distance.y > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool MoveLeft()
    {
        Vector3 distance = GetStartToEndDistace();
        if (distance.x < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool MoveRight()
    {
        Vector3 distance = GetStartToEndDistace();
        if (distance.x > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Vector3 GetStartToEndDistace ()
    {
        Vector3 startPos = Vector3.zero;
        Vector3 endPos = Vector3.zero;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
            }
        }
        return startPos - endPos;
    }
}
