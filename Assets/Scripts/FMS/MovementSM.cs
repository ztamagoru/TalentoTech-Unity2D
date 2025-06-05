using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walking walkingState;
    [HideInInspector]
    public State runningState;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float speed;
    public int sprintMultiplier;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
        runningState = new Running(this);
    }

    protected override State GetInitialState()
    {
        return idleState;
    }
}
