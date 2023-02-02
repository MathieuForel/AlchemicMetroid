using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName ="InputController/PlayerController")]
public class PlayerController : InputController
{
    public override bool RetreiveJumpInput()
    {
        return Input.GetKeyDown("z");
    }

    public override float RetreiveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetreiveVerticalInput()
    {
        return Input.GetKeyDown("s");
    }

    public override bool RetreiveAttackInput()
    {
        return Input.GetKeyDown("space");
    }
}

