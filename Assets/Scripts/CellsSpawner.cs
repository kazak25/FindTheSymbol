using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellsSpawner : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private TaskSelection _playMode;
    [SerializeField] private LevelSettings _levelSettings;
    
    [SerializeField] private GameObject _cell;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Canvas _currentLevel;
    
    public void Easylevel(List<Sprite> _sprites)
    {
        _levelSettings.EasyLevelSettings();
        CreateLevel(_sprites);
    }
    public void MediumLevel(List<Sprite> _sprites)
    {
        _levelSettings.MediumLevelSettings();
        CreateLevel(_sprites);
    }
    public void HardLevel(List<Sprite> _sprites)
    {
        _levelSettings.HardLevelSettings();
        CreateLevel(_sprites);
    }

    private void CreateLevel(List<Sprite> _sprites)
    {
        int x = _levelSettings.startPositionX;
        int y = _levelSettings.startPositionY;
        var cellCount = _levelSettings.columnsCount * _levelSettings.elementsСountPerLine;
        var tempSprite= _gameController.SpritesRandom(_sprites, cellCount);
        _playMode.Initialize(tempSprite);
        int spriteNumber = 0;
        for (int k = 0; k < _levelSettings.columnsCount; k++)
        {
            for (int i = 0; i < _levelSettings.elementsСountPerLine; i++)
            {
                var cell = Instantiate(_cell,_currentLevel.transform);
                cell.transform.position = new Vector3(x, y, 0);
                var icon = Instantiate(_gameObject,cell.transform);
                var sprite = icon.GetComponent<SpriteRenderer>();
                sprite.sprite = tempSprite[spriteNumber];
                icon.transform.position = new Vector3(x, y, 0);
                icon.name = sprite.sprite.name;
                x += _levelSettings.distanceBetweenElements;
                spriteNumber++;
            }
            x = _levelSettings.startPositionX;
            y -= _levelSettings.lineSpacing;
        }
    }
}
