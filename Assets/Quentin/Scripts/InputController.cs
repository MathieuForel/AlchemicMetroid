using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetreiveMoveInput();
    public abstract float RetreiveVerticalInput();
    public abstract bool RetreiveJumpInput();
}
