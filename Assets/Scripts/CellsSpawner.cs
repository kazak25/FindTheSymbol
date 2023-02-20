using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellsSpawner : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private TaskSelection _playMode;
    
    [SerializeField] private GameObject _cell;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _currentLevel;
    
    public void Easylevel(List<Sprite> _sprites)
    {
        CreateLevel(_sprites, 1, 3, -5, 0, 5, 0);
    }
    public void MediumLevel(List<Sprite> _sprites)
    {
        CreateLevel(_sprites, 2, 3, -5, 2, 5,3 );
    }
    public void HardLevel(List<Sprite> _sprites)
    {
        CreateLevel(_sprites, 3, 3, -4, 3, 4, 3);
    }

    private void CreateLevel(List<Sprite> _sprites, int columnsCount, int elementsСountPerLine, int startPositionX, 
        int startPositionY,int distanceBetweenElements,int lineSpacing)
    {
        int x = startPositionX;
        int y = startPositionY;
        var tempSprite= _gameController.SpritesRandom(_sprites, columnsCount*elementsСountPerLine);
        _playMode.Initialize(tempSprite);
        int spriteNumber = 0;
        for (int k = 0; k < columnsCount; k++)
        {
            for (int i = 0; i < elementsСountPerLine; i++)
            {
                var cell = Instantiate(_cell,_currentLevel.transform);
                cell.transform.position = new Vector3(x, y, 0);
                var gameObject = Instantiate(_gameObject,cell.transform);
                Sprite sprite = gameObject.GetComponent<Sprite>();
                sprite = tempSprite[spriteNumber];
                gameObject.transform.position = new Vector3(x, y, 0);
                gameObject.name = sprite.name;
                x += distanceBetweenElements;
                spriteNumber++;
            }
            x = startPositionX;
            y -= lineSpacing;
        }
    }
}
