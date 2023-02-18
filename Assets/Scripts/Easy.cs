using System;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour,StateMachine.Istate
{
    [SerializeField] private CellsSpawner _easyLevel;
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
        _easyLevel.Easylevel(_sprites);
    }

    public void Exit()
    {
       _gameController.ChildrenDelete(_currentLevel);

    }
}