using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, Istate> _states;
    private Istate _currentState;

    public StateMachine(params Istate[] states)
    {
        _states = new Dictionary<Type, Istate>();
        foreach (var state in states)
        {
            state.Initialize(this);
            var type = state.GetType();
            _states[type] = state;
        }
    }

    public void Enter<Tstate>()
        where Tstate : Istate
    {
        _currentState?.Exit();
        var type = typeof(Tstate);
        var state = _states[type];
        state.Enter();
        _currentState = state;
    }
    
    public interface Istate
    {
        void Initialize(StateMachine stateMachine);
        void Enter();
        void Exit();
    }

}