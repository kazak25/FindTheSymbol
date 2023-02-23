using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, IStateWithoutContext
{
    // Start is called before the first frame update
    [SerializeField] private CellsSpawner _levelDifficult;
    [SerializeField] private GameObject _currentLevel;
    
   // private GameController _gameController;
    private IReadOnlyList<Sprite> _sprites = new List<Sprite>();
    private StateMachine _stateMachine;
   
    
    public void Array(IReadOnlyList<Sprite> sprites)
    {
        _sprites = sprites;
    }

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
       
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
