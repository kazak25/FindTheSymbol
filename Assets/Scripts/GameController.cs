using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using OpenAI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public UnityEvent PlayMode;

  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  
  [SerializeField] private GameObject _setSelectionObject;
  [SerializeField] private GameObject _cell;
  
  [SerializeField] private ScriptableObject _scriptableObject;
  [SerializeField] private StateMachine _stateMachine;
  [SerializeField] private SetSelctionState _setSelctionState;
  [SerializeField] private GameState _gameState;
  [SerializeField] private SymbolsSetView _symbolsSetView;
  [SerializeField] private Canvas _setSelection;
  [SerializeField] private DallE _dalleSprites;
  [SerializeField] private Canvas _dalleScreen;
  [SerializeField] private Canvas _startScreen;
  [SerializeField] private Canvas _standartScreen;
  [SerializeField] private BoxCollider _currentLevelCollider;
  [SerializeField] private GameObject _currentLevel;
  public IReadOnlyList<Sprite> Icons => _icons;
  public bool isGameActive = false;
 
  
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
        StartGame(_scriptableObject.Mystery);
        break;
      }
      case "Animals":
      {
        StartGame(_scriptableObject.Animals);
        break;
      }
      case "Food":
      {
        StartGame(_scriptableObject.Food);
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
    PlayMode.Invoke();
    isGameActive = true;

  }

  [UsedImplicitly]
  public void StandartSprites()
  {
    _startScreen.enabled = false;
    _standartScreen.enabled = true;
  }

  public void DalleStartGame()
  {
    StartGame(_dalleSprites.DalleImage);
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
    _currentLevel.transform.localScale = new Vector3(35f, 35f, 0);
    _currentLevelCollider.size = new Vector3(5, 5, 0);
  }
}
  
