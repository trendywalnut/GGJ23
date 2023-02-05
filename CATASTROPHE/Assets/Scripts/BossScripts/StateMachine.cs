using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    private void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
            //Debug.Log(currentState.name + " Enter");
        }
    }

    public virtual void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
            //Debug.Log(currentState.name + " Update");
        }
    }

    private void LateUpdate()
    {
        if (currentState != null)
        { 
            currentState.UpdatePhysics();
            //Debug.Log(currentState.name + " LateUpdate");
        }
    }

    public void ChangeState(BaseState newState)
    {
        //Debug.Log("Changing State From: " + currentState.name + " To: " + newState.name);
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
