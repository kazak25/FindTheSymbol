using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, IStateWithoutContext
{
    [SerializeField] private CellsSpawner _levelDifficult;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private GameController _gameController;
    [SerializeField] private LevelSettings _levelSettings;
    
    public int _levelNumber;
    public bool isWinCondition = false;
    public bool isLastLevel = false;
   
   // private GameController _gameController;

  
    private IReadOnlyList<Sprite>  _sprites = new List<Sprite>();
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
       _levelDifficult.Easylevel(_sprites);
    }

    public void Exit()
    {
        _gameController.ChildrenDelete(_currentLevel);
    }

    public void ChangeLevel()
    {
        switch (_levelNumber)
        {
            case 1:
            {
                _gameController.ChildrenDelete(_currentLevel);
                _levelDifficult.MediumLevel(_sprites);    
                _levelSettings.NextLevelSetting();   // Как внутри этого метода вызывать нужный уровень по Дженерикам
                break;
            }
            case 2:
            {
                isLastLevel = true;
                _gameController.ChildrenDelete(_currentLevel);
               _levelDifficult.HardLevel(_sprites);
               _levelSettings.NextLevelSetting();
                break;
            }
            default: return;
        }
    }
    
    
    
}
