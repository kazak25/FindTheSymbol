using System.Linq;
using GameSettings;
using JetBrains.Annotations;
using ScriptableObjects;
using SimpleEventBus.Disposables;
using StateMachine;
using UI;
using UnityEngine;

namespace States
{
    public class SetSelectionState : MonoBehaviour, IStateWithContext<GameModeSelection>
    {
        [SerializeField] private GameObject _setSelectionObject;
        [SerializeField] private GameObject _loading;
        [SerializeField] private GameObject _cell;
        [SerializeField] private Canvas _setSelection;
    
        private SymbolsSet _symbolsSetView;
        private SpriteModels _spriteModels;
        private GameModeSelection _gameModeSelection;
        private StateMachine.StateMachine _stateMachine;
        private CompositeDisposable _subscription;
   
        public void Initialize(StateMachine.StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Initialize(SymbolsSet symbolsSet)
        {
            _symbolsSetView = symbolsSet;
        }
        public void Initialize(SpriteModels spriteModels)
        {
            _spriteModels = spriteModels;
        }
        public void Initialize(GameModeSelection gameModeSelection)
        {
            _gameModeSelection = gameModeSelection;
        }
        public void Enter(GameModeSelection gameModeSelection)
        {
            SetStandart(gameModeSelection);
        }
        private void SetStandart(GameModeSelection gameModeSelection)
        {
            _gameModeSelection = gameModeSelection;
            _setSelectionObject.SetActive(true);
            AddStartIcons();
            SetSelection();
        }

        [UsedImplicitly] 
        public void HideLoading()
        {
            _loading.SetActive(false);
        }
        public void SetSelection()
        {
            for (var i = 0; i < _spriteModels._icons.Count; i++)
            {
                var cell = Instantiate(_cell, _setSelection.transform);
                var setView = Instantiate(_symbolsSetView, cell.transform);
                setView.Initialize(_spriteModels.AllObjects[i].First(), _spriteModels.AllObjectsNames[i]);
                setView.name = _spriteModels.AllObjectsNames[i];
            }
        }
        public void AddStartIcons()
        {
            for (int i = 0; i < _spriteModels.AllObjects.Count; i++)
            {
                _spriteModels._icons.Add(_spriteModels.AllObjects[i].First()); 
            }
        }
        public void Exit()
        {
            
        }
    }
}
