using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelSettings : MonoBehaviour
{
   [SerializeField] private GameController _gameController;
   [SerializeField] private GameState _gameState;
   [SerializeField] private BoxCollider _currentLevelCollider;
   
   [SerializeField] private GameObject _currentLevel;
   [SerializeField] private GameObject _spawner;
   [SerializeField] private GameObject _nextLevelbutton;
   
   public  int columnsCount;
   public  int elementsСountPerLine;
   public  int startPositionX;
   public  int startPositionY;
   public  int distanceBetweenElements;
   public  int lineSpacing;
   
   private void Start()
   {
      _currentLevel.transform.localScale = new Vector3(35f, 35f, 0);
      _currentLevelCollider.size = new Vector3(5, 5, 0);
   }
   public void NextLevelSettings(LevelDifficulty level, int levelNumber, IReadOnlyList<Sprite> sprites, 
      IEnumerator countDown)
   { 
      _gameController.ChildrenDelete(_spawner);
      switch (levelNumber)
      {
         case 1:
         {
            level.MediumLevel(sprites);
            break;
         }
         case 2:
         {
            _gameState.isLastLevel = true;
            level.HardLevel(sprites);
            break;
         }  
         default: return;
      }
      _nextLevelbutton.SetActive(false);
      _gameController.PlayMode.Invoke();
      StartCoroutine(countDown);
   }
   public  void EasyLevelSettings()
   {
      columnsCount = 1;
      elementsСountPerLine = 3;
      startPositionX = -5;
      startPositionY = 0;
      distanceBetweenElements = 5;
      lineSpacing = 0;
   }
   public  void MediumLevelSettings()
   {
      columnsCount = 2;
      elementsСountPerLine = 3;
      startPositionX = -5;
      startPositionY = 2;
      distanceBetweenElements = 5;
      lineSpacing =1;
   }
   public  void HardLevelSettings()
   {
      columnsCount = 3;
      elementsСountPerLine = 3;
      startPositionX = -4;
      startPositionY = 3;
      distanceBetweenElements = 4;
      lineSpacing = 1;
   }
}
