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
   
  [SerializeField] private Easy _easyLevelState;
  [SerializeField] private Medium _mediumLevelState;
  [SerializeField] private Hard _hardLevelState;
  
  [SerializeField] private GameObject _icon;
  [SerializeField] private Canvas _setSelection;
  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  [SerializeField] private GameObject _setSelectionObject;
  
  [SerializeField] private CanvasGroup _canvasGroup;
  
  
  public bool _isGameActive = false; 
  public bool isLastLevel = false;
  public bool _isWinCondition = false;
  private List<Sprite> _icons = new List<Sprite>();
  private List<GameObject> _gameObjects = new List<GameObject>();
  public int _levelNumber;

  private void Start()
  {
    _stateMachine = new StateMachine(_easyLevelState, _mediumLevelState, _hardLevelState);
    BlackOut();
    AddStartIcons();
    SetSelection();
  }
  [UsedImplicitly]
  private void SetSelection()
  {
    for (var i = 0; i < _icons.Count; i++)
    {
      var icon = Instantiate(_icon,_setSelection.transform);
      var sprite = icon.GetComponent<SpriteRenderer>();
      sprite.sprite = _icons[i];
      var textUI = icon.GetComponentInChildren<TextMeshProUGUI>();
      textUI.text = _scriptableObject._allObjectsNames[i];
      icon.name = _scriptableObject._allObjectsNames[i];
    }
  }
  [UsedImplicitly]
  public void ChangeLevel()
  {
    switch (_levelNumber)
    {
      case 1:
      {
        _stateMachine.Enter<Medium>();
        _nextLevelbutton.SetActive(false);
        _PlayMode.Invoke();
        break;
      }
      case 2:
      {
        isLastLevel = true;
        _stateMachine.Enter<Hard>();
        _nextLevelbutton.SetActive(false);
        _PlayMode.Invoke();
        break;
      }
      default: return;
    }
  }
  public void ObjectsSelection(string objectName)
  {
    switch (objectName)
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
  private void StartGame(List<Sprite> sprites)
  {
    _setSelectionObject.SetActive(false);
    _easyLevelState.Array(sprites);
    _mediumLevelState.Array(sprites);
    _hardLevelState.Array(sprites);
    _stateMachine.Enter<Easy>();
    _PlayMode.Invoke();
    _isGameActive = true;
   
  }

  [UsedImplicitly]
  public void ChildrenDelete(GameObject parent)
  {
    var currentParent = parent.transform;

    foreach (Transform child in currentParent) 
    {
      Destroy(child.gameObject); 
    }
  }

  private void AddStartIcons()
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
  public void BlackOut()
  {
    _canvasGroup.DOFade(1, 3f);
  }

 public List<T> GetRandomObject<T>(List<T> objects, int count)
  {
    List<T> _tempSprites = new List<T>();
    for (int i = 0; i < count; i++)
    {
      while (true)
      {
        var tempIndex = Random.Range(0, objects.Count);
        var randomSprite = objects[tempIndex];
        if (!_tempSprites.Contains(randomSprite))
        {
          _tempSprites.Add(randomSprite);
          break;
        }
      }
    }
    return _tempSprites;
  }
}
