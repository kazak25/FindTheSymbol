using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using JetBrains.Annotations;
using ScriptableObjects;
using Settings;
using StateMachine;
using UnityEngine;

namespace States
{
    public class GameState : MonoBehaviour, IStateWithoutContext
    {
        public bool isWinCondition { get; private set; }
        public bool isLastLevel = false;

        [SerializeField] private LevelDifficulty _levelDifficulty;
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _currentLevel;

        private LevelSettings _levelSettings;
        private SpriteModels _spriteModels;
        private int _levelNumber;
        private IReadOnlyList<Sprite> _sprites = new List<Sprite>();
        private StateMachine.StateMachine _stateMachine;


        public void Initialize(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }

        public void Initialize(SpriteModels spriteModels)
        {
            _spriteModels = spriteModels;
        }


        public void Array(IReadOnlyList<Sprite> sprites)
        {
            _sprites = sprites;
        }

        public void Initialize(StateMachine.StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _levelDifficulty.Easylevel(_sprites);
            StartCoroutine(CountDown());
        }

        [UsedImplicitly]
        public void ChangeLevelNumber()
        {
            _levelNumber++;
        }

        public void Exit()
        {
            _gameController.ChildrenDelete(_currentLevel);
        }

        [UsedImplicitly]
        public void WinConditionOff()
        {
            isWinCondition = false;
        }

        public void WinConditionOn()
        {
            isWinCondition = true;
        }

        public void ChangeLevel()
        {
            _levelSettings.NextLevelSettings(_levelDifficulty, _levelNumber, _sprites, CountDown());
        }

        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(5);
            foreach (var cel in _spriteModels.Cells)
            {
                var sprite = cel.GetComponentInChildren<SpriteRenderer>(); 
                cel.transform.DORotate(new Vector3(0, 180, 0), 3);
                var icon = cel.GetComponentInChildren<SpriteRenderer>(); 
                icon.flipX = true;
                yield return null;
                sprite.DOColor(Color.clear, 2);
            }
        }
    }
}