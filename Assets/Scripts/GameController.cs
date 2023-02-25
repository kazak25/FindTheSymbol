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

  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  
  [SerializeField] private ScriptableObject _scriptableObject;
  [SerializeField] private StateMachine _stateMachine;
  [SerializeField] private SetSelctionState _setSelctionState;
  [SerializeField] private GameState _gameState;
  [SerializeField] private SymbolsSetView _symbolsSetView;
  [SerializeField] private Canvas _setSelection;
  [SerializeField] private GameObject _setSelectionObject;
  [SerializeField] private GameObject _cell;
  public IReadOnlyList<Sprite> Icons => _icons;
  public bool _isGameActive = false;
 
  
  private List<Sprite> _icons = new List<Sprite>();
  private List<Sprite> _gameObjects = new List<Sprite>();

  private void Start()
  {
    _stateMachine = new StateMachine(_setSelctionState, _gameState);
    _stateMachine.Enter<SetSelctionState, GameController>(this);
  }

  public void SetSelection()
  {
    for (var i = 0; i < _icons.Count; i++)
    {
      var cell = Instantiate(_cell, _setSelection.transform);
      var setView = Instantiate(_symbolsSetView, cell.transform);
      setView.Initialize(_scriptableObject.AllObjects[i].First(), _scriptableObject.AllObjectsNames[i]);
      setView.name = _scriptableObject.AllObjectsNames[i];
    }
  }
  
 
  

  public void ObjectsSelection(string name)
  {
    switch (name)
    {
      case "Mystery":
      {
        StartGame(_scriptableObject.Cars);
        break;
      }
      case "Animals":
      {
        StartGame(_scriptableObject.Letters);
        break;
      }
      case "Food":
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
}
  
