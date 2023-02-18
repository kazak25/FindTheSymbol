using System.Collections.Generic;
using UnityEngine;

public class Hard : MonoBehaviour,StateMachine.Istate
{
    [SerializeField] private CellsSpawner _hardLevel;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private GameController _gameController;
    
    private StateMachine _stateMachine;
    private List<Sprite> _sprites = new List<Sprite>();

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Array(List<Sprite> sprites)
    {
        _sprites = sprites;
    }
    
    public void Enter()
    {
        _hardLevel.HardLevel(_sprites);
    }

    public void Exit()
    {
        _gameController.ChildrenDelete(_currentLevel);
    }
}