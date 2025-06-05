using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Idle : State
{
    private MovementSM _sm;
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        _horizontalInput = Input.GetAxis("Horizontal");
        
        if(Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.walkingState);
    }
}
