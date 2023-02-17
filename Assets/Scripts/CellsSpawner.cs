using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _cell;
    
    [SerializeField]
    private GameController _gameController;
    
    [SerializeField]
    private ScriptableObject _scriptableObject;

    [SerializeField]
    private GameObject _gameObject;

    [SerializeField] private GameMode _playMode;
    [SerializeField] private GameObject _currentLevel;
    
    private float _x = -5;
    private float _y = 0;
    private void Start()
    {
        // Easylevel(_scriptableObject._cars,3);
        // MediumLevel(_scriptableObject._cars);
        // HardLevel(_scriptableObject._cars);
    }

    public void Easylevel(List<Sprite> _sprites, int i1)
    {
       var tempSprite= _gameController.SpritesRandom(_sprites, 3);
       _playMode.Initialize(tempSprite);
       
        for (int i = 0; i < 3; i++)
        {
            var cell = Instantiate(_cell,_currentLevel.transform);
            cell.transform.position = new Vector3(_x, 0, 0);
            var gameObject = Instantiate(_gameObject,cell.transform);
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = tempSprite[i];
            gameObject.name = sprite.sprite.name;
           
            gameObject.transform.position = new Vector3(_x, 0, 0);
            _x += 5;
        }
    }
    
    public void MediumLevel(List<Sprite> _sprites,int i1)
    {
        _x = -5;
        _y = 1;
        var tempSprite= _gameController.SpritesRandom(_sprites, 6);
        _playMode.Initialize(tempSprite);
        int spriteNumber = 0;
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 3; i++)
            {
               
                var cell = Instantiate(_cell,_currentLevel.transform);
                cell.transform.position = new Vector3(_x, _y, 0);
                var gameObject = Instantiate(_gameObject,cell.transform);
                var sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.sprite = tempSprite[spriteNumber];
                gameObject.transform.position = new Vector3(_x, _y, 0);
                gameObject.name = sprite.sprite.name;
                _x += 5;
                spriteNumber++;
            }
            _x = -5;
            _y -= 2;
        }
       
    }
    public void HardLevel(List<Sprite> _sprites,int i1)
    {
        _x = -5;
        _y = 3;
        var tempSprite= _gameController.SpritesRandom(_sprites, 9);
        _playMode.Initialize(tempSprite);
        int spriteNumber = 0;
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                var cell = Instantiate(_cell,_currentLevel.transform);
                cell.transform.position = new Vector3(_x, _y, 0);
                var gameObject = Instantiate(_gameObject,cell.transform);
                var sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.sprite = tempSprite[spriteNumber];
                gameObject.transform.position = new Vector3(_x, _y, 0);
                gameObject.name = sprite.sprite.name;
                _x += 5;
                spriteNumber++;
            }
            _x = -5;
            _y -= 3;
        }
    }
}
