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

    public Rigidbody2D rigidbody;
    public Animation animation;

    public float speed = 5f;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
    }

    protected override State GetInitialState()
    {
        return idleState;
    }
}
