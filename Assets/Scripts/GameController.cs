using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public UnityEvent _PlayMode;
  
  [SerializeField] private ScriptableObject _scriptableObject;
  
  [SerializeField] private StateMachine _stateMachine;
   
  [SerializeField] private SetSelctionState _setSelctionState;
  [SerializeField] private GameState _gameState;
 // [SerializeField] private Hard _hardLevelState;

  [SerializeField] private SymbolsSetView _symbolsSetView;
  [SerializeField] private Canvas _setSelection;
  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  [SerializeField] private GameObject _setSelectionObject;
  
  [SerializeField] private CanvasGroup _canvasGroup;

  public IReadOnlyList<Sprite> Icons => _icons;

  public bool _isGameActive = false; 
  public bool isLastLevel = false;
  public bool _isWinCondition = false;
  public List<Sprite> _icons = new List<Sprite>();
  
  private List<GameObject> _gameObjects = new List<GameObject>();
  public int _levelNumber;

  private void Start()
  {
    _stateMachine = new StateMachine(_setSelctionState, _gameState);
   // BlackOut(); для теста в машине пока что будем запускать
   // AddStartIcons()
   //SetSelection();
   _stateMachine.Enter<SetSelctionState,GameController>(this);
   
  }

  
  public void SetSelection()
  {
    for (var i = 0; i < _icons.Count; i++)
    {
      var setView = Instantiate(_symbolsSetView, _setSelection.transform);
      setView.Initialize(_scriptableObject.AllObjects[i].First(),_scriptableObject.AllObjectsNames[i]);
      setView.name = _scriptableObject.AllObjectsNames[i];
    }
  }
  
  [UsedImplicitly]
  // public void ChangeLevel()
  // {
  //   switch (_levelNumber)
  //   {
  //     case 1:
  //     {
  //      // _stateMachine.Enter<Medium>();
  //       _nextLevelbutton.SetActive(false);
  //       _PlayMode.Invoke();
  //       break;
  //     }
  //     case 2:
  //     {
  //       isLastLevel = true;
  //       //_stateMachine.Enter<Hard>();
  //       _nextLevelbutton.SetActive(false);
  //       _PlayMode.Invoke();
  //       break;
  //     }
  //     default: return;
  //   }
  // }
 
  private void StartCreateLevel<T>(StateMachine _stateMachine)
  {
    _stateMachine.Enter<T>();
    _nextLevelbutton.SetActive(false);
    _PlayMode.Invoke();
  }
 public List<T> GetRandomObjects<T>(List<T> _sprites, int cellCount)
  {
    List<T> _tempSprites = new List<T>();
    for (int i = 0; i < cellCount; i++)
    {
      while (true)
      {
        var tempIndex = Random.Range(0, _sprites.Count);
        var randomSprite = _sprites[tempIndex];
        if (!_tempSprites.Contains(randomSprite))
        {
          _tempSprites.Add(randomSprite);
          break;
        }
      }
    }
    return _tempSprites;
  }

  public void ObjectsSelection(string name)
  {
    switch (name)
    {
      case "Cars": 
      {
        StartGame(_scriptableObject.Cars);
        break;
      }
      case "Letters": 
      {
        StartGame(_scriptableObject.Letters);
        break;
      }
      case "Numbers":
      {
        StartGame(_scriptableObject.Numbers);
        break;
      }
      default: return;
    }
  }
  private void StartGame(IReadOnlyList<Sprite> sprites)
  {
    _setSelectionObject.SetActive(false);
    _gameState.Array(sprites);
    _stateMachine.Enter<GameState>();
    _PlayMode.Invoke();
    _isGameActive = true;
   
  }

  [UsedImplicitly]
  public void ChildrenDelete(GameObject gameObject)
  {
    var temp = gameObject.transform;

    foreach (Transform child in temp) 
    {
      Destroy(child.gameObject); 
    }
  }

  public void AddStartIcons()
  {
    for (int i = 0; i < _scriptableObject.AllObjects.Count; i++)
    {
      _icons.Add(_scriptableObject.AllObjects[i].First());
    }
    
  }
  
  [UsedImplicitly]
  public void RestartScene()
  {
    SceneManager.LoadSceneAsync(GlobalConstants.SceneGame);
  }
  // public void BlackOut()
  // {
  //   _canvasGroup.DOFade(1, 3f);
  // }
  //
}
