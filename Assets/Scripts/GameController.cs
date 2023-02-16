using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
  [SerializeField] private ScriptableObject _scriptable;
  [SerializeField] private GameObject _gameObject;
  [SerializeField] private GameObject _iconName;
  [SerializeField] private GameObject _setSelection;
  
  private CellsSpawner _cellsSpawner;
  private List<string> _names = new List<string>();
  private List<Sprite> _icons = new List<Sprite>();
  private List<GameObject> _gameObjects = new List<GameObject>();
  private float _x = -3;
  
  private void Awake()
  {
    _icons.Add(_scriptable._cars.First());
    _icons.Add(_scriptable._letters.First());
    _icons.Add(_scriptable._numbers.First());
    _names.Add("Cars");
    _names.Add("Letters");
    _names.Add("Numbers");
  }

  private void Start()
  {
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
      textUI.text = _names[i];
      textUI.fontSize = 2;
      gameObject.name = _names[i];
      _x += 3;
      
    }
  }

  private void StartGame(List<Sprite> _sprites)
  {
    _cellsSpawner.Easylevel(_sprites,3);
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
}
