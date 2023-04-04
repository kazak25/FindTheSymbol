using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
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
        {
            _currentState?.Exit();
            var type = typeof(Tstate);
            var state = _states[type];
            ((IStateWithoutContext)state).Enter();
            _currentState = state;
        }

        public void Enter<Tstate, TContext>(TContext context)
            where Tstate : IStateWithContext<TContext>
    
        {
            _currentState?.Exit();
            var type = typeof(Tstate);
            var state = _states[type];
            ((IStateWithContext<TContext>)state).Enter(context);
            _currentState = state;
        }
    
    }
}

// для того , чтобы передавать только наследников класса (избегаем , чтобы не нпередали пустой класс)