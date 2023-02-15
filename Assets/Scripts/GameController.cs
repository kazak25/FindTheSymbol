using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private ScriptableObject _scriptable;
  [SerializeField] private GameObject _gameObject;
  [SerializeField] private GameObject _iconName;
  private List<string> _names = new List<string>();
  private List<Sprite> _icons = new List<Sprite>();
  private List<GameObject> _gameObjects = new List<GameObject>();
  private float _x = -5;
  
  private void Awake()
  {
    _icons.Add(_scriptable._cars.First());
    _icons.Add(_scriptable._letters.First());
    _icons.Add(_scriptable._numbers.First());
    _names.Add("Cars");
    _names.Add("Letters");
    _names.Add("Numbers");
    Debug.Log("КУКУ");
  }

  private void Start()
  {
      SetSelection();
  }

  private void SetSelection()
  {
    for (var i = 0; i < _icons.Count; i++)
    {
      var gameObject = Instantiate(_gameObject,transform);
      var iconName = Instantiate(_iconName,transform);
      iconName.transform.parent = gameObject.transform;
      var sprite = gameObject.GetComponent<SpriteRenderer>();
      sprite.sprite = _icons[i];
      gameObject.transform.position = new Vector3(_x, 0f, 0f);
      _gameObjects.Add(gameObject);
      var textUI = iconName.GetComponent<TextMeshProUGUI>();
      textUI.text = _names[i];
      _x += 5;
    }
  }
}
