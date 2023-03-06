public interface IStateWithContext<TContext> : Istate
   
{ 
    void Enter(TContext modeSelection);
}

