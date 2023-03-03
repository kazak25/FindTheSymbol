using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameState : MonoBehaviour, IStateWithoutContext
{
    [SerializeField] private CellsSpawner _cellsCurrentLevel;
    
    [SerializeField] private GameObject _currentLevel;
    
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private LevelSettings _levelSettings;
    
    [SerializeField] private float _waitingTime;
    
    public int _levelNumber;
    public bool isWinCondition = false;
    public bool isLastLevel = false;

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
       _cellsCurrentLevel.Easylevel(_sprites);
       StartCoroutine(CountDown());
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
                _cellsCurrentLevel.MediumLevel(_sprites);
                _levelSettings.NextLevelSetting();   // Как внутри этого метода вызывать нужный уровень по Дженерикам
                StartCoroutine(CountDown());
                break;
            }
            case 2:
            {
                isLastLevel = true;
                _gameController.ChildrenDelete(_currentLevel);
                _cellsCurrentLevel.HardLevel(_sprites);
                _levelSettings.NextLevelSetting();
                StartCoroutine(CountDown());
                break;
            }
            default: return;
        }
    }
    
    IEnumerator CountDown()
    {
    
        // while (count > 0) { 
        //
        //     textmeshprougui.text = count.ToString(); 
        //
        //     yield return new WaitForSeconds(1f); 
        //
        //     count--; 
        // }
    
        // textmeshprougui.text = "GO!";
        // DOTween.To(()=> image.transform.rotation, 
        
        //     x=> image.transform.rotation = x, 
        //     new Vector3(0f, 180f, 0f), 1f);
        // yield return new WaitForSeconds(1f); 
        yield return new WaitForSeconds(5);
        foreach (var cel in _cellsCurrentLevel.Cels)
        {
            Debug.Log(cel.name);
            var sprite = cel.GetComponentInChildren<SpriteRenderer>();   // как сделать по - другому ?
            cel.transform.DORotate(new Vector3(0, 180, 0), 3);
            yield return null;
            sprite.DOColor(Color.clear, 2);
        }
        
    }
    
    
    
}
