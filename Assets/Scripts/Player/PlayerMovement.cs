using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Falling
    }

    private PlayerState currentState = PlayerState.Idle;

    private int horizontalMovement = 0;
    private int verticalMovement = 0;

    private Vector2 mov = new Vector2(0, 0);

    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier = 2.5f;

    private Rigidbody2D rb;

    private bool timerOn = false;
    private float timeLeft = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timerOn)
        {
            TimerUpdate();
        }

        MovementInput();      
    }

    private void FixedUpdate()
    {
        mov = new Vector2(horizontalMovement, verticalMovement);

        mov = mov.normalized;

        rb.AddForce(mov * speed * Time.fixedDeltaTime);
    }

    private void MovementInput()
    {
        horizontalMovement = 
            Input.GetKey(KeyCode.A) ? -1 : 
            Input.GetKey(KeyCode.D) ? 1 : 0;

        verticalMovement = 
            Input.GetKey(KeyCode.W) ? 1 : 
            rb.velocity.y <= -0.1f ? -1 : 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= speedMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= speedMultiplier;
        }

        PlayerState previousState = currentState;

        currentState = verticalMovement > 0 ? PlayerState.Jumping :
            verticalMovement < 0 ? PlayerState.Falling :
            horizontalMovement != 0 ? (Input.GetKey(KeyCode.LeftShift) ? PlayerState.Running : PlayerState.Walking) :
            PlayerState.Idle;

        if (currentState != previousState)
        {
            Debug.Log($"{currentState}");
        }
    }

    private void StartTimer(float duration)
    {
        timeLeft = duration;
        timerOn = true;
    }

    private void TimerUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timerOn = false;
            timeLeft = 0;

            Debug.Log("Timer ended");
        }
    }
}
