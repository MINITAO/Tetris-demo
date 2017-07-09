using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandalonController : InputController
{
    public override bool FastMoveDown()
    {
        return Input.GetKeyDown(KeyCode.DownArrow) || 
               Input.GetKeyDown(KeyCode.S) ||
              (Input.GetAxis("Vertical") == -1);
    }

    public override bool MakeChange()
    {
        return Input.GetKeyDown(KeyCode.UpArrow) ||
               Input.GetKeyDown(KeyCode.W) ||
              (Input.GetAxis("Vertical") == 1);
    }

    public override bool MoveLeft()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow) ||
               Input.GetKeyDown(KeyCode.A) ||
              (Input.GetAxis("Horizontal") == -1);
    }

    public override bool MoveRight()
    {
        return Input.GetKeyDown(KeyCode.RightArrow) ||
               Input.GetKeyDown(KeyCode.D) ||
              (Input.GetAxis("Horizontal") == 1);
    }
}
