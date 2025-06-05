using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int horizontalMovement = 0;
    public int verticalMovement = 0;

    private Vector2 mov = new Vector2(0, 0);

    public float speed;
    public float speedMultiplier = 2.5f;

    public Rigidbody2D rb;
    private Collider2D playerCollider;

    private bool timerOn = false;
    private float timeLeft = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
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
    }

    [SerializeField] private LayerMask groundLayer;

    public bool IsOnGround()
    {
        return playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    #region timer

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
    #endregion
}
