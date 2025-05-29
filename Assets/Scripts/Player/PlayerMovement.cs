using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int horizontalMovement = 0;
    private int verticalMovement = 0;

    private Vector2 mov = new Vector2(0, 0);

    [SerializeField] private float speed;

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
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = 1;
        }
        else
        {
            horizontalMovement = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalMovement = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            verticalMovement = -1;
        }
        else
        {
            verticalMovement = 0;
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
