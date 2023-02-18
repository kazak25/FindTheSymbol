using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public UnityEvent _PlayMode;
  
  [SerializeField] private ScriptableObject _scriptableObject;
  
  [SerializeField] private StateMachine _stateMachine;
   
  [SerializeField] private Easy _easyLevelState;
  [SerializeField] private Medium _mediumLevelState;
  [SerializeField] private Hard _hardLevelState;
  
  [SerializeField] private GameObject _gameObject;
  [SerializeField] private GameObject _iconName;
  [SerializeField] private GameObject _setSelection;
  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  
  [SerializeField] private CanvasGroup _canvasGroup;
  
  public bool _isGameActive = false; 
  public bool isLastLevel = false;
  public bool _isWinCondition = false;
  private List<Sprite> _icons = new List<Sprite>();
  private List<GameObject> _gameObjects = new List<GameObject>();
  public int _levelNumber;
  private float _x = -3;

  private void Start()
  {
    _stateMachine = new StateMachine(_easyLevelState, _mediumLevelState, _hardLevelState);
    BlackOut();
    AddStartIcons();
    SetSelection();
  }

  private void SetSelection()
  {
    for (var i = 0; i < _icons.Count; i++)
    {
      var gameObject = Instantiate(_gameObject,_setSelection.transform);
      var iconName = Instantiate(_iconName,_setSelection.transform);
      var sprite = gameObject.GetComponent<SpriteRenderer>();
      sprite.sprite = _icons[i];
      gameObject.transform.position = new Vector3(_x, 0f, 0f);
      iconName.transform.position = new Vector3(_x, -2f, 0f);
      var scale = gameObject.GetComponent<RectTransform>();
      scale.sizeDelta = new Vector2(5, 5);
      scale.localScale = new Vector3(3, 3, 0);
      var textScale = iconName.GetComponent<RectTransform>();
      textScale.sizeDelta = new Vector2(5, 5);
      textScale.localScale = new Vector3(2, 2,0);
      _gameObjects.Add(gameObject);
      var textUI = iconName.GetComponent<TextMeshProUGUI>();
      textUI.text = _scriptableObject._allObjectsNames[i];
      textUI.fontSize = 2;
      gameObject.name = _scriptableObject._allObjectsNames[i];
      _x += 3;
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
  public List<Sprite> SpritesRandom(List<Sprite> _sprites, int cellCount)
  {
    List<Sprite> _tempSprites = new List<Sprite>();
    for (int i = 0; i < cellCount; i++)
    {
      var count = 0;
      var index = Random.Range(0, _sprites.Count);
      var tempsprite = _sprites[index];
      if (_tempSprites.Count == 0)
      {
        _tempSprites.Add(tempsprite);
        continue;
      }
      for ( int k = 0; k < _tempSprites.Count; k++)
      {
        if (tempsprite == _tempSprites[k])
        {
          i--;
          count = 1;
        }
      }
      if (count == 0)
      {
        _tempSprites.Add(tempsprite); 
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
    _setSelection.SetActive(false);
    _easyLevelState.Array(_sprites);
    _mediumLevelState.Array(_sprites);
    _hardLevelState.Array(_sprites);
    _stateMachine.Enter<Easy>();
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
  
}
