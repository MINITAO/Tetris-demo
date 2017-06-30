using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController {

    public abstract bool MoveLeft();
    public abstract bool MoveRight();
    public abstract bool FastMoveDown();
    public abstract bool MakeChange();

}
