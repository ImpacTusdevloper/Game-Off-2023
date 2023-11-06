using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    public Run(Player _player, StateMachine _machine) : base(_player, _machine)
    {

    }

    public override void FixedFrameUpdate()
    {
        TransitionCheck();
        player.Move(player.rSpeed);
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
        else if(!player.IsShiftHold())
        {
            if(player.IsMoving())
                machine.ChangeState(player.walk);
            else
                machine.ChangeState(player.idle);
        }
    }
}
