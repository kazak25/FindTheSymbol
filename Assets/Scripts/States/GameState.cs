using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class GameState : MonoBehaviour, IStateWithoutContext
{
    [SerializeField] private LevelDifficulty _levelDifficulty;
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private GameController _gameController;
    [SerializeField] private LevelSettings _levelSettings;

    [SerializeField] private GameObject _currentLevel;
    
   
    public bool isWinCondition { get; private set; }
    public bool isLastLevel = false;
    
    private int _levelNumber;
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
       _levelDifficulty.Easylevel(_sprites);
       StartCoroutine(CountDown());
    }
    [UsedImplicitly]
    public void ChangeLevelNumber()
    {
        _levelNumber++;
    }
    public void Exit()
    {
        _gameController.ChildrenDelete(_currentLevel);
    }
    
    [UsedImplicitly] 
    public void WinConditionOff()
    {
        isWinCondition = false;
    }
    
    public void WinConditionOn()
    {
        isWinCondition = true;
    }
    public void ChangeLevel()
    {
        _levelSettings.NextLevelSettings(_levelDifficulty, _levelNumber, _sprites, CountDown());
    }
    
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5);
        foreach (var cel in _scriptableObject.Cells)
        {
           
            var sprite = cel.GetComponentInChildren<SpriteRenderer>();   // как сделать по - другому ?
            cel.transform.DORotate(new Vector3(0, 180, 0), 3);
            var icon = cel.GetComponentInChildren<SpriteRenderer>(); // как сделать по - другому ?
            icon.flipX = true;
            yield return null;
            sprite.DOColor(Color.clear, 2);
        }
    }
    
    
    
}
