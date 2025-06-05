using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour
{
    State currentState;

    void Start()
    {
        currentState = GetInitialState();
        if(currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    protected virtual State GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "No State";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
