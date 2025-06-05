using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Running : State
{
    private MovementSM _sm;
    private float _horizontalInput;

    public Running(MovementSM stateMachine) : base("Running", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.animator.SetFloat("moving", 1f);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            stateMachine.ChangeState(_sm.walkingState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rb.velocity;
        
        vel.x = Input.GetAxis("Horizontal") == 0f ? 0f : _horizontalInput * _sm.speed * _sm.sprintMultiplier;

        _sm.rb.velocity = vel;
        _sm.spriteRenderer.flipX = vel.x < 0f;
    }
}