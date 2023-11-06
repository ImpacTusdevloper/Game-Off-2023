using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : State
{
    Rigidbody rb;
    public InAir(Player _player, StateMachine _machine) : base(_player, _machine)
    {
        rb = player.GetComponent<Rigidbody>();
    }
    public override void EnterState()
    {
        rb.drag = 0f;
    }
    public override void FixedFrameUpdate()
    {
        TransitionCheck();
        player.Move(player.aSpeed);
    }

    public override void TransitionCheck()
    {
        if(player.IsShiftClicked())
        {
            machine.ChangeState(player.dash);
        }
        else if(player.IsSpacePressed() && machine.curState != player.jump)
        {
            machine.ChangeState(player.jump);
        }
        else if(player.OnGround())
        {
            rb.drag = player.rbDrag;
            machine.ChangeState(player.idle);
        }
    }
}
