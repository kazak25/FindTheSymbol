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
  [SerializeField] private GameObject _icon;
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
      setView.Initialize(_scriptableObject._allObjects[i].First(),_scriptableObject._allObjectsNames[i]);
      setView.name = _scriptableObject._allObjectsNames[i];
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

  public List<Sprite> GetRandomObject(List<Sprite> _sprites, int cellCount)
  {
    List<Sprite> _tempSprites = new List<Sprite>();
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
        StartGame(_scriptableObject._cars);
        break;
      }
      case "Letters": 
      {
        StartGame(_scriptableObject._letters);
        break;
      }
      case "Numbers":
      {
        StartGame(_scriptableObject._numbers);
        break;
      }
      default: return;
    }
  }
  private void StartGame(List<Sprite> _sprites)
  {
    _setSelectionObject.SetActive(false);
    _gameState.Array(_sprites);
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
    for (int i = 0; i < _scriptableObject._allObjects.Count; i++)
    {
      _icons.Add(_scriptableObject._allObjects[i].First());
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
