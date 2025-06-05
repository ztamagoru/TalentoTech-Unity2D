using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool timerOn = false;
    private float timeLeft = 0;

    void Update()
    {
        if (timerOn)
            TimerUpdate();
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
