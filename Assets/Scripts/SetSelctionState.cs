using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelctionState : MonoBehaviour, StateMachine.Istate
{
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
