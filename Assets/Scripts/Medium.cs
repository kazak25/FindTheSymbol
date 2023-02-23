using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medium : MonoBehaviour
{
    [SerializeField] private CellsSpawner _mediumLevel;
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
        _mediumLevel.MediumLevel(_sprites);
    }

    public void Exit()
    {
        _gameController.ChildrenDelete(_currentLevel);
    }
}