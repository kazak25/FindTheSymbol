namespace StateMachine
{
    public interface Istate
    {
        void Initialize(StateMachine stateMachine);
        void Exit();
    }
}

