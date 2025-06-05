using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : State
{
    private MovementSM _sm;
    private float _horizontalInput;

    public Walking(MovementSM stateMachine) : base("Walking", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        //_sm.animation
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = ((MovementSM) stateMachine).rigidbody.velocity;
        vel.x = _horizontalInput * _sm.speed;
        _sm.rigidbody.velocity = vel;
    }
}
