using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State curState {get; set;}
    public void SetState(State _state)
    {
        curState = _state;
        curState.EnterState();
    }

    public void ChangeState(State _state)
    {
        curState.ExitState();
        SetState(_state);
    }
}
