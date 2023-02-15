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
    
    private float _x = -5;
    private float _y = 3;
    private void Start()
    {
        Easylevel(_scriptableObject._cars);
    }

    public void Easylevel(List<Sprite> _sprites)
    {
       var tempSprite= _gameController.SpritesRandom(_sprites, 3);
        for (int i = 0; i < 3; i++)
        {
            var cell = Instantiate(_cell,transform);
            cell.transform.position = new Vector3(_x, 0, 0);
            var gameObject = Instantiate(_gameObject,cell.transform);
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = tempSprite[i];
           
            gameObject.transform.position = new Vector3(_x, 0, 0);
            _x += 5;
        }
    }
    
    private void MediumLevel()
    {
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                var cell = Instantiate(_cell,transform);
                _cell.transform.position = new Vector3(_x, _y, 0);
                _x += 3;
            }
            _x = -3;
            _y -= 3;
        }
       
    }
    private void HardLevel()
    {
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                var cell = Instantiate(_cell,transform);
                _cell.transform.position = new Vector3(_x, _y, 0);
                _x += 3;
            }
            _x = -3;
            _y -= 3;
        }
    }
}
