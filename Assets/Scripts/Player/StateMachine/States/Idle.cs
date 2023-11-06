using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(Player _player, StateMachine _machine) : base(_player, _machine)
    {
        
    }
    
    public override void FrameUpdate() => TransitionCheck();

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
        else if(player.IsMoving())
        {
            if(player.IsShiftHold())
                machine.ChangeState(player.run);
            else
                machine.ChangeState(player.walk);
        }
    }
}
